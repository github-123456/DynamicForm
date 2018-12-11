using Application.DynamicForm.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class OrderListViewModel
    {
        public List<OrderDto> OrderDtos { get; set; }
        public List<OrderAttributeDto> OrderAttributeDtos { get; set; }
    }
}
