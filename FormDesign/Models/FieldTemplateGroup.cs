using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{
    /// <summary>
    ///字段模板组
    /// </summary>
    public class FieldTemplateGroup
    {

        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}