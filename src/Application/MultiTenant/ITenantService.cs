using Application.MultiTenant.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MultiTenant
{
    public interface ITenantService
    {
        List<TenantDto> GetTenants();
        List<TenantDto> InsertExampleData();
    }
}
