using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DynamicForm
{
    public class FormAttributeValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public FormAttribute FormAttribute { get; set; }
    }
}
