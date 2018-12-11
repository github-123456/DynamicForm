using Core.DynamicForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DynamicForm.Dto
{
    public class FormAttributeEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public FormAttributeControlType ControlType { get; set; }
        public bool Required { get; set; }
        public int DisplayOrder { get; set; }
        public int TenantId { get; set; }
        public List<FormAttributeValueEditDto> FormAttributeValueEditDtos { get; set; } = new List<FormAttributeValueEditDto>();
    }
    public class FormAttributeValueEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
