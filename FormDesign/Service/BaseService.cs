using FormDesign.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormDesign
{
    public class BaseService : IBaseService
    {
        protected static Database DB
        {
            get
            {
                return new Database("DeafuleConn");
            }
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Save<T>(T model)
        {
            DB.Save(model);
        }


        /// <summary>
        /// 数据添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>返回主键值</returns>
        public object Insert<T>(T model)
        {
            return DB.Insert(model);
        }


        /// <summary>
        /// 数据修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>返回修改条数</returns>
        public int Update<T>(T model)
        {
            return DB.Update(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="pocoOrPrimaryKey">实体或主键值</param>
        /// <returns></returns>
        public int Delete<T>(object pocoOrPrimaryKey)
        {
            return DB.Delete<T>(pocoOrPrimaryKey);
        } 
    }
}
