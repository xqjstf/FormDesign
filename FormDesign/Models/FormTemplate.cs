using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{
    /// <summary>
    /// 表单模板
    /// </summary>
    class FormTemplate
    {
        public int Id { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; } 
    }
}