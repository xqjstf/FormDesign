using FormDesign.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormDesign
{
    public interface IBaseService
    {
        /// <summary>
        /// 数据添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>返回主键值</returns>
        object Insert<T>(T model);

        /// <summary>
        /// 数据修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns>返回修改条数</returns>
        int Update<T>(T model);
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        void Save<T>(T model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="pocoOrPrimaryKey">实体或主键值</param>
        /// <returns></returns>
        int Delete<T>(object pocoOrPrimaryKey);
    }
}
