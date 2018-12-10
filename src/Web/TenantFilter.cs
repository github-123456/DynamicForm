using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class TenantFilter :IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
            var tenantName = context.HttpContext.Request.Cookies["tenant"];
            context.HttpContext.Response.Cookies.Append("tenant", tenantName);
            context.HttpContext.Items["tenantName"] = string.IsNullOrEmpty(tenantName) ? "aaaa" : tenantName;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}
