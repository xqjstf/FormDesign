using FormDesign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FormDesign.Controllers
{
    public class HomeController : BaseController
    {
        private IFormDesignService _IFormDesign = new FormDesignService();

        /// <summary>
        /// 表单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        #region 表单模板
        public ActionResult FormTemplate(int page = 1)
        {
            return View(_IFormDesign.GetFormTemplate(page, PageSize));
        }
        public ActionResult SaveFormTemplate(int? id)
        {
            FormTemplate model = null;
            if (id.HasValue)
            {
                model = _IFormDesign.GetFormTemplate(id.Value);
                if (model == null)
                {
                    return Alert("表单模板不存在！");
                }
            }
            else
            {
                model = new Models.FormTemplate();
            } 
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveFormTemplate(FormTemplate model)
        {
            _IFormDesign.Save<FormTemplate>(model);
            return Alert("数据保存成功！", Url.Action("FormTemplate"));
        }

        public ActionResult DelFormTemplate(int id)
        {
            _IFormDesign.Delete<FormTemplate>(id);
            return Alert("删除成功！", Url.Action("FormTemplate"));
        }
        #endregion

        #region 字段模板
        public ActionResult FieldTemplate(int page = 1)
        {
            return View(_IFormDesign.GetFieldTemplate(page, PageSize));
        }
        public ActionResult SaveFieldTemplate(int? id)
        {
            FieldTemplate model = null;
            if (id.HasValue)
            {
                model = _IFormDesign.GetFieldTemplate(id.Value);
                if (model == null)
                {
                    return Alert("表单模板不存在！");
                }
            }
            else
            {
                model = new FieldTemplate();
            }
            ViewData["GroupId"] = new SelectList(FormDesign.Models.FieldTemplate.FieldTemplateGroup, "key", "value", model.GroupId);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveFieldTemplate(FieldTemplate model)
        {
            _IFormDesign.Save<FieldTemplate>(model);
            return Alert("数据保存成功！", Url.Action("FieldTemplate"));
        }

        public ActionResult DelFieldTemplate(int id)
        {
            _IFormDesign.Delete<FieldTemplate>(id);
            return Alert("删除成功！", Url.Action("FieldTemplate"));
        }
        #endregion

        #region 字段配置
        public ActionResult FieldConfig(int page = 1)
        {
            return View(_IFormDesign.GetFieldConfig(page, PageSize));
        }
        public ActionResult SaveFieldConfig(int? id)
        {
            FieldConfig model = null;
            if (id.HasValue)
            {
                model = _IFormDesign.GetFieldConfig(id.Value);
                if (model == null)
                {
                    return Alert("表单模板不存在！");
                }
            }
            else
            {
                model = new Models.FieldConfig();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveFieldConfig(FieldConfig model)
        {
            _IFormDesign.Save<FieldConfig>(model);
            return Alert("数据保存成功！", Url.Action("FieldTemplate"));
        }

        public ActionResult DelFieldConfig(int id)
        {
            _IFormDesign.Delete<FieldConfig>(id);
            return Alert("删除成功！", Url.Action("FieldTemplate"));
        }
        #endregion

        #region 表单配置
        public ActionResult FormConfig()
        {
            return View();
        }

        #endregion

        #region 表单预览
        /// <summary>
        /// 表单预览
        /// </summary>
        /// <returns></returns>
        public ActionResult FormConfigPreview(int id = 1)
        {

            FormConfig config = _IFormDesign.GetFormConfig(id);
            if (config == null)
            {
                return Alert("请先配置表单信息");
            }
            FormTemplate ft = _IFormDesign.GetFormTemplate(config.FormTemplateId);
            if (ft == null)
            {
                return Alert("请先配置表单模板信息");
            }
            FieldTemplateGroup fg = _IFormDesign.GetFieldTemplateGroup(config.FieldTemplateGroupId);
            if (ft == null)
            {
                return Alert("请先配置字段模板组信息");
            }

            IList<FieldTemplate> ftList = _IFormDesign.GetFieldTemplateByGroupId(config.FieldTemplateGroupId);
            if (ftList.Count == 0)
            {
                return Alert("请先配置表单字段");
            }
            //表单字段
            if (string.IsNullOrEmpty(config.TableName))
            {
                return Alert("请先配置表单信息对应表名称");
            }
            List<FieldConfig> fcList = new List<FieldConfig>();
            foreach (var item in config.TableName.Split(','))
            {
                if (string.IsNullOrEmpty(item) == false)
                {
                    fcList.AddRange(_IFormDesign.GetFieldConfigByTableName(item));
                }
            }

            //组装页面显示html
            StringBuilder sbHdFildHtml = new StringBuilder();
            StringBuilder sbFildHtml = new StringBuilder();

            for (int i = 0; i < fcList.Count; i++)
            {

                if (fcList[i].FieldType == (int)EmFieldType.Hidden)
                {
                    sbHdFildHtml.AppendLine("<input type='hidden' name='" + fcList[i].Field + "'>");
                    continue;
                }
                else
                {
                    var ftp = ftList.FirstOrDefault(p => p.Id == fcList[i].FieldTemplateId);
                    if (ftp == null)
                    {
                        return Alert(string.Format("{0}下的{1}字段模板不存在", fcList[i].TableName, fcList[i].Field));
                    }
                    var currentFiledCount = fcList.Count - (ftp.FieldCount + i);
                    if (currentFiledCount < 0) //如果剩余字段不够填充
                    {
                        ftp = ftList.FirstOrDefault(p => p.FieldCount == (ftp.FieldCount - 1));
                        if (ftp == null)
                        {
                            return Content("<script>alert('请配置字段个数为" + currentFiledCount + "的字段模板！')</script>");
                        }
                    }
                    sbFildHtml.AppendLine(ftp.Content);




                    //模板字段内容处理 
                    string fildContent = null;
                    for (int j = 0; j < ftp.FieldCount; j++)
                    {
                        if (fcList[i].FieldType == (int)EmFieldType.Lable)
                        {
                            fildContent = "<label name=\"" + fcList[i].Field + "\"></label>";
                        }
                        else if (fcList[i].FieldType == (int)EmFieldType.Text)
                        {
                            fildContent = "<input type=\"text\" name=\"" + fcList[i].Field + "\" />";
                        }
                        else if (fcList[i].FieldType == (int)EmFieldType.TextArea)
                        {
                            fildContent = "<textarea  name=\"" + fcList[i].Field + "\"></textarea>";
                        }
                        else if (fcList[i].FieldType == (int)EmFieldType.Password)
                        {
                            fildContent = "<input type=\"password\"  name=\"" + fcList[i].Field + "\"/>";
                        }
                        else if (fcList[i].FieldType == (int)EmFieldType.NormalButton)
                        {
                            fildContent = "<input type=\"button\" value=\"" + fcList[i].FieldLable + "\"/>";
                        }
                        else if (fcList[i].FieldType == (int)EmFieldType.SubmitButton)
                        {
                            fildContent = "<input type=\"submit\" value=\"" + fcList[i].FieldLable + "\"/>";
                        }
                        else if (fcList[i].FieldType == (int)EmFieldType.Radio)
                        {

                        }
                        else if (fcList[i].FieldType == (int)EmFieldType.CheckBox)
                        {

                        }
                        else if (fcList[i].FieldType == (int)EmFieldType.Select)
                        {

                        }
                        sbFildHtml.Replace("{$filed" + (j + 1) + "Name$}", fcList[i].FieldLable).Replace("{$filed" + (j + 1) + "$}", fildContent);

                        if (j < ftp.FieldCount - 1)
                        {
                            i++;
                        }
                    }
                }
            }

            StringBuilder sbHtml = new StringBuilder();
            sbHtml.AppendLine("<style type='text/css'>");
            sbHtml.AppendLine(ft.Style);
            sbHtml.AppendLine(fg.Style);
            sbHtml.AppendLine("</style>");
            sbHtml.AppendLine(ft.Content.Replace("<formContent></formContent>", Convert.ToString(sbHdFildHtml) + Convert.ToString(sbFildHtml)));
            return Content(sbHtml.ToString());
        }
        #endregion
    }
}