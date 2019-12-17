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
        /// 表单模板
        /// </summary> 
        /// <returns></returns>
        public IList<FormTemplate> GetFormTemplate()
        {
            return DB.Fetch<FormTemplate>("SELECT *  FROM  FormTemplate ORDER BY  Name");
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
        /// 字段组模板
        /// </summary> 
        /// <returns></returns>
        public IList<FieldTemplateGroup> GetFieldTemplateGroup()
        {
            return DB.Fetch<FieldTemplateGroup>("SELECT *  FROM  FieldTemplateGroup ORDER BY  Name");
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
        public Page<V_FieldTemplate> GetFieldTemplate(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            sql.Append(@"SELECT  a.* ,
                            (SELECT    a1.Name
                              FROM      dbo.FieldTemplateGroup a1
                              WHERE     a1.id = a.GroupId
                            ) GroupName
                    FROM    FieldTemplate a");
            sql.OrderBy("a.Id");
            return DB.Page<V_FieldTemplate>(pageIndex, pageSize, sql);
        }
        #endregion

        #region 字段配置
        public Sql GetFieldConfigSql()
        {
            Sql sql = new Sql();
            sql.Append(@"SELECT  a.*,
                         b.Name FormName
                                        FROM    dbo.FieldConfig a
                                       LEFT JOIN dbo.FormConfig b ON a.FormId = b.Id");
            return sql;
        }
        /// <summary>
        /// 字段配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FieldConfig GetFieldConfig(int id)
        {
            Sql sql = GetFieldConfigSql();
            sql.Where("Id=@0", id);
            return DB.FirstOrDefault<V_FieldConfig>(sql);
        }
        /// <summary>
        /// 获取表字段配置集合
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IList<FieldConfig> GetFieldConfigByTableName(string tableName)
        {
            Sql sql = GetFieldConfigSql();
            sql.Where("TableName=@0", tableName);
            return DB.Fetch<FieldConfig>(sql);
        }
        /// <summary>
        /// 获取在字段配置中存在的表名
        /// </summary>
        /// <returns></returns>
        public IList<string> GetFieldConfigGroupTableName()
        {
            return DB.Fetch<string>("SELECT TableName  FROM  FieldConfig group BY  TableName ORDER BY TableName");
        }
        /// <summary>
        /// 字段配置分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Page<V_FieldConfig> GetFieldConfig(int pageIndex, int pageSize)
        {
            Sql sql = GetFieldConfigSql();
            sql.Append(@"ORDER BY a.TableName, a.Seq ,a.Field");
            return DB.Page<V_FieldConfig>(pageIndex, pageSize, sql);
        }
        /// <summary>
        /// 根据表名称获取表字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public IList<DBTable> GetFieldByTableName(string tableName)
        {
            return DB.Fetch<DBTable>(@"SELECT   c.name AS ColumnsName ,
                                                t.name AS ColumnsType ,
                                                c.length AS ColumnsLength
                                        FROM    SysObjects AS o ,
                                                SysColumns AS c ,
                                                SysTypes AS t
                                        WHERE   o.type IN ( 'u', 'v' )
                                                AND o.name = @0
                                                AND o.id = c.id
                                                AND c.xtype = t.xtype
                                        ORDER BY c.name ", tableName);
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
        public Page<V_FormConfig> GetFormConfig(int pageIndex, int pageSize)
        {
            Sql sql = new Sql();
            sql.Append(@"SELECT  a.* ,
                                (SELECT    a1.Name
                                  FROM      dbo.FormTemplate a1
                                  WHERE     a1.id = a.FormTemplateId
                                ) FormTemplateName,
                                (SELECT    a1.Name
                                  FROM      dbo.FieldTemplateGroup a1
                                  WHERE     a1.id = a.FieldTemplateGroupId
                                ) FieldTemplateGroupName
                        FROM    FormConfig a ");
            sql.OrderBy("a.Id");
            return DB.Page<V_FormConfig>(pageIndex, pageSize, sql);
        }
        /// <summary>
        /// 获取数据库中的表和试图
        /// </summary>
        /// <returns></returns>
        public IList<DBTable> GetDBTableAndView()
        {
            return DB.Fetch<DBTable>("SELECT name FROM  SysObjects WHERE type  IN ( 'u', 'v' ) ORDER BY name");
        }

        /// <summary>
        /// 获取表单字段克隆表名称
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public IList<string> GetCopyFormFieldTable(int formId)
        {
            return DB.Fetch<string>(@"SELECT   DISTINCT  CAST(a.FormId AS VARCHAR(10)) + '_' + a.TableName
                                  FROM      dbo.FieldConfig a
                                  WHERE     a.TableName IN (
                                            SELECT  '' + REPLACE(a1.TableName, ',', '''') + ''
                                            FROM    FormConfig a1
                                            WHERE   a1.Id = @0 )", formId);
        }

        /// <summary>
        /// 表单字段克隆
        /// </summary>
        /// <param name="tableName">要克隆的表名</param>
        /// <param name="formId">表单Id</param>
        public void CopyFormField(string tableName, int formId)
        {
            DB.Execute(@"               
               INSERT   INTO dbo.FieldConfig
                        ( TableName ,
                          Field ,
                          FieldLable ,
                          FieldType ,
                          FieldTemplateId ,
                          FieldLength ,
                          IsPrimaryKey ,
                          IsRequired ,
                          RegExpression ,
                          IsEnabled ,
                          Seq ,
                          DeafultValue ,
                          FormId
                        )
                        SELECT  TableName ,
                                Field ,
                                FieldLable ,
                                FieldType ,
                                FieldTemplateId ,
                                FieldLength ,
                                IsPrimaryKey ,
                                IsRequired ,
                                RegExpression ,
                                IsEnabled ,
                                Seq ,
                                DeafultValue ,
                                @1
                        FROM    FieldConfig
                        WHERE    CAST(a.FormId AS VARCHAR(10)) + '_' + a.TableName=@0", tableName, formId);
        }
        /// <summary>
        /// 获取表单表名称
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public string GetFormTableName(int formId)
        {
            return DB.FirstOrDefault<string>("SELECT TableName FROM dbo.FormConfig WHERE Id=0", formId);
        }
        #endregion
    }
}
