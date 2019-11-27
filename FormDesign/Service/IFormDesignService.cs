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
        Page<FieldTemplate> GetFieldTemplate(int pageIndex, int pageSize);
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
        /// 字段配置分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Page<FieldConfig> GetFieldConfig(int pageIndex, int pageSize);
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
        Page<FormConfig> GetFormConfig(int pageIndex, int pageSize);
        #endregion
    }
}
