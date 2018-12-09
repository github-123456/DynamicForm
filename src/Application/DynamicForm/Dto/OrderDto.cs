using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Application.DynamicForm.Dto
{
    public class OrderDto
    {
        public string this[string name]
        {
            get
            {
                if (name == nameof(TenantName))
                    return TenantName;
                if (name == nameof(InsertTime))
                    return InsertTime.ToLocalTime().ToString();
                var attr = GenericAttributeDtos.FirstOrDefault(s => s.Name == name);
                return attr == null ? "" : attr.Value;
            }
        }
        public int Id { get; set; }
        public string TenantName { get; set; }
        public DateTime InsertTime { get; set; }
        public List<GenericAttributeDto> GenericAttributeDtos { get; set; }
        public static List<OrderDto> Imitate()
        {
            var tenantName = "tenant A";
            var data = new List<OrderDto> {
                new OrderDto(){
                    TenantName=tenantName,
                    InsertTime=DateTime.Now,
                     GenericAttributeDtos=new List<GenericAttributeDto>()
                     {
                         new GenericAttributeDto(){Name="名称",Value="aaa订单"},
                         new GenericAttributeDto(){ Name="联系电话",Value="1111111131"},
                         new GenericAttributeDto(){ Name="备注",Value="备注。。。。"}
                     }
                },
                new OrderDto(){
                    TenantName=tenantName,
                    InsertTime=DateTime.Now,
                     GenericAttributeDtos=new List<GenericAttributeDto>()
                     {
                         new GenericAttributeDto(){ Name="名称",Value="bbb订单"},
                         new GenericAttributeDto(){ Name="联系电话",Value="1111111131"},
                         new GenericAttributeDto(){ Name="备注",Value="markmarkmark。。。。"}
                     }
                }
            };
            return data;
        }
    }
    public class GenericAttributeDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
