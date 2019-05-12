using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UBS.Web.Models;
using Core.Interfaces;
using Core.Entities;

namespace UBS.Web.Controllers
{
    public class PersonController : Controller
    {
        private UBSWebContext db = new UBSWebContext();
        private readonly IWatcher _wacher;
        private readonly IUpdateModel _updateModel;


        public PersonController(IWatcher wacher, IUpdateModel updateModel)
        {
            //_wacher = wacher;
            //_updateModel = updateModel;
            //_wacher.CreateWacher("D:\\Mock", "MOCK_DATA_1.json");
        }

        // GET: Person
        public async Task<ActionResult> Index()
        {
            ViewBag.zezinho = PersonProvider.ListPerson;


            IEnumerable<Person> listPerson = PersonProvider.ListPerson;
            return View(listPerson);
        }
    }
}
