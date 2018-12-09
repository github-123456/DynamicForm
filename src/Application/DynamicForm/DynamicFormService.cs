using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DynamicForm
{
    public class DynamicFormService
    {
        public string[] GetOrderAttributeNames(int tenantId)
        {
            var data =new string[] {"名称","联系电话","备注" };
            return data;
        }
    }
}
