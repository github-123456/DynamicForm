using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Application.MultiTenant;

namespace Web
{
    public class TenantFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tenantService = context.HttpContext.RequestServices.GetService<ITenantService>();
            var tenants = tenantService.GetTenants();
            if (tenants.Count < 1)
                tenants = tenantService.InsertExampleData();
            context.HttpContext.Items["tenants"] = tenants;

            var tenantName = context.HttpContext.Request.Cookies["tenantId"] ?? tenants.First().Id.ToString();
            context.HttpContext.Items["tenantId"] = tenantName;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
