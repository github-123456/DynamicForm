using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Application.DynamicForm.Dto
{
    public class OrderDto
    {
        public string this[int id] => GenericAttributeDtos.FirstOrDefault(s => s.FormAttributeId == id)?.Value;
        public int Id { get; set; }
        public string TenantName { get; set; }
        public DateTime InsertTime { get; set; }
        public List<GenericAttributeDto> GenericAttributeDtos { get; set; }
    }
    public class GenericAttributeDto
    {
        public int FormAttributeId { get; set; }
        public string Value { get; set; }
    }
}
