using System.Collections.Generic;
using System.Text;
using System.Web.Routing;
using System.Linq;
using System.Collections.Specialized;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace System.Web.Mvc
{
    public static class HtmlHelpers
    {
        #region 分页控件(学工)
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper">helper 对象</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">显示条数</param>
        /// <param name="recordCount">总条数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns>html代码</returns>
        public static MvcHtmlString Pager(this HtmlHelper helper, long currentPageIndex, long pageSize, long recordCount, long pageCount)
        {
            if (recordCount == 0)
            {
                return null;
            }
            int btnCount = 7;
            TagBuilder builder = new TagBuilder("ul");
            builder.AddCssClass("pagination");
            StringBuilder sbHtml = new StringBuilder();
            sbHtml = GetNormalPage(currentPageIndex, pageSize, recordCount, pageCount, btnCount);
            builder.InnerHtml = Convert.ToString(sbHtml);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
        /// <summary>
        /// 获取普通分页
        /// </summary> 
        private static StringBuilder GetNormalPage(long currentPageIndex, long pageSize, long recordCount, long pageCount, int btnCount)
        {
            StringBuilder url = new StringBuilder();
            url.Append(HttpContext.Current.Request.Url.AbsolutePath + "?page={0}");
            NameValueCollection collection = HttpContext.Current.Request.QueryString;
            string[] keys = collection.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].ToLower() != "page")
                {
                    url.AppendFormat("&{0}={1}", HttpUtility.UrlEncode(keys[i]), HttpUtility.UrlEncode(collection[keys[i]]));
                }
            }


            StringBuilder sb = new StringBuilder();
            if (currentPageIndex > 1)
            {
                sb.AppendFormat(@"<li>
                                    <a href='{0}' aria-label='Previous'>
                                        <span aria-hidden='true'>&laquo;</span>
                                    </a>
                                </li>", string.Format(url.ToString(), currentPageIndex - 1));

            }
            else
            {
                sb.AppendFormat(@"<li class='disabled'>
                                        <a href='javscript:void(0)' aria-label='Previous'>
                                            <span aria-hidden='true'>&laquo;</span>
                                        </a>
                                  </li>");
            }




            sb.Append(GetNumericPage(currentPageIndex, pageSize, recordCount, pageCount, url.ToString(), btnCount));
            if (currentPageIndex < pageCount)
            {
                sb.AppendFormat(@"<li>
                                        <a href='{0}' aria-label='Next'>
                                            <span aria-hidden='true'>&laquo;</span>
                                        </a>
                                  </li>", string.Format(url.ToString(), currentPageIndex + 1));
            }
            else
            {
                sb.AppendFormat(@"<li class='disabled'>
                                        <a href='javscript:void(0)' aria-label='Next'>
                                            <span aria-hidden='true'>&laquo;</span>
                                        </a>
                                  </li>");
            }
            return sb;
        }

        /// <summary>
        /// 获取数字分页
        /// </summary>
        /// <param name="currentPageIndex">当前页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="recordCount">数据总条数</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="url">地址</param>
        /// <param name="btnCount">没有按钮显示个数</param>
        /// <returns></returns>
        private static string GetNumericPage(long currentPageIndex, long pageSize, long recordCount, long pageCount, string url, int btnCount)
        {
            int start = btnCount / 2;
            int end = btnCount - 1;
            long beginNum = currentPageIndex - start > pageCount - end ? pageCount - end : currentPageIndex - start;
            if (beginNum < 1)
            {
                beginNum = 1;
            }
            long endNum = beginNum + btnCount > pageCount ? pageCount : beginNum + end;

            StringBuilder sb = new StringBuilder();
            for (long i = beginNum; i <= endNum; i++)
            {
                if (i == currentPageIndex)
                {
                    sb.AppendLine("<li class='active'><a href='javascript:void(0)'>" + i + "</a></li>");
                }
                else
                {
                    sb.AppendLine("<li><a href='" + string.Format(url.ToString(), i) + "'>" + i + "</a></li>");
                }
            }
            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// 下拉框绑定
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="name">名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="haveNull">是否包含空值</param>
        /// <param name="enumType">枚举类型</param>
        /// <param name="htmlAttributes">html属性</param>
        /// <returns></returns>
        public static MvcHtmlString DropDownList(this HtmlHelper htmlHelper, string name, object defaultValue, bool haveNull, Type enumType, object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("select");
            builder.MergeAttribute("name", name);
            builder.GenerateId(name);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            if (haveNull)
            {
                builder.InnerHtml += "<option value=''>-请选择-</option>";
            }
            foreach (object e in Enum.GetValues(enumType))
            {
                string filed = e.ToString();
                string filedName = (e.GetType().GetField(filed).GetCustomAttributes(typeof(DisplayAttribute), true)[0] as DisplayAttribute).Name;
                TagBuilder tag2 = new TagBuilder("option");
                tag2.SetInnerText(filedName);
                tag2.MergeAttribute("value", filed);
                if (filed.Equals(defaultValue))
                {
                    tag2.MergeAttribute("selected", "selected");
                }
                builder.InnerHtml += tag2.ToString(TagRenderMode.Normal);
            }
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}