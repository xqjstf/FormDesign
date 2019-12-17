using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormDesign.Models
{
    /// <summary>
    /// 字段类型
    /// </summary>
    public enum EmFieldType
    {
        [Display(Name = "文本框")]
        Text = 0,
        [Display(Name = "单选框")]
        Radio = 1,
        [Display(Name = "复选框")]
        CheckBox = 2,
        [Display(Name = "多行文本")]
        TextArea = 3,
        [Display(Name = "隐藏域")]
        Hidden = 4,
        [Display(Name = "密码框")]
        Password = 5,
        [Display(Name = "lable")]
        Lable = 6,
        [Display(Name = "下拉框")]
        Select = 7,
        [Display(Name = "提交按钮")]
        SubmitButton = 8,
        [Display(Name = "常规按钮")]
        NormalButton = 9,
    }
}