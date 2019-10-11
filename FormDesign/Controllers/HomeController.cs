using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormDesign.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 表单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetSelectItem()
        {
            var arr = new string[] { "字段1", "字段2", "字段3" };
            return Json(arr, JsonRequestBehavior.AllowGet);
        }
    }
}