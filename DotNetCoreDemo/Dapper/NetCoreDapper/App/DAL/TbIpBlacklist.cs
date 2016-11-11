/*
 * XCoder v6.8.6159.30224
 * 作者：Administrator/XUDB
 * 时间：2016-11-11 16:54:38
 * 版权：hardCTE 2016~2016
*/
﻿using System;
using System.Collections.Generic;
using System.Data;
using App.FrameCore;

namespace App.DAL
{
    /// <summary>tb_ip_blacklist</summary>
	/// <remarks></remarks>
    ///[Description("")]
    ///[BindIndex("PRIMARY", true, "id")]
    ///[BindIndex("idx_ip", false, "ip")]
    ///[BindTable("tb_ip_blacklist", Description = "", ConnName = "MyConnName", DbType = DatabaseType.MySql)]
    public partial class TbIpBlacklist : TableModelBase
    {
        #region 属性
		/// <summary>Original自增Id</summary>
		public virtual Int64 OriginalId { get; set; }
		
        /// <summary>自增Id</summary>
		public virtual Int64 Id { get; set; }

        /// <summary>ip值(支持正则表达式)</summary>
		public virtual String Ip { get; set; }

        /// <summary>添加时间</summary>
		public virtual DateTime AddTime { get; set; }

        /// <summary>结束日期</summary>
		public virtual DateTime? EndTime { get; set; }

        /// <summary>是否启用</summary>
		public virtual SByte IsEnable { get; set; }

        /// <summary>描述</summary>
		public virtual String Descr { get; set; }
        #endregion

        #region 实现抽象类方法

		/// <summary>
        /// 数据库表名
        /// </summary>
        public override string DataBaseTableName => _.DataBaseTableName;

        /// <summary>
        /// 获取模型所有字段
        /// </summary>
        /// <returns></returns>
        public override IList<Field> GetAllFields()
        {
            return _.AllFields;
        }

        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引
        /// 派生实体类可重写该索引
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
					case __.OriginalId : return OriginalId;
                    case __.Id : return Id;
                    case __.Ip : return Ip;
                    case __.AddTime : return AddTime;
                    case __.EndTime : return EndTime;
                    case __.IsEnable : return IsEnable;
                    case __.Descr : return Descr;
                    default: return null;
                }
            }
            set
            {
                switch (name)
                {
					case __.OriginalId : OriginalId = Convert.ToInt64(value); break;
                    case __.Id : Id = Convert.ToInt64(value); break;
                    case __.Ip : Ip = Convert.ToString(value); break;
                    case __.AddTime : AddTime = Convert.ToDateTime(value); break;
                    case __.EndTime : EndTime = Convert.ToDateTime(value); break;
                    case __.IsEnable : IsEnable = Convert.ToSByte(value); break;
                    case __.Descr : Descr = Convert.ToString(value); break;
                    default: break;
				}
            }
        }
        #endregion

        #region 字段信息

		/// <summary>取得tb_ip_blacklist字段名称的快捷方式</summary>
        public partial class __
        {
			///<summary>原始主键，自增Id</summary>
            public const String OriginalId = "OriginalId";

            ///<summary>自增Id</summary>
            public const String Id = "Id";

            ///<summary>ip值(支持正则表达式)</summary>
            public const String Ip = "Ip";

            ///<summary>添加时间</summary>
            public const String AddTime = "AddTime";

            ///<summary>结束日期</summary>
            public const String EndTime = "EndTime";

            ///<summary>是否启用</summary>
            public const String IsEnable = "IsEnable";

            ///<summary>描述</summary>
            public const String Descr = "Descr";

        }

        /// <summary>取得tb_ip_blacklist字段信息的快捷方式</summary>
        public partial class _
        {
			/// <summary>
            /// 数据库表名
            /// </summary>
            public const string DataBaseTableName = "tb_ip_blacklist";

            ///<summary>原始主键,自增Id</summary>
            public static readonly Field OriginalId = new Field
            {
                Name = __.OriginalId,
				ColumnName = "id",
                DisplayName = "自增Id",
                Description = "自增Id",
                DataType = DbType.Int64,
                DefaultValue = null,
                IsPrimaryKey = true,
				Identity = true,
                IsReadonly = true,
                IsNullable = false,
                Length = 19,
                Precision = 19,
                Scale = 0
			};

            ///<summary>自增Id</summary>
            public static readonly Field Id = new Field
            {
                Name = __.Id,
				ColumnName = "id",
                DisplayName = "自增Id",
                Description = "自增Id",
                DataType = DbType.Int64,
                DefaultValue = null,
                IsPrimaryKey = true,
				Identity = true,
                IsReadonly = false,
                IsNullable = false,
                Length = 19,
                Precision = 19,
                Scale = 0
			};

            ///<summary>ip值(支持正则表达式)</summary>
            public static readonly Field Ip = new Field
            {
                Name = __.Ip,
				ColumnName = "ip",
                DisplayName = "ip值支持正则表达式",
                Description = "ip值(支持正则表达式)",
                DataType = DbType.String,
                DefaultValue = "",
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = false,
                Length = 200,
                Precision = 0,
                Scale = 0
			};

            ///<summary>添加时间</summary>
            public static readonly Field AddTime = new Field
            {
                Name = __.AddTime,
				ColumnName = "add_time",
                DisplayName = "添加时间",
                Description = "添加时间",
                DataType = DbType.DateTime,
                DefaultValue = null,
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = false,
                Length = 0,
                Precision = 0,
                Scale = 0
			};

            ///<summary>结束日期</summary>
            public static readonly Field EndTime = new Field
            {
                Name = __.EndTime,
				ColumnName = "end_time",
                DisplayName = "结束日期",
                Description = "结束日期",
                DataType = DbType.DateTime,
                DefaultValue = null,
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 0,
                Precision = 0,
                Scale = 0
			};

            ///<summary>是否启用</summary>
            public static readonly Field IsEnable = new Field
            {
                Name = __.IsEnable,
				ColumnName = "is_enable",
                DisplayName = "是否启用",
                Description = "是否启用",
                DataType = DbType.SByte,
                DefaultValue = "0",
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = false,
                Length = 3,
                Precision = 3,
                Scale = 0
			};

            ///<summary>描述</summary>
            public static readonly Field Descr = new Field
            {
                Name = __.Descr,
				ColumnName = "descr",
                DisplayName = "描述",
                Description = "描述",
                DataType = DbType.String,
                DefaultValue = "",
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 800,
                Precision = 0,
                Scale = 0
			};

			///<summary>所有字段列表</summary>
			public static readonly IList<Field> AllFields = new List<Field>
            {
				OriginalId,			
				Id,			
				Ip,			
				AddTime,			
				EndTime,			
				IsEnable,			
				Descr,
            };

        }

        #endregion
    }
}