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
    }
}