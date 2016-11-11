/*
 * XCoder v6.8.6159.30224
 * 作者：Administrator/XUDB
 * 时间：2016-11-11 16:47:33
 * 版权：hardCTE 2016~2016
*/
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using App.FrameCore;
using Dapper;

namespace App.DAL
{
	/// <summary>
    /// TbSchoolInfo 数据访问层
    /// </summary>
    public partial class TbSchoolInfoDal : DbBase
    {
		#region 定义

        public TbSchoolInfoDal(IDbConnection dbCon = null) : base(dbCon)
        {
		}

        #endregion

		#region 查询

        #region 按键及索引 查询

		/// <summary>
        /// 根据主键获取实体
        /// </summary>
		/// <param name="keyId">班级（联合主键1，int、非空）</param>
		/// <param name="keyStr">学校（联合主键2，字符可空，最大40）</param>
		/// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual TbSchoolInfo GetByPk(Int32 keyId,String keyStr, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} WHERE key_id=@KeyId and key_str=@KeyStr";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.QueryFirst<TbSchoolInfo>(
                sql: sql,
                param: new {KeyId = keyId , KeyStr = keyStr},
                transaction: tran);
        }

		/// <summary>
        /// 根据唯一索引获取实体
        /// </summary>
		/// <param name="keyId">班级（联合主键1，int、非空）</param>
		/// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual TbSchoolInfo GetByUkIdexu(Int32 keyId, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} WHERE key_id=@KeyId";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.QueryFirst<TbSchoolInfo>(
                sql: sql,
                param: new {KeyId = keyId},
                transaction: tran);
        }

		/// <summary>
        /// 根据索引获取实体列表
        /// </summary>
		/// <param name="idxCode">编码（索引1）</param>
		/// <param name="idxNum">数字（序号索引2）</param>
		/// <param name="top">获取行数(默认为0，即所有)</param>
        /// <param name="sort">排序方式(不包含关键字Order By)</param>
		/// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<TbSchoolInfo> GetByIdxIdxMul(String idxCode,Int64 idxNum, int top = 0, string sort = null, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} WHERE idx_code=@IdxCode and idx_num=@IdxNum {1} {2}";

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
				TbSchoolInfo._.DataBaseTableName,
				sortClause, limitClause);

            return DbConn.Query<TbSchoolInfo>(
                sql: sql,
                param: new {IdxCode = idxCode , IdxNum = idxNum},
                transaction: tran);
        }

		/// <summary>
        /// 根据索引获取实体列表
        /// </summary>
		/// <param name="refCategory">引用的分类Id</param>
		/// <param name="top">获取行数(默认为0，即所有)</param>
        /// <param name="sort">排序方式(不包含关键字Order By)</param>
		/// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<TbSchoolInfo> GetByIdxFkCategoryId(Int64 refCategory, int top = 0, string sort = null, IDbTransaction tran = null)
        {
            const string format = "SELECT * FROM {0} WHERE ref_category=@RefCategory {1} {2}";

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
				TbSchoolInfo._.DataBaseTableName,
				sortClause, limitClause);

            return DbConn.Query<TbSchoolInfo>(
                sql: sql,
                param: new {RefCategory = refCategory},
                transaction: tran);
        }

        #endregion

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
        public virtual IEnumerable<TbSchoolInfo> GetTopSort(string where, object param = null,
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
                TbSchoolInfo._.DataBaseTableName,
                whereClause, sortClause, limitClause);

            return DbConn.Query<TbSchoolInfo>(
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
                TbSchoolInfo._.DataBaseTableName,
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
        public virtual IEnumerable<TbSchoolInfo> GetPageList(Int64 pageIndex, int pageSize,
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
                TbSchoolInfo._.DataBaseTableName,
                whereClause, sortClause, limitClause);

            return DbConn.Query<TbSchoolInfo>(
                sql: sql,
                param: param);
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
        public virtual int Add(TbSchoolInfo item, IDbTransaction tran = null)
        {
            const string format = @"INSERT INTO {0}(key_id,key_str,idx_code,idx_num,ref_category,txt_char,txt_text,bool_enum,ext_enum,num_tinyint,num_decimal,dt_date,dt_datetime,dt_timestamp) 
				VALUES(@KeyId,@KeyStr,@IdxCode,@IdxNum,@RefCategory,@TxtChar,@TxtText,@BoolEnum,@ExtEnum,@NumTinyint,@NumDecimal,@DtDate,@DtDatetime,@DtTimestamp);
				";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

			DbConn.ExecuteScalar(sql, param: item, transaction: tran);
			item.OriginalKeyId = item.KeyId;
			item.OriginalKeyStr = item.KeyStr;

            return 1;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="items">实体列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Add(IEnumerable<TbSchoolInfo> items, IDbTransaction tran = null)
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
        public virtual int Update(TbSchoolInfo item, IDbTransaction tran = null)
        {
            const string format = @"UPDATE {0} 
					SET key_id=@KeyId,key_str=@KeyStr,idx_code=@IdxCode,idx_num=@IdxNum,ref_category=@RefCategory,txt_char=@TxtChar,txt_text=@TxtText,bool_enum=@BoolEnum,ext_enum=@ExtEnum,num_tinyint=@NumTinyint,num_decimal=@NumDecimal,dt_date=@DtDate,dt_datetime=@DtDatetime,dt_timestamp=@DtTimestamp 
					WHERE key_id=@OriginalKeyId AND key_str=@OriginalKeyStr;";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        /// <summary>
        /// 更新（根据原始主键OriginalXXX更新包含的字段列表）
        /// </summary>
        /// <param name="item">仅更新的字段、OriginalXXX字段</param>
        /// <param name="nameList">包含的name列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(TbSchoolInfo item, IList<string> nameList, IDbTransaction tran = null)
        {
            if (nameList == null)
            {
                return Update(item, tran);
            }

            var curFieldList = TbSchoolInfo._.AllFields.Where(f => nameList.Contains(f.Name) && !f.IsReadonly);
            if (!curFieldList.Any())
            {
                return 0;
            }

            const string format = "UPDATE {0} SET {1} WHERE {2};";

            var setClause = curFieldList.Aggregate(string.Empty,
                (raw, p) => $"{raw},{p.ColumnName}=@{p.Name}",
                last => last.Trim(','));

            var originalKeys = TbSchoolInfo._.AllFields.Where(p => p.IsPrimaryKey && p.IsReadonly);
            var whereClause = originalKeys.Aggregate(string.Empty,
                (raw, p) => $"{raw} and {p.ColumnName}=@{p.Name}",
                last => last.Trim().Substring(4));

            var sql = string.Format(format,
                TbSchoolInfo._.DataBaseTableName,
                setClause, whereClause);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="items">实体对象集合</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int Update(IEnumerable<TbSchoolInfo> items, IDbTransaction tran = null)
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
        public virtual int Update(TbSchoolInfo item, string strSet, string strWhere, IDbTransaction tran = null)
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
                TbSchoolInfo._.DataBaseTableName,
                strSet, whereClause);

            return DbConn.Execute(sql, param: item, transaction: tran);
        }

        #endregion

		#region Remove

		﻿	#region 按键及索引 删除

		/// <summary>
        /// 根据主键删除
        /// </summary>
		
		/// <param name="keyId">班级（联合主键1，int、非空）</param>	
		/// <param name="keyStr">学校（联合主键2，字符可空，最大40）</param>
		/// <param name="tran">事务</param>
        /// <returns></returns>
		public virtual int RemoveByPk(Int32 keyId, String keyStr, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE key_id=@OriginalKeyId AND key_str=@OriginalKeyStr;";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.Execute(sql, param: new {OriginalKeyId = keyId, OriginalKeyStr = keyStr}, transaction: tran);
        }
	
	
		/// <summary>
        /// 根据索引删除
        /// </summary>
		
		/// <param name="keyId">班级（联合主键1，int、非空）</param>
		/// <param name="tran">事务</param>
        /// <returns></returns>
		public virtual int RemoveByIdxIdexu(Int32 keyId, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE key_id=@OriginalKeyId;";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.Execute(sql, param: new {OriginalKeyId = keyId}, transaction: tran);
        }
	
	
		/// <summary>
        /// 根据索引批量删除
        /// </summary>
        /// <param name="keyIds">班级（联合主键1，int、非空）列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int RemoveByIdxIdexus(IEnumerable<Int32> keyIds, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE key_id=@OriginalKeyId;";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.Execute(sql, param: keyIds.Select(p => new {OriginalKeyId = p}), transaction: tran);
        }
	
		/// <summary>
        /// 根据索引删除
        /// </summary>
		
		/// <param name="idxCode">编码（索引1）</param>	
		/// <param name="idxNum">数字（序号索引2）</param>
		/// <param name="tran">事务</param>
        /// <returns></returns>
		public virtual int RemoveByIdxIdxMul(String idxCode, Int64 idxNum, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE idx_code=@OriginalIdxCode AND idx_num=@OriginalIdxNum;";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.Execute(sql, param: new {OriginalIdxCode = idxCode, OriginalIdxNum = idxNum}, transaction: tran);
        }
	
	
		/// <summary>
        /// 根据索引删除
        /// </summary>
		
		/// <param name="refCategory">引用的分类Id</param>
		/// <param name="tran">事务</param>
        /// <returns></returns>
		public virtual int RemoveByIdxFkCategoryId(Int64 refCategory, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE ref_category=@OriginalRefCategory;";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.Execute(sql, param: new {OriginalRefCategory = refCategory}, transaction: tran);
        }
	
	
		/// <summary>
        /// 根据索引批量删除
        /// </summary>
        /// <param name="refCategorys">引用的分类Id列表</param>
        /// <param name="tran">事务</param>
        /// <returns></returns>
        public virtual int RemoveByIdxFkCategoryIds(IEnumerable<Int64> refCategorys, IDbTransaction tran = null)
        {
            const string format = @"DELETE FROM {0} WHERE ref_category=@OriginalRefCategory;";

            var sql = string.Format(format, TbSchoolInfo._.DataBaseTableName);

            return DbConn.Execute(sql, param: refCategorys.Select(p => new {OriginalRefCategory = p}), transaction: tran);
        }
	
		#endregion

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
                TbSchoolInfo._.DataBaseTableName,
                whereClause);

            return DbConn.Execute(sql, param: param, transaction: tran);
        }

        #endregion
    }
}
