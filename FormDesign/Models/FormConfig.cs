using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{
    /// <summary>
    /// 表单配置信息
    /// </summary>
    public class FormConfig
    {
        public int Id { get; set; }

        /// <summary>
        /// 表单模板Id
        /// </summary>
        public int FormTemplateId { get; set; }

        /// <summary>
        /// 字段模板组Id
        /// </summary>
        public int FieldTemplateGroupId { get; set; }

        /// <summary>
        /// 数据表名称（以逗号分隔）
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表单样式
        /// </summary>
        public string Style { get; set; }
    }
}