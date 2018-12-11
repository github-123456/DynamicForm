using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.DynamicForm
{
    public class GenericAttribute
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        [ForeignKey(nameof(FormAttribute))]
        public int FormAttributeId { get; set; }
        public FormAttribute FormAttribute { get; set; }
        public string Value { get; set; }
    }
}
