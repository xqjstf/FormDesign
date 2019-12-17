using FormDesign.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormDesign
{
    interface IFormDesignService : IBaseService
    {

        #region 表单模板
        /// <summary>
        /// 表单模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FormTemplate GetFormTemplate(int id);

        /// <summary>
        /// 表单模板
        /// </summary> 
        /// <returns></returns>
        IList<FormTemplate> GetFormTemplate();

        /// <summary>
        /// 表单模板分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Page<FormTemplate> GetFormTemplate(int pageIndex, int pageSize);
        #endregion

        #region 字段模板

        /// <summary>
        /// 字段组模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FieldTemplateGroup GetFieldTemplateGroup(int id);

        /// <summary>
        /// 字段组模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<FieldTemplateGroup> GetFieldTemplateGroup();
        /// <summary>
        /// 字段组模板分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Page<FieldTemplateGroup> GetFieldTemplateGroup(int pageIndex, int pageSize);
        /// <summary>
        /// 字段模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FieldTemplate GetFieldTemplate(int id);

        /// <summary>
        /// 获取模板组的字段字段模板
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IList<FieldTemplate> GetFieldTemplateByGroupId(int groupId);
        /// <summary>
        /// 字段模板分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Page<V_FieldTemplate> GetFieldTemplate(int pageIndex, int pageSize);

        #endregion

        #region 字段配置
        /// <summary>
        /// 字段配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FieldConfig GetFieldConfig(int id);
        /// <summary>
        /// 获取表字段配置集合
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        IList<FieldConfig> GetFieldConfigByTableName(string tableName);

        /// <summary>
        /// 获取在字段配置中存在的表名
        /// </summary>
        /// <returns></returns>
        IList<string> GetFieldConfigGroupTableName();

        /// <summary>
        /// 字段配置分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Page<V_FieldConfig> GetFieldConfig(int pageIndex, int pageSize);

        /// <summary>
        /// 根据表名称获取表字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        IList<DBTable> GetFieldByTableName(string tableName); 
        #endregion

        #region 表单配置
        /// <summary>
        /// 表单配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FormConfig GetFormConfig(int id);
        /// <summary>
        /// 表单配置分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Page<V_FormConfig> GetFormConfig(int pageIndex, int pageSize);

        /// <summary>
        /// 获取数据库中的表和试图
        /// </summary>
        /// <returns></returns>
        IList<DBTable> GetDBTableAndView();

        /// <summary>
        /// 获取表单字段克隆表名称
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        IList<string> GetCopyFormFieldTable(int formId);

        /// <summary>
        /// 表单字段克隆
        /// </summary>
        /// <param name="tableName">要克隆的表名</param>
        /// <param name="formId">表单Id</param>
        void CopyFormField(string tableName, int formId);

        /// <summary>
        /// 获取表单表名称
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        string GetFormTableName(int formId);
        #endregion
    }
}
