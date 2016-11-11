using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using App.FrameCore;
using Dapper;

namespace App.DbModel
{
    public partial class TbIpBlackListDalRaw : DbBase
    {
        #region 定义

        public TbIpBlackListDalRaw(IDbConnection dbCon = null) : base(dbCon)
        {
        }

        #endregion

        #region 查询

        // todo:唯一索引（条件查询、是否存在）

        #region 按键及索引 查询

        /// <summary>
        /// 根据主键获取EO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual TbIpBlackListRaw GetByPk(Int64 id, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} WHERE id = @Id";

            var sql = string.Format(format, TbIpBlackListRaw.__.DataBaseTableName);

            return DbConn.QueryFirst<TbIpBlackListRaw>(
                sql: sql,
                param: new {Id = id},
                transaction: tran);
        }

        /// <summary>
        /// 根据索引 idx_ip(ip列)查询列表
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<TbIpBlackListRaw> GetByIp(string ip, IDbTransaction tran = null)
        {
            return GetByIp(ip, 0, null, tran);
        }

        /// <summary>
        /// 根据索引 idx_ip(ip列)查询列表
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="top">获取行数</param>
        /// <param name="sort">排序方式</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<TbIpBlackListRaw> GetByIp(string ip, int top, string sort, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} WHERE ip = @Ip {1} {2}";

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

            var sql = string.Format(format,
                TbIpBlackListRaw.__.DataBaseTableName,
                sortClause, limitClause);

