using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Ajax使用.Models
{
    public class PeopleController : Controller
    {
        private Person[] personData =
        {
            new Person {FirstName="Adam",LastName="Freeman",Role=Role.Admin },
            new Person {FirstName="Steven",LastName="Sanderson",Role=Role.Admin },
            new Person {FirstName="Jacqui",LastName="Griffyth",Role=Role.User },
            new Person {FirstName="John",LastName="Smith",Role=Role.User },
            new Person {FirstName="Anne",LastName="Jones",Role=Role.Guest}
        };
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<Person> GetData(string seletedRole)
        {
            IEnumerable<Person> data = personData;
            if(seletedRole!="All")
            {
                Role seleted = (Role)Enum.Parse(typeof(Role), seletedRole);
                data = personData.Where(p => p.Role == seleted);
            }
            return data;
        }

        public JsonResult GetPeopleDataJson(string selectedRole="All")
        {
            IEnumerable<Person> data = GetData(selectedRole);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPeople(string selectedRole="All")
        {
            return View((Object)selectedRole);
        }

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole)
        //{
        //    if(selectedRole==null||selectedRole=="All")
        //    {
        //        return View(personData);
        //    }
        //    else
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        return View(personData.Where(p => p.Role == selected));
        //    }
        //}


        public PartialViewResult GetPeopleData(string selectedRole="All")
        {
            //bool IsAjaxRequest = Request.IsAjaxRequest();
            //Thread.Sleep(5000);
            //IEnumerable<Person> data = personData;
            //if (selectedRole != "All")
            //{
            //    Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
            //    data = personData.Where(p => p.Role == selected);
            //}
            //return PartialView(data);
            return PartialView(GetData(selectedRole));
        }
    }
}