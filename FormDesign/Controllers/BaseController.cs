using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FormDesign.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Layer弹窗
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="url">返回地址（空则返回上一页）</param>
        /// <returns></returns>
        public ActionResult Alert(string msg, string url = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("alert('" + msg + "')");
            if (string.IsNullOrEmpty(url))
            {
                sb.Append(";history.back();");
            }
            else
            {
                sb.Append(";window.location.href = '" + url + "'");
            }
            sb.Append("</script>");
            return Content(sb.ToString());
        }
    }
}