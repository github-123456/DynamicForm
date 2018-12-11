using Core.DynamicForm;
using Core.MultiTenant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
               : base(options)
        { }
        public DbSet<FormAttribute> FormAttributes { get; set; }
        public DbSet<FormAttributeValue> FormAttributeValues { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GenericAttribute> GenericAttributes { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

    }
}
