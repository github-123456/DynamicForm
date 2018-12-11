using Application.DynamicForm;
using Application.MultiTenant.Dto;
using Core;
using Core.MultiTenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Application.MultiTenant
{
    public class TenantService : ITenantService
    {
        private readonly AppDbContext dbContext;
        private readonly IDynamicFormService dynamicFormService;
        public TenantService(AppDbContext dbContext, IDynamicFormService dynamicFormService)
        {
            this.dbContext = dbContext;
            this.dynamicFormService = dynamicFormService;
        }
        public List<TenantDto> GetTenants()
        {
            return dbContext.Set<Tenant>().Select(s => new TenantDto() { Id = s.Id, Name = s.Name }).ToList();
        }
        public List<TenantDto> InsertExampleData()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var entities = new List<Tenant>() {
                new Tenant(){ Name="Tenant A" },
                new Tenant(){ Name="Tenant B" },
                new Tenant(){ Name="Tenant C" },
            };
                dbContext.AddRange(entities);
                dbContext.SaveChanges();
                dynamicFormService.SaveAttribute(new DynamicForm.Dto.FormAttributeEditDto()
                {
                    ControlType = Core.DynamicForm.FormAttributeControlType.RadioButtonList,
                    DisplayOrder = 10,
                    Name = "Test",
                    Required = true,
                    TenantId = entities.First().Id,
                    FormAttributeValueEditDtos = new List<DynamicForm.Dto.FormAttributeValueEditDto> {
                    new DynamicForm.Dto.FormAttributeValueEditDto()
                    {
                        DisplayOrder=10,
                        Name="a",
                    },
                    new DynamicForm.Dto.FormAttributeValueEditDto()
                    {
                        DisplayOrder=20,
                        Name="b",
                    },
                    new DynamicForm.Dto.FormAttributeValueEditDto()
                    {
                        DisplayOrder=30,
                        Name="c",
                    }
                }
                });
                dynamicFormService.SaveAttribute(new DynamicForm.Dto.FormAttributeEditDto()
                {
                    ControlType = Core.DynamicForm.FormAttributeControlType.DropDownList,
                    DisplayOrder = 20,
                    Name = "City",
                    Required = true,
                    TenantId = entities.First().Id,
                    FormAttributeValueEditDtos = new List<DynamicForm.Dto.FormAttributeValueEditDto> {
                    new DynamicForm.Dto.FormAttributeValueEditDto()
                    {
                        DisplayOrder=10,
                        Name="北京",
                    },
                    new DynamicForm.Dto.FormAttributeValueEditDto()
                    {
                        DisplayOrder=20,
                        Name="上海",
                    },
                    new DynamicForm.Dto.FormAttributeValueEditDto()
                    {
                        DisplayOrder=30,
                        Name="深圳",
                    }
                }
                });
                dynamicFormService.SaveAttribute(new DynamicForm.Dto.FormAttributeEditDto()
                {
                    ControlType = Core.DynamicForm.FormAttributeControlType.TextBox,
                    DisplayOrder = 30,
                    Name = "Detail address",
                    Required = true,
                    TenantId = entities.First().Id,
                });
                scope.Complete();
                return entities.Select(s => new TenantDto() { Id = s.Id, Name = s.Name }).ToList();
            }
        }
    }
}
