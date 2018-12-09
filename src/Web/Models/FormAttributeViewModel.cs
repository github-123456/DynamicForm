using Core.DynamicForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class FormAttributeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FormAttributeControlType ControlType { get; set; }
        public bool Required { get; set; }
        public int DisplayOrder { get; set; }
        public List<FormAttributeViewValueModel> FormAttributeViewValueModels { get; set; }
        public static FormAttributeViewModel Imitate()
        {
            var data = new FormAttributeViewModel();
            data.FormAttributeViewValueModels = new List<FormAttributeViewValueModel>()
            {
                new FormAttributeViewValueModel(){ Id=0,Name="xxx",DisplayOrder=0 },
                new FormAttributeViewValueModel(){ Id=1,Name="aaa",DisplayOrder=10 },
            };
            return data;
        }
    }

    public class FormAttributeViewValueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
