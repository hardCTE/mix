/*
 * XCoder v6.8.6162.20400
 * 作者：Administrator/XUDB
 * 时间：2016-11-14 11:20:12
 * 版权：hardCTE 2016~2016
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using App.FrameCore;
using Dapper;

namespace App.DAL
{
    /// <summary>
    /// TbIpBlacklist 数据访问层
    /// </summary>
    public partial class TbIpBlacklistDal : TableDalBase<TbIpBlacklist>
    {
        #region 定义

        public TbIpBlacklistDal(IDbConnection dbCon = null) : base(dbCon)
        {
        }

        #endregion

        /// <summary>
        /// 实现抽象基类属性
        /// </summary>
        public override string DataBaseTableName => TbIpBlacklist._.DataBaseTableName;

        #region 查询

        #region 按键及索引 查询

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">自增Id</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual TbIpBlacklist GetByPk(Int64 id, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} WHERE id=@Id";

            var sql = string.Format(format, DataBaseTableName);

            return DbConn.QueryFirst<TbIpBlacklist>(
                sql: sql,
                param: new { Id = id },
                transaction: tran);
        }

        /// <summary>
        /// 根据索引获取实体列表
        /// </summary>
        /// <param name="ip">ip值(支持正则表达式)</param>
        /// <param name="top">获取行数(默认为0，即所有)</param>
        /// <param name="sort">排序方式(不包含关键字Order By)</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<TbIpBlacklist> GetByIdxIp(String ip, int top = 0, string sort = null, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} WHERE ip=@Ip {1} {2}";

            var sortClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(sort))
            {
                sortClause = "ORDER BY " + sort;
            }

            var limitClause = string.Empty;
            if (top > 0)
            {
                limitClause = "LIMIT " + top;
            }

            var sql = string.Format(format, DataBaseTableName, sortClause, limitClause);

            return DbConn.Query<TbIpBlacklist>(
                sql: sql,
                param: new { Ip = ip },
                transaction: tran);
        }

        #endregion

        #endregion


        #region Add

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item">实体</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Add(TbIpBlacklist item, IDbTransaction tran = null)
        {
            const string format = @"INSERT INTO {0}(ip,add_time,end_time,is_enable,descr) 
				VALUES(@Ip,@AddTime,@EndTime,@IsEnable,@Descr);
				SELECT LAST_INSERT_ID();";

            var sql = string.Format(format, DataBaseTableName);

            item.Id = DbConn.ExecuteScalar<Int64>(sql, param: item, transaction: tran);
            item.OriginalId = item.Id;

            return 1;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="items">实体列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Add(IEnumerable<TbIpBlacklist> items, IDbTransaction tran = null)
        {
            var count = 0;
            foreach (var item in items)
            {
                Add(item, tran);
                count++;
            }

            return count;
        }

        #endregion

        #region Update

        /// <summary>
        /// 更新（根据原始主键OriginalXXX更新其它字段信息）
        /// </summary>
        /// <param name="item">实体对象</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(TbIpBlacklist item, IDbTransaction tran = null)
        {
            const string format = @"UPDATE {0} 
					SET ip=@Ip,add_time=@AddTime,end_time=@EndTime,is_enable=@IsEnable,descr=@Descr 
					WHERE id=@OriginalId;";

            var sql = string.Format(format, DataBaseTableName);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        /// <summary>
        /// 更新（根据原始主键OriginalXXX更新包含的字段列表）
        /// </summary>
        /// <param name="item">仅更新的字段、OriginalXXX字段</param>
        /// <param name="nameList">包含的name列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(TbIpBlacklist item, IList<string> nameList, IDbTransaction tran = null)
        {
            if (nameList == null)
            {
                return Update(item, tran);
            }

            var curFieldList = TbIpBlacklist._.AllFields.Where(f => nameList.Contains(f.Name) && !f.IsReadonly);
            if (!curFieldList.Any())
            {
                return 0;
            }

            const string format = "UPDATE {0} SET {1} WHERE {2};";

            var setClause = curFieldList.Aggregate(string.Empty,
                (raw, p) => $"{raw},{p.ColumnName}=@{p.Name}",
                last => last.Trim(','));

            var originalKeys = TbIpBlacklist._.AllFields.Where(p => p.IsPrimaryKey && p.IsReadonly);
            var whereClause = originalKeys.Aggregate(string.Empty,
                (raw, p) => $"{raw} and {p.ColumnName}=@{p.Name}",
                last => last.Trim().Substring(4));

            var sql = string.Format(format, DataBaseTableName, setClause, whereClause);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="items">实体对象集合</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(IEnumerable<TbIpBlacklist> items, IDbTransaction tran = null)
        {
            var count = 0;
            foreach (var item in items)
            {
                Update(item, tran);
                count++;
            }

            return count;
        }

        #endregion

        #region Remove

        #region 按键及索引 删除

        /// <summary>
        /// 根据主键删除
        /// </summary>

        /// <param name="id">自增Id</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int RemoveByPk(Int64 id, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE id=@OriginalId;";

            var sql = string.Format(format, DataBaseTableName);

            return DbConn.Execute(sql, param: new { OriginalId = id }, transaction: tran);
        }


        /// <summary>
        /// 根据主键批量删除
        /// </summary>
        /// <param name="ids">自增Id列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int RemoveByPks(IEnumerable<Int64> ids, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE id=@OriginalId;";

            var sql = string.Format(format, DataBaseTableName);

            return DbConn.Execute(sql, param: ids.Select(p => new { OriginalId = p }), transaction: tran);
        }

        /// <summary>
        /// 根据索引删除
        /// </summary>

        /// <param name="ip">ip值(支持正则表达式)</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int RemoveByIdxIp(String ip, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE ip=@OriginalIp;";

            var sql = string.Format(format, DataBaseTableName);

            return DbConn.Execute(sql, param: new { OriginalIp = ip }, transaction: tran);
        }


        /// <summary>
        /// 根据索引批量删除
        /// </summary>
        /// <param name="ips">ip值(支持正则表达式)列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int RemoveByIdxIps(IEnumerable<String> ips, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE ip=@OriginalIp;";

            var sql = string.Format(format, DataBaseTableName);

            return DbConn.Execute(sql, param: ips.Select(p => new { OriginalIp = p }), transaction: tran);
        }

        #endregion

        #endregion
    }
}
