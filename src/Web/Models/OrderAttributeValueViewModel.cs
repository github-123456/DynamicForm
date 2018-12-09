using Core.DynamicForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class OrderAttributeViewModel
    {
        public string Name { get; set; }
        public FormAttributeControlType ControlType { get; set; }
        public List<OrderAttributeValueViewModel> OrderAttributeValueViewModels { get; set; }
        public string Value { get; set; }
        public static List<OrderAttributeViewModel> Imitate()
        {
            var model = new List<OrderAttributeViewModel>()
            {
                new OrderAttributeViewModel{ Name="名称",ControlType=FormAttributeControlType.TextBox},
                new OrderAttributeViewModel{ Name="联系电话",ControlType=FormAttributeControlType.TextBox},
                new OrderAttributeViewModel{ Name="备注",ControlType=FormAttributeControlType.TextBox},
            };
            return model;
        }
    }
    public class OrderAttributeValueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
