using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.DynamicForm.Dto;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Configure()
        {
            var data = new List<FormAttributeDto> {
                new FormAttributeDto(){
                    ControlType=Core.DynamicForm.FormAttributeControlType.DropDownList,
                    DisplayOrder=131,
                    Id=13,
                    Required=true,
                    Name="收货地址"
                },
                 new FormAttributeDto(){
                    ControlType=Core.DynamicForm.FormAttributeControlType.DropDownList,
                    DisplayOrder=131,
                    Id=13,
                    Required=true,
                    Name="收货地址"
                }
            };
            return View(data);
        }

        public IActionResult EditFormAttribute()
        {
            var data = FormAttributeViewModel.Imitate();
            return View(data);
        }
        [HttpPost]
        public IActionResult EditFormAttribute(FormAttributeViewModel model)
        {
            var data = model;
            return View(data);
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
