using FormDesign.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormDesign
{
    class FormDesignService : BaseService, IFormDesignService
    {
        #region 表单模板
        /// <summary>
        /// 表单模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FormTemplate GetFormTemplate(int id)
        {
            return DB.FirstOrDefault<FormTemplate>("Where Id=@0", id);
        }
        /// <summary>
        /// 表单模板分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FormTemplate> GetFormTemplate(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FormTemplate>(pageIndex, pageSize, sql);
        }
        #endregion

        #region 字段模板

        /// <summary>
        /// 字段组模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FieldTemplateGroup GetFieldTemplateGroup(int id)
        {
            return DB.FirstOrDefault<FieldTemplateGroup>("Where Id=@0", id);
        }

        /// <summary>
        /// 字段组模板分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FieldTemplateGroup> GetFieldTemplateGroup(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FieldTemplateGroup>(pageIndex, pageSize, sql);
        }

        /// <summary>
        /// 字段模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FieldTemplate GetFieldTemplate(int id)
        {
            return DB.FirstOrDefault<FieldTemplate>("Where Id=@0", id);
        }

        /// <summary>
        /// 获取模板组的字段字段模板
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public IList<FieldTemplate> GetFieldTemplateByGroupId(int groupId)
        {
            return DB.Fetch<FieldTemplate>("Where GroupId=@0", groupId);
        }
        /// <summary>
        /// 字段模板分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FieldTemplate> GetFieldTemplate(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FieldTemplate>(pageIndex, pageSize, sql);
        }
        #endregion

        #region 字段配置
        /// <summary>
        /// 字段配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FieldConfig GetFieldConfig(int id)
        {
            return DB.FirstOrDefault<FieldConfig>("Where Id=@0", id);
        }
        /// <summary>
        /// 获取表字段配置集合
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IList<FieldConfig> GetFieldConfigByTableName(string tableName)
        {
            return DB.Fetch<FieldConfig>("Where TableName=@0", tableName);
        }
        /// <summary>
        /// 字段配置分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FieldConfig> GetFieldConfig(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FieldConfig>(pageIndex, pageSize, sql);
        }
        #endregion

        #region 表单配置
        /// <summary>
        /// 表单配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FormConfig GetFormConfig(int id)
        {
            return DB.FirstOrDefault<FormConfig>("Where Id=@0", id);
        }
        /// <summary>
        /// 表单配置分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<FormConfig> GetFormConfig(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            return DB.Page<FormConfig>(pageIndex, pageSize, sql);
        }
        #endregion
    }
}
