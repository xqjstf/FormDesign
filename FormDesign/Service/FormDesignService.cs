using FormDesign.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormDesign
{
    class FormDesignService : IFormDesignService
    {
        private IFormDesignService _IFormDesign;
        private Database DB;
        public FormDesignService(string connectionStringName)
        {
            _IFormDesign = new FormDesignService(connectionStringName);
            DB = new Database(connectionStringName);
        }
        public FormDesignService(string connectionString, string providerName)
        {
            _IFormDesign = new FormDesignService(connectionString, providerName);
            DB = new Database(connectionString, providerName);
        }

        #region 表单模板
        /// <summary>
        /// 表单模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FormTemplate GetFormTemplate(int id)
        {
            return DB.FirstOrDefault<FormTemplate>("Id=@0", id);
        }
        /// <summary>
        /// 表单模板分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FormTemplate> GetFormTemplatePage(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FormTemplate>(pageIndex, pageSize, sql);
        }
        #endregion

        #region 字段模板
        /// <summary>
        /// 字段模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FieldTemplate FieldTemplate(int id)
        {
            return DB.FirstOrDefault<FieldTemplate>("Id=@0", id);
        }
        /// <summary>
        /// 字段模板分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FieldTemplate> GetFieldTemplatePage(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FieldTemplate>(pageIndex, pageSize, sql);
        }
        #endregion

        #region 字段配置
        /// <summary>
        /// 字段配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FieldConfig FieldConfig(int id)
        {
            return DB.FirstOrDefault<FieldConfig>("Id=@0", id);
        }
        /// <summary>
        /// 字段配置分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FieldConfig> GetFieldConfigPage(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FieldConfig>(pageIndex, pageSize, sql);
        }
        #endregion

        #region 表单配置
        /// <summary>
        /// 表单配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FormConfig FormConfig(int id)
        {
            return DB.FirstOrDefault<FormConfig>("Id=@0", id);
        }
        /// <summary>
        /// 表单配置分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FormConfig> GetFormConfigPage(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FormConfig>(pageIndex, pageSize, sql);
        }
        #endregion

        /// <summary>
        /// 表单预览
        /// </summary>
        /// <returns></returns>
        public string FormConfigPreview()
        {
            FormConfig config = new FormConfig();
            config.Id = 1;
            config.FieldTemplateGroupId = 1;

            FormTemplate ft = new FormTemplate();
            ft.Content = "<table  cellspacing=\"0\"><formContent></formContent></table>";
            ft.Style = ".text-right {text-align: right;} table{width: 100%;border-bottom:1px solid #ccc;border-right: 1px solid #ccc;} table td{padding: 5px; border-top: 1px solid #ccc;border-left: 1px solid #ccc;}";

            FieldTemplateGroup fg = new FieldTemplateGroup();
            fg.Id = config.FieldTemplateGroupId;
            fg.Name = "常规表格字段模板组";
            fg.Style = "";

            IList<FieldTemplate> ftList = new List<FieldTemplate>();
            ftList.Add(new FieldTemplate
            {
                Content = "<tr></td><td colspan='4'>{$filed1Name$}</td></tr>",
                GroupId = fg.Id,
                FieldCount = 0,
                Id = 0
            });

            ftList.Add(new FieldTemplate
            {
                Content = "<tr><td class=\"text-right\" width=\"15%\" >{$filed1Name$}：</td><td colspan='3'  width=\"35%\">{$filed1$}</td></tr>",
                GroupId = fg.Id,
                FieldCount = 1,
                Id = 1
            });
            ftList.Add(new FieldTemplate
            {
                Content = "<tr><td class=\"text-right\" width=\"15%\">{$filed1Name$}：</td><td  width=\"35%\">{$filed1$}</td><td width=\"15%\" class=\"text-right\">{$filed2Name$}：</td><td  width=\"35%\">{$filed2$}</td></tr>",
                GroupId = fg.Id,
                FieldCount = 2,
                Id = 2
            });

            IList<FieldConfig> fcList = new List<FieldConfig>();
            fcList.Add(new Models.FieldConfig()
            {
                Field = "StudentId",
                FieldLable = "学号",
                FieldType = (int)EmFieldType.Hidden,
                FieldLength = 20,
                IsEnabled = true,
                IsPrimaryKey = true,
                IsRequired = true,
                Seq = 1,
                FieldTemplateId = 0,
                TableName = "YX_NewStudentInfo"
            });

            fcList.Add(new Models.FieldConfig()
            {
                Field = "Name",
                FieldLable = "姓名",
                FieldLength = 20,
                FieldType = (int)EmFieldType.Lable,
                IsEnabled = true,
                IsPrimaryKey = false,
                IsRequired = true,
                FieldTemplateId = 2,
                Seq = 2,
                TableName = "YX_NewStudentInfo"
            });

            fcList.Add(new Models.FieldConfig()
            {
                Field = "EnrollId",
                FieldLable = "考生号",
                FieldLength = 20,
                FieldType = (int)EmFieldType.Lable,
                IsEnabled = true,
                IsPrimaryKey = false,
                IsRequired = true,
                FieldTemplateId = 2,
                Seq = 2,
                TableName = "YX_NewStudentInfo"
            });

            fcList.Add(new Models.FieldConfig()
            {
                Field = "Birthday",
                FieldLable = "出生日期",
                FieldLength = 20,
                FieldType = (int)EmFieldType.Text,
                IsEnabled = true,
                IsPrimaryKey = false,
                IsRequired = true,
                FieldTemplateId = 2,
                Seq = 2,
                TableName = "YX_NewStudentInfo"
            });


            fcList.Add(new Models.FieldConfig()
            {
                Field = "IdCard",
                FieldLable = "身份证号码",
                FieldLength = 25,
                FieldType = (int)EmFieldType.Text,
                IsEnabled = true,
                IsPrimaryKey = false,
                IsRequired = true,
                FieldTemplateId = 2,
                Seq = 2,
                TableName = "YX_NewStudentInfo"
            });


            fcList.Add(new Models.FieldConfig()
            {
                Field = "FamillyAddress",
                FieldLable = "家庭地址",
                FieldLength = 250,
                FieldType = (int)EmFieldType.Text,
                IsEnabled = true,
                IsPrimaryKey = false,
                IsRequired = true,
                FieldTemplateId = 2,
                Seq = 2,
                TableName = "YX_NewStudentInfo"
            });

            fcList.Add(new Models.FieldConfig()
            {
                Field = "",
                FieldLable = "提交",
                FieldLength = 250,
                FieldType = (int)EmFieldType.SubmitButton,
                IsEnabled = true,
                IsPrimaryKey = false,
                IsRequired = true,
                FieldTemplateId = 0,
                Seq = 2,
                TableName = "YX_NewStudentInfo"
            });

            //组装页面显示html
            StringBuilder sbHdFildHtml = new StringBuilder();
            StringBuilder sbFildHtml = new StringBuilder();

            //字段个数分组 



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
                        return Content("<script>alert('请配置字段个数为" + ftp.FieldCount + "的字段模板！')</script>");
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
