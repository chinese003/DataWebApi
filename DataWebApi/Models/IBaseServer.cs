using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataWebApi.Models
{
    public interface IBaseServer<T> where T : class
    {
        /// <summary>
        /// 查询数据不需要任何条件
        /// </summary>
        /// <returns></returns>
        Task<ActionResult<List<T>>> GetListAsync();

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<ActionResult<string>> AddAsync(T parm);


        /// <summary>
        /// 删除一条或者多条数据
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<ActionResult<string>> DeleteAsync(string parm);

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="pram"></param>
        /// <returns></returns>
        Task<ActionResult<string>> UpdateAsync(T pram);

        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="where">Expression<Func<T, bool>></param>
        /// <returns></returns>
        Task<ActionResult<T>> GetModelAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<ActionResult<List<T>>> AddList(List<T> parm);
    }
}
