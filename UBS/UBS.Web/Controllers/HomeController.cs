using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Core.Interfaces;

namespace UBS.Web.Controllers
{
    public class HomeController : Controller
    {
        public List<Person> items = new List<Person>();
        private readonly IUpdateModel _updateModel;
        public HomeController(IUpdateModel updateModel)
        {
            _updateModel = updateModel;
        }

        public ActionResult Index()
        {
            Person person = new Person();
            person.Gender = "Masculino";
            person.Company = "UBS Tecnologia";
            person.State = "São Paulo";

            items.Add(person);

            ViewBag.GridViewString = items;

            return View();
        }
        
        [HttpPost]
        public JsonResult UpdateModel()
        {
            //ViewBag.GridViewString = _updateModel.Start("D:\\Mock\\MOCK_DATA_1.json");
            return Json(PersonProvider.ListPerson);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dados: ";

            return View();
        }
    }
}