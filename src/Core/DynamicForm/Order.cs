using Core.MultiTenant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.DynamicForm
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Tenant))]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
