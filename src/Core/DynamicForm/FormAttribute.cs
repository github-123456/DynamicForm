using Core.MultiTenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.DynamicForm
{
    public class FormAttribute
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Tenant))]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Name { get; set; }
        public FormAttributeControlType ControlType { get; set; }
        public bool Required { get; set; }
        public int DisplayOrder { get; set; }
        public List<FormAttributeValue> FormAttributeValues { get; set; } = new List<FormAttributeValue>();
    }
}
