using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.DynamicForm;
using Application.DynamicForm.Dto;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDynamicFormService dynamicFormService;
        private int TenantId => Convert.ToInt32(HttpContext.Items["tenantId"]);
        public HomeController(IDynamicFormService dynamicFormService)
        {
            this.dynamicFormService = dynamicFormService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Configure()
        {
            var data = this.dynamicFormService.GetAttributes(TenantId);
            return View(data);
        }

        public IActionResult EditFormAttribute(int attributeId)
        {
            FormAttributeEditDto data = null;
            if (attributeId == 0)
            {
                data = new FormAttributeEditDto();
            }
            else
                data = this.dynamicFormService.GetAttribute(attributeId);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditFormAttribute(FormAttributeEditDto data)
        {
            data.TenantId = TenantId;
            dynamicFormService.SaveAttribute(data);
            return View(data);
        }
        public IActionResult Order()
        {
            var data = dynamicFormService.GetOrders(TenantId);
            var OrderAttributeDtos = this.dynamicFormService.GetOrderAttributes(TenantId);
            return View(new OrderListViewModel() { OrderAttributeDtos = OrderAttributeDtos, OrderDtos = data });
        }
        public IActionResult EditOrder(int id)
        {
            var data = dynamicFormService.GetFormAttributes(TenantId, id);
            ViewBag.OrderId = id;
            return View(data);
        }
        [HttpPost]
        public IActionResult EditOrder(int orderId, List<FormAttributeEditDto> model)
        {
            var data = model.Select(s => new GenericAttributeDto() { FormAttributeId = s.Id, Value = s.Value }).ToList();
            this.dynamicFormService.SaveOrder(orderId, TenantId, data);
            return RedirectToAction("Order");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
