using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{
    /// <summary>
    /// 字段模板
    /// </summary>
    class FieldTemplate
    {
        public int Id { get; set; }

        /// <summary>
        /// 所属模板组Id
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 字段个数
        /// </summary>
        public int FieldCount { get; set; } 
    }
}