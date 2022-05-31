using Master_detail.Models;
using Master_detail.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Master_detail.Controllers
{

    public class HomeController : Controller

    {
        private EMPMV db = new EMPMV();

        // GET: Home
        public ActionResult Index()
        {
            //EMP emp = db.AutoGenerate();

            //EMP emp = new EMP();
            //emp.Deptid = Convert.ToInt16(db.AutoGenerate());
            //emp.EMPNO = Convert.ToInt16(db.AutoGenerateEMPNO());
            EMP emp = db.AutoGenerate();

            return View(emp);
        }

        //[HttpGet]
        //public JsonResult Save()
        //{
           

        //    return new JsonResult { };

        //}

        [HttpPost]
        public JsonResult Save(Dept d)
        {
            bool status = false;

            db.AddNewDEPT(d);

            foreach (var item in d.EMP)
            {
                db.AddNewEmployee(item);
                status = true;
            }


            return new JsonResult { Data = new { status = status } };
        }
    }
}