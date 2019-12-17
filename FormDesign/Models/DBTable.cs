using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{
    /// <summary>
    /// 数据库表
    /// </summary>
    public class DBTable
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public string ColumnsName { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string ColumnsType { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public int? ColumnsLength { get; set; }
    }
}