            return DbConn.Query<TbIpBlackListRaw>(
                sql: sql,
                param: new {Ip = ip},
                transaction: tran);
        }

        #endregion

        #region 自定义查询

        /// <summary>
        /// 自定义条件查询
        /// </summary>
        /// <param name="where">自定义条件，where子句（不包含关键字Where）</param>
        /// <param name="param">参数（对象属性自动转为sql中的参数，eg：new {Id=10},则执行sql会转为参数对象 @Id,值为10）</param>
        /// <param name="top">获取行数</param>
        /// <param name="sort">排序方式(不包含关键字Order By)</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<TbIpBlackListRaw> GetTopSort(string where, object param = null,
            int top = 0, string sort = null, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} {1} {2} {3}";

            var whereClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(where))
            {
                whereClause = where.Trim();

                if (!whereClause.StartsWith("where", StringComparison.OrdinalIgnoreCase))
                {
                    whereClause = "WHERE " + whereClause;
                }
            }

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

            var sql = string.Format(format,
                TbIpBlackListRaw.__.DataBaseTableName,
                whereClause, sortClause, limitClause);

            return DbConn.Query<TbIpBlackListRaw>(
                sql: sql,
                param: param,
                transaction: tran);
        }

        #endregion

        #region 分页

        /// <summary>
        /// 分页信息
        /// </summary>
        /// <param name="pageSize">每页条数</param>
        /// <param name="where">过滤条件</param>
        /// <param name="param">参数（对象属性自动转为sql中的参数，eg：new {Id=10},则执行sql会转为参数对象 @Id,值为10）</param>
        /// <returns>
        /// Item1: 总记录数
        /// Item2: 页数
        /// </returns>
        public virtual Tuple<Int64, Int64> GetPageInfo(int pageSize, string where = null, object param = null)
        {
            const string format = @"SELECT COUNT(*) FROM {0} {1}";

            var whereClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(where))
            {
                whereClause = where.Trim();

                if (!whereClause.StartsWith("where", StringComparison.OrdinalIgnoreCase))
                {
                    whereClause = "WHERE " + whereClause;
                }
            }

            var sql = string.Format(format,
                TbIpBlackListRaw.__.DataBaseTableName,
                whereClause);

            var recordCount = DbConn.ExecuteScalar<Int64>(sql, param);

            var pageCount = 1L;
            if (pageSize != 0)
            {
                var lastPageCount = recordCount%pageSize;
                pageCount = recordCount/pageSize + (lastPageCount > 0 ? 1 : 0);
            }

            return new Tuple<long, long>(recordCount, pageCount);
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="pageIndex">页索引（从1开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="where">过滤条件</param>
        /// <param name="param">参数（对象属性自动转为sql中的参数，eg：new {Id=10},则执行sql会转为参数对象 @Id,值为10）</param>
        /// <param name="sort">排序方式(不包含关键字Order By)</param>
        /// <returns></returns>
        public virtual IEnumerable<TbIpBlackListRaw> GetPageList(Int64 pageIndex, int pageSize,
            string where = null, object param = null, string sort = null)
        {
            const string format = "SELECT * FROM {0} {1} {2} {3};";

            var whereClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(where))
            {
                whereClause = where.Trim();

                if (!whereClause.StartsWith("where", StringComparison.OrdinalIgnoreCase))
                {
                    whereClause = "WHERE " + whereClause;
                }
            }

            var sortClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(sort))
            {
                sortClause = "ORDER BY " + sort;
            }

            var limitClause = string.Empty;
            if (pageIndex > 0 && pageSize > 0)
            {
                limitClause = $"LIMIT {(pageSize - 1L)*pageSize},{pageSize}";
            }

            var sql = string.Format(format,
                TbIpBlackListRaw.__.DataBaseTableName,
                whereClause, sortClause, limitClause);

            return DbConn.Query<TbIpBlackListRaw>(
                sql: sql,
                param: param);
        }

        #endregion

        #endregion

        #region Add

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public virtual int Add(TbIpBlackListRaw item, IDbTransaction tran = null)
        {
            const string format =
                @"INSERT INTO {0}(ip,add_time,end_time,is_enable,descr) VALUES(@Ip,@AddTime,@EndTime,@IsEnable,@Descr);SELECT LAST_INSERT_ID();";

            var sql = string.Format(format, TbIpBlackListRaw.__.DataBaseTableName);

            item.Id = DbConn.ExecuteScalar<Int64>(sql, param: item, transaction: tran);
            item.OriginalId = item.Id;

            return 1;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="items"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public virtual int Add(IEnumerable<TbIpBlackListRaw> items, IDbTransaction tran = null)
        {
            // const string format = @"INSERT INTO {0}(ip,add_time,end_time,is_enable,descr) VALUES(@Ip,@AddTime,@EndTime,@IsEnable,@Descr);";
            // var sql = string.Format(format, TbIpBlackListRaw.__.DataBaseTableName);
            // return DbConn.Execute(sql, param: items, transaction: tran);

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
        public virtual int Update(TbIpBlackListRaw item, IDbTransaction tran = null)
        {
            const string format =
                "UPDATE {0} SET ip=@Ip,add_time=@AddTime,end_time=@EndTime,is_enable=@IsEnable,descr=@Descr WHERE id=@OriginalId";

            var sql = string.Format(format, TbIpBlackListRaw.__.DataBaseTableName);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        /// <summary>
        /// 更新（根据原始主键OriginalXXX更新包含的字段列表）
        /// </summary>
        /// <param name="item">仅更新的字段、OriginalXXX字段</param>
        /// <param name="nameList">包含的name列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(TbIpBlackListRaw item, IList<string> nameList, IDbTransaction tran = null)
        {
            if (nameList == null)
            {
                return Update(item, tran);
            }

            var curFieldList = TbIpBlackListRaw._.AllFields.Where(f => nameList.Contains(f.Name) && !f.IsReadonly);
            if (!curFieldList.Any())
            {
                return 0;
            }

            const string format = "UPDATE {0} SET {1} WHERE {2};";

            var setClause = curFieldList.Aggregate(string.Empty,
                (raw, p) => $"{raw},{p.ColumnName}=@{p.Name}",
                last => last.Trim(','));

            var originalKeys = TbIpBlackListRaw._.AllFields.Where(p => p.IsPrimaryKey && p.IsReadonly);
            var whereClause = originalKeys.Aggregate(string.Empty,
                (raw, p) => $"{raw} and {p.ColumnName}=@{p.Name}",
                last => last.Trim().Substring(4));

            var sql = string.Format(format,
                TbIpBlackListRaw.__.DataBaseTableName,
                setClause, whereClause);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="items">实体对象集合</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(IEnumerable<TbIpBlackListRaw> items, IDbTransaction tran = null)
        {
            var count = 0;
            foreach (var item in items)
            {
                Update(item, tran);
                count++;
            }

            return count;
        }

        /// <summary>
        /// 自定义更新
        /// </summary>
        /// <param name="item">实体对象（仅更新的字段、Where字段）</param>
        /// <param name="strSet">set语句（不含set关键字，可以用sql参数，Eg：cloumn_name=@CloumnName）</param>
        /// <param name="strWhere">where语句（不含where关键字，可以用sql参数，Eg：id=@Id）</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(TbIpBlackListRaw item, string strSet, string strWhere, IDbTransaction tran = null)
        {
            const string format = "UPDATE {0} SET {1} {2};";

            if (string.IsNullOrWhiteSpace(strSet))
            {
                return 0;
            }

            var whereClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                whereClause = strWhere.Trim();

                if (!whereClause.StartsWith("where", StringComparison.OrdinalIgnoreCase))
                {
                    whereClause = "WHERE " + whereClause;
                }
            }

            var sql = string.Format(format,
                TbIpBlackListRaw.__.DataBaseTableName,
                strSet, whereClause);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        #endregion

        #region Remove

        /// <summary>
        /// 按主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public virtual int RemoveByPk(Int64 id, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE id=@Id;";

            var sql = string.Format(format, TbIpBlackListRaw.__.DataBaseTableName);

            return DbConn.Execute(sql, param: new {Id = id}, transaction: tran);
        }

        /// <summary>
        /// 按主键批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public virtual int RemoveByPks(IEnumerable<Int64> ids, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE id=@Id;";

            var sql = string.Format(format, TbIpBlackListRaw.__.DataBaseTableName);

            return DbConn.Execute(sql, param: ids.Select(p => new {Id = p}), transaction: tran);
        }

        /// <summary>
        /// 根据索引删除 idx_ip(ip)
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public virtual int RemoveByIp(string ip, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE ip=@Ip;";

            var sql = string.Format(format, TbIpBlackListRaw.__.DataBaseTableName);

            return DbConn.Execute(sql, param: new {Ip = ip}, transaction: tran);
        }

        /// <summary>
        /// 根据索引批量删除 idex_ip(ip)
        /// </summary>
        /// <param name="ips"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public virtual int RemoveByIps(IEnumerable<string> ips, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE ip=@Ip;";

            var sql = string.Format(format, TbIpBlackListRaw.__.DataBaseTableName);

            return DbConn.Execute(sql, param: ips.Select(p => new {Ip = p}), transaction: tran);
        }

        /// <summary>
        /// 自定义条件删除
        /// </summary>
        /// <param name="where">自定义条件，where子句（不包含关键字Where）</param>
        /// <param name="param">参数（对象属性自动转为sql中的参数，eg：new {Id=10},则执行sql会转为参数对象 @Id,值为10）</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Remove(string where, object param = null, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} {1};";

            var whereClause = string.Empty;
            if (!string.IsNullOrWhiteSpace(where))
            {
                whereClause = where.Trim();

                if (!whereClause.StartsWith("where", StringComparison.OrdinalIgnoreCase))
                {
                    whereClause = "WHERE " + whereClause;
                }
            }

            var sql = string.Format(format,
                TbIpBlackListRaw.__.DataBaseTableName,
                whereClause);

            return DbConn.Execute(sql, param: param, transaction: tran);
        }

        #endregion
    }
}
