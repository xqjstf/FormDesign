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

    }
    public class V_FieldTemplate : FieldTemplate
    {
        /// <summary>
        /// 组名称
        /// </summary>
        public string GroupName { get; set; }
    }
}