using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{
    /// <summary>
    /// 字段配置信息
    /// </summary>
    public class FieldConfig
    {
        public int Id { get; set; }

        /// <summary>
        ///所属表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public string Field { get; set; }


        /// <summary>
        /// 字段显示名称
        /// </summary>
        public string FieldLable { get; set; }

        /// <summary>
        /// 字段类型（参见EmFieldType枚举）
        /// </summary>
        public int FieldType { get; set; }

        /// <summary>
        /// 字段模板Id
        /// </summary>
        public int? FieldTemplateId { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public int? FieldLength { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool? IsPrimaryKey { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool? IsRequired { get; set; }

        /// <summary>
        /// 正则表达式
        /// </summary>
        public string RegExpression { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int? Seq { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DeafultValue { get; set; }

        /// <summary>
        /// 所属表单Id
        /// </summary>
        public int FormId { get; set; }
    }

    public class V_FieldConfig : FieldConfig
    {
        /// <summary>
        /// 表单名称
        /// </summary>
        public string FormName { get; set; }
    }
}