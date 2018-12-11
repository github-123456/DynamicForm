using Application.DynamicForm.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DynamicForm
{
    public interface IDynamicFormService
    {
        List<OrderAttributeDto> GetOrderAttributes(int tenantId);
        List<FormAttributeDto> GetAttributes(int tenantId);
        void SaveAttribute(FormAttributeEditDto dto);
        FormAttributeEditDto GetAttribute(int attributeId);
        List<OrderDto> GetOrders(int tenantId);
        void SaveOrder(int orderId, int tenantId, List<GenericAttributeDto> dto);
        List<FormAttributeEditDto> GetFormAttributes(int tenantId, int orderId);
    }
}
