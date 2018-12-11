using Application.DynamicForm.Dto;
using Core;
using Core.DynamicForm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DynamicForm
{
    public class DynamicFormService : IDynamicFormService
    {
        private readonly AppDbContext dbContext;
        public DynamicFormService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<OrderAttributeDto> GetOrderAttributes(int tenantId)
        {
            return dbContext.Set<FormAttribute>().Where(s => s.TenantId == tenantId).OrderBy(s => s.DisplayOrder).Select(s => new OrderAttributeDto() { Id = s.Id, Name = s.Name }).ToList();
        }
        public List<OrderDto> GetOrders(int tenantId)
        {
            var data = dbContext.Set<Order>().Where(s => s.Tenant.Id == tenantId).Select(s => new OrderDto()
            {
                Id = s.Id,
                InsertTime = s.InsertTime.ToLocalTime(),
                TenantName = s.Tenant.Name,
            }).ToList();
            var orderIds = data.Select(s => s.Id);
            var genericAttributes = dbContext.Set<GenericAttribute>().Include(s => s.FormAttribute).Where(s => orderIds.Contains(s.EntityId)).ToList();
            var specialAttributes = genericAttributes.Where(s => s.FormAttribute.ControlType != FormAttributeControlType.TextBox).Select(s => new { s.FormAttribute.Id, s.Value });
            var specialAttributeValues = specialAttributes.Select(s => Convert.ToInt32(s.Value)).ToList();
            var sav = dbContext.Set<FormAttributeValue>().Where(s => specialAttributeValues.Contains(s.Id));
            foreach (var i in genericAttributes.Where(s => s.FormAttribute.ControlType != FormAttributeControlType.TextBox))
            {
                i.Value = sav.FirstOrDefault(s => s.Id.ToString() == i.Value)?.Name;
            }
            foreach (var i in data)
            {
                i.GenericAttributeDtos = genericAttributes.Where(s => s.EntityId == i.Id).Select(s => new GenericAttributeDto() { FormAttributeId = s.FormAttributeId, Value = s.Value }).ToList();
            }
            return data;
        }
        public void SaveOrder(int orderId, int tenantId, List<GenericAttributeDto> dto)
        {
            Order order = null;
            if (orderId == 0)
                order = new Order() { InsertTime = DateTime.UtcNow, TenantId = tenantId };
            else
                order = dbContext.Set<Order>().First(s => s.Id == orderId);
            dbContext.Update(order);
            dbContext.SaveChanges();

            var entities = dto.Select(s => new GenericAttribute() { EntityId = order.Id, FormAttributeId = s.FormAttributeId, Value = s.Value });
            dbContext.RemoveRange(dbContext.Set<GenericAttribute>().Where(s => s.EntityId == orderId));
            dbContext.UpdateRange(entities);
            dbContext.SaveChanges();
        }
        public List<FormAttributeDto> GetAttributes(int tenantId)
        {
            return dbContext.Set<FormAttribute>().Where(s => s.Tenant.Id == tenantId).Select(s => new FormAttributeDto() { Id = s.Id, ControlType = s.ControlType, DisplayOrder = s.DisplayOrder, Name = s.Name, Required = s.Required, TenantName = s.Tenant.Name }).OrderBy(s => s.DisplayOrder).ToList();
        }
        public FormAttributeEditDto GetAttribute(int attributeId)
        {
            var entity = this.dbContext.Set<FormAttribute>().Include(s => s.FormAttributeValues).First(s => s.Id == attributeId);
            var dto = new FormAttributeEditDto()
            {
                Id = entity.Id,
                TenantId = entity.TenantId,
                ControlType = entity.ControlType,
                DisplayOrder = entity.DisplayOrder,
                Name = entity.Name,
                Required = entity.Required,
            };
            foreach (var i in entity.FormAttributeValues.OrderBy(s => s.DisplayOrder))
            {
                dto.FormAttributeValueEditDtos.Add(new FormAttributeValueEditDto()
                {
                    DisplayOrder = i.DisplayOrder,
                    Id = i.Id,
                    Name = i.Name,
                });
            }
            return dto;
        }
        public void SaveAttribute(FormAttributeEditDto dto)
        {
            var entity = new FormAttribute()
            {
                Id = dto.Id,
                Name = dto.Name,
                Required = dto.Required,
                TenantId = dto.TenantId,
                ControlType = dto.ControlType,
                DisplayOrder = dto.DisplayOrder
            };
            foreach (var i in dto.FormAttributeValueEditDtos)
            {
                entity.FormAttributeValues.Add(new FormAttributeValue() { DisplayOrder = i.DisplayOrder, Id = i.Id, Name = i.Name });
            }

            if (entity.Id != 0)
            {
                var remove = dbContext.Set<FormAttributeValue>().Where(s => s.FormAttribute.Id == entity.Id).AsNoTracking().ToList().Where(s => !dto.FormAttributeValueEditDtos.Any(v => v.Id == s.Id));
                dbContext.RemoveRange(remove);
            }

            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
        public List<FormAttributeEditDto> GetFormAttributes(int tenantId, int orderId)
        {
            var dto = dbContext.Set<FormAttribute>().Include(s => s.FormAttributeValues).Where(s => s.TenantId == tenantId).ToList().Select(s => new FormAttributeEditDto() { ControlType = s.ControlType, DisplayOrder = s.DisplayOrder, Id = s.Id, Name = s.Name, Required = s.Required, TenantId = s.TenantId, FormAttributeValueEditDtos = s.FormAttributeValues.Select(v => new FormAttributeValueEditDto() { DisplayOrder = v.DisplayOrder, Id = v.Id, Name = v.Name }).ToList() }).ToList();
            if (orderId != 0)
            {
                var orderAttributes = dbContext.Set<GenericAttribute>().Where(s => s.EntityId == orderId).ToList();
                dto.ForEach(s => s.Value = orderAttributes.FirstOrDefault(oa => oa.FormAttributeId == s.Id)?.Value);
            }
            return dto;
        }
    }
}
