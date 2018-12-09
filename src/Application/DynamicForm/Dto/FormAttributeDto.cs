using Core.DynamicForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DynamicForm.Dto
{
    public class FormAttributeDto
    {
        public int Id { get; set; }
        public string TenantName { get; set; }
        public string Name { get; set; }
        public FormAttributeControlType ControlType { get; set; }
        public bool Required { get; set; }
        public int DisplayOrder { get; set; }
    }
}
