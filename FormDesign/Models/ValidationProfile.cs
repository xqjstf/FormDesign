using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{

    /// <summary>
    /// 验证配置
    /// </summary>
    public class ValidationProfile
    {
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 验证代码
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }
    }
}