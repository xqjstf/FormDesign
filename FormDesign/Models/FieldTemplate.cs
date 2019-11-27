using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{
    /// <summary>
    /// 字段模板
    /// </summary>
    public class FieldTemplate
    {
        public int Id { get; set; }
        /// <summary>
        /// 组别
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// 所属模板组Id
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 字段个数
        /// </summary>
        public int? FieldCount { get; set; }


        /// <summary>
        /// 字段模板组
        /// </summary>
        [PetaPoco.ResultColumn]
        public static Dictionary<int, string> FieldTemplateGroup
        {
            get
            {
                Dictionary<int, string> dic = new Dictionary<int, string>();
                dic.Add(0, "");
                dic.Add(1, "表格");
                return dic;
            }
        }
    }
}