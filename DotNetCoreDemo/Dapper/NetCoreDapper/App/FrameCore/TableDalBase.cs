using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace App.FrameCore
{
    /// <summary>
    /// Table Dal Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TableDalBase<T> : DbBase where T : TableModelBase
    {
        protected TableDalBase(IDbConnection dbCon = null) : base(dbCon)
        {
        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        public virtual string DataBaseTableName { get; }

        #region 自定义查询

        /// <summary>
        /// 自定义条件查询
        /// </summary>
        /// <param name="where">自定义条件，where子句（不包含关键字Where）</param>
        /// <param name="param">参数（对象属性自动转为sql中的参数，eg：new {Id=10},则执行sql会转为参数对象 @Id,值为10）</param>
        /// <param name="top">获取行数(默认为0，即所有)</param>
        /// <param name="sort">排序方式(不包含关键字Order By)</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetTopSort(string where, object param = null,
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
                DataBaseTableName,
                whereClause, sortClause, limitClause);

            return DbConn.Query<T>(
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

            var sql = string.Format(format, DataBaseTableName, whereClause);

            var recordCount = DbConn.ExecuteScalar<Int64>(sql, param);

            var pageCount = 1L;
            if (pageSize != 0)
            {
                var lastPageCount = recordCount % pageSize;
                pageCount = recordCount / pageSize + (lastPageCount > 0 ? 1 : 0);
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
        public virtual IEnumerable<T> GetPageList(Int64 pageIndex, int pageSize,
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
                limitClause = $"LIMIT {(pageSize - 1L) * pageSize},{pageSize}";
            }

            var sql = string.Format(format, DataBaseTableName,
                whereClause, sortClause, limitClause);

            return DbConn.Query<T>(
                sql: sql,
                param: param);
        }

        #endregion

        #region 自定义更新

        /// <summary>
        /// 自定义更新
        /// </summary>
        /// <param name="item">实体对象（仅更新的字段、Where字段）</param>
        /// <param name="strSet">set语句（不含set关键字，可以用sql参数，Eg：cloumn_name=@CloumnName）</param>
        /// <param name="strWhere">where语句（不含where关键字，可以用sql参数，Eg：id=@Id）</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(T item, string strSet, string strWhere, IDbTransaction tran = null)
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

            var sql = string.Format(format, DataBaseTableName, strSet, whereClause);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        #endregion

        #region 自定义删除

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

            var sql = string.Format(format, DataBaseTableName, whereClause);

            return DbConn.Execute(sql, param: param, transaction: tran);
        }

        #endregion
    }


}
