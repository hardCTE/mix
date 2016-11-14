/*
 * XCoder v6.8.6162.20400
 * 作者：Administrator/XUDB
 * 时间：2016-11-14 11:20:14
 * 版权：hardCTE 2016~2016
*/
﻿using System;
using System.Collections.Generic;
using System.Data;
using App.FrameCore;

namespace App.DAL
{
    /// <summary>学校信息表包含各种常用字段</summary>
	/// <remarks>学校信息表（包含各种常用字段）</remarks>
    /// [Description("学校信息表（包含各种常用字段）")]
    /// [BindIndex("PRIMARY", true, "key_id,key_str")]
    /// [BindIndex("idexu_", true, "key_id")]
    /// [BindIndex("idx_mul", false, "idx_code,idx_num")]
    /// [BindIndex("fk_categoryId", false, "ref_category")]
    /// [BindTable("tb_school_info", Description = "学校信息表（包含各种常用字段）", ConnName = "MyConnName", DbType = DatabaseType.MySql)]
    public partial class TbSchoolInfo : TableModelBase
    {
        #region 属性
		/// <summary>Original班级（联合主键1，int、非空）</summary>
		public virtual Int32 OriginalKeyId { get; set; }
		
        /// <summary>班级（联合主键1，int、非空）</summary>
		public virtual Int32 KeyId { get; set; }

		/// <summary>Original学校（联合主键2，字符可空，最大40）</summary>
		public virtual String OriginalKeyStr { get; set; }
		
        /// <summary>学校（联合主键2，字符可空，最大40）</summary>
		public virtual String KeyStr { get; set; }

        /// <summary>编码（索引1）</summary>
		public virtual String IdxCode { get; set; }

        /// <summary>数字（序号索引2）</summary>
		public virtual Int64 IdxNum { get; set; }

        /// <summary>引用的分类Id</summary>
		public virtual Int64 RefCategory { get; set; }

        /// <summary>标示（字符char200)</summary>
		public virtual String TxtChar { get; set; }

        /// <summary>名称（text8000）</summary>
		public virtual String TxtText { get; set; }

        /// <summary>是否启用（bool替代值enumyn）</summary>
		public virtual Boolean BoolEnum { get; set; }

        /// <summary>扩展枚举（可多重选择1,2,3）</summary>
		public virtual String ExtEnum { get; set; }

        /// <summary>类型（tinyint2）</summary>
		public virtual SByte? NumTinyint { get; set; }

        /// <summary>价格（decimal10,2）</summary>
		public virtual Decimal? NumDecimal { get; set; }

        /// <summary>注册日期（date）</summary>
		public virtual DateTime? DtDate { get; set; }

        /// <summary>修改时间（datetime）</summary>
		public virtual DateTime? DtDatetime { get; set; }

        /// <summary>时间戳</summary>
		public virtual DateTime? DtTimestamp { get; set; }
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
					case __.OriginalKeyId : return OriginalKeyId;
                    case __.KeyId : return KeyId;
					case __.OriginalKeyStr : return OriginalKeyStr;
                    case __.KeyStr : return KeyStr;
                    case __.IdxCode : return IdxCode;
                    case __.IdxNum : return IdxNum;
                    case __.RefCategory : return RefCategory;
                    case __.TxtChar : return TxtChar;
                    case __.TxtText : return TxtText;
                    case __.BoolEnum : return BoolEnum;
                    case __.ExtEnum : return ExtEnum;
                    case __.NumTinyint : return NumTinyint;
                    case __.NumDecimal : return NumDecimal;
                    case __.DtDate : return DtDate;
                    case __.DtDatetime : return DtDatetime;
                    case __.DtTimestamp : return DtTimestamp;
                    default: return null;
                }
            }
            set
            {
                switch (name)
                {
					case __.OriginalKeyId : OriginalKeyId = Convert.ToInt32(value); break;
                    case __.KeyId : KeyId = Convert.ToInt32(value); break;
					case __.OriginalKeyStr : OriginalKeyStr = Convert.ToString(value); break;
                    case __.KeyStr : KeyStr = Convert.ToString(value); break;
                    case __.IdxCode : IdxCode = Convert.ToString(value); break;
                    case __.IdxNum : IdxNum = Convert.ToInt64(value); break;
                    case __.RefCategory : RefCategory = Convert.ToInt64(value); break;
                    case __.TxtChar : TxtChar = Convert.ToString(value); break;
                    case __.TxtText : TxtText = Convert.ToString(value); break;
                    case __.BoolEnum : BoolEnum = Convert.ToBoolean(value); break;
                    case __.ExtEnum : ExtEnum = Convert.ToString(value); break;
                    case __.NumTinyint : NumTinyint = Convert.ToSByte(value); break;
                    case __.NumDecimal : NumDecimal = Convert.ToDecimal(value); break;
                    case __.DtDate : DtDate = Convert.ToDateTime(value); break;
                    case __.DtDatetime : DtDatetime = Convert.ToDateTime(value); break;
                    case __.DtTimestamp : DtTimestamp = Convert.ToDateTime(value); break;
                    default: break;
				}
            }
        }
        #endregion

        #region 字段信息

		/// <summary>取得学校信息表包含各种常用字段字段名称的快捷方式</summary>
        public partial class __
        {
			///<summary>原始主键，班级（联合主键1，int、非空）</summary>
            public const String OriginalKeyId = "OriginalKeyId";

            ///<summary>班级（联合主键1，int、非空）</summary>
            public const String KeyId = "KeyId";

			///<summary>原始主键，学校（联合主键2，字符可空，最大40）</summary>
            public const String OriginalKeyStr = "OriginalKeyStr";

            ///<summary>学校（联合主键2，字符可空，最大40）</summary>
            public const String KeyStr = "KeyStr";

            ///<summary>编码（索引1）</summary>
            public const String IdxCode = "IdxCode";

            ///<summary>数字（序号索引2）</summary>
            public const String IdxNum = "IdxNum";

            ///<summary>引用的分类Id</summary>
            public const String RefCategory = "RefCategory";

            ///<summary>标示（字符char200)</summary>
            public const String TxtChar = "TxtChar";

            ///<summary>名称（text8000）</summary>
            public const String TxtText = "TxtText";

            ///<summary>是否启用（bool替代值enumyn）</summary>
            public const String BoolEnum = "BoolEnum";

            ///<summary>扩展枚举（可多重选择1,2,3）</summary>
            public const String ExtEnum = "ExtEnum";

            ///<summary>类型（tinyint2）</summary>
            public const String NumTinyint = "NumTinyint";

            ///<summary>价格（decimal10,2）</summary>
            public const String NumDecimal = "NumDecimal";

            ///<summary>注册日期（date）</summary>
            public const String DtDate = "DtDate";

            ///<summary>修改时间（datetime）</summary>
            public const String DtDatetime = "DtDatetime";

            ///<summary>时间戳</summary>
            public const String DtTimestamp = "DtTimestamp";

        }

        /// <summary>取得学校信息表包含各种常用字段字段信息的快捷方式</summary>
        public partial class _
        {
			/// <summary>
            /// 数据库表名
            /// </summary>
            public const string DataBaseTableName = "tb_school_info";

            ///<summary>原始主键,班级（联合主键1，int、非空）</summary>
            public static readonly Field OriginalKeyId = new Field
            {
                Name = __.OriginalKeyId,
				ColumnName = "key_id",
                DisplayName = "班级联合主键1，int、非空",
                Description = "班级（联合主键1，int、非空）",
                DataType = DbType.Int32,
                DefaultValue = null,
                IsPrimaryKey = true,
				Identity = false,
                IsReadonly = true,
                IsNullable = false,
                Length = 10,
                Precision = 10,
                Scale = 0
			};

            ///<summary>班级（联合主键1，int、非空）</summary>
            public static readonly Field KeyId = new Field
            {
                Name = __.KeyId,
				ColumnName = "key_id",
                DisplayName = "班级联合主键1，int、非空",
                Description = "班级（联合主键1，int、非空）",
                DataType = DbType.Int32,
                DefaultValue = null,
                IsPrimaryKey = true,
				Identity = false,
                IsReadonly = false,
                IsNullable = false,
                Length = 10,
                Precision = 10,
                Scale = 0
			};

            ///<summary>原始主键,学校（联合主键2，字符可空，最大40）</summary>
            public static readonly Field OriginalKeyStr = new Field
            {
                Name = __.OriginalKeyStr,
				ColumnName = "key_str",
                DisplayName = "学校联合主键2，字符可空，最大40",
                Description = "学校（联合主键2，字符可空，最大40）",
                DataType = DbType.String,
                DefaultValue = "",
                IsPrimaryKey = true,
				Identity = false,
                IsReadonly = true,
                IsNullable = false,
                Length = 40,
                Precision = 0,
                Scale = 0
			};

            ///<summary>学校（联合主键2，字符可空，最大40）</summary>
            public static readonly Field KeyStr = new Field
            {
                Name = __.KeyStr,
				ColumnName = "key_str",
                DisplayName = "学校联合主键2，字符可空，最大40",
                Description = "学校（联合主键2，字符可空，最大40）",
                DataType = DbType.String,
                DefaultValue = "",
                IsPrimaryKey = true,
				Identity = false,
                IsReadonly = false,
                IsNullable = false,
                Length = 40,
                Precision = 0,
                Scale = 0
			};

            ///<summary>编码（索引1）</summary>
            public static readonly Field IdxCode = new Field
            {
                Name = __.IdxCode,
				ColumnName = "idx_code",
                DisplayName = "编码索引1",
                Description = "编码（索引1）",
                DataType = DbType.String,
                DefaultValue = "",
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 50,
                Precision = 0,
                Scale = 0
			};

            ///<summary>数字（序号索引2）</summary>
            public static readonly Field IdxNum = new Field
            {
                Name = __.IdxNum,
				ColumnName = "idx_num",
                DisplayName = "数字序号索引2",
                Description = "数字（序号索引2）",
                DataType = DbType.Int64,
                DefaultValue = null,
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = false,
                Length = 19,
                Precision = 19,
                Scale = 0
			};

            ///<summary>引用的分类Id</summary>
            public static readonly Field RefCategory = new Field
            {
                Name = __.RefCategory,
				ColumnName = "ref_category",
                DisplayName = "引用的分类Id",
                Description = "引用的分类Id",
                DataType = DbType.Int64,
                DefaultValue = null,
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = false,
                Length = 19,
                Precision = 19,
                Scale = 0
			};

            ///<summary>标示（字符char200)</summary>
            public static readonly Field TxtChar = new Field
            {
                Name = __.TxtChar,
				ColumnName = "txt_char",
                DisplayName = "标示字符char200",
                Description = "标示（字符char200)",
                DataType = DbType.String,
                DefaultValue = "",
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 200,
                Precision = 0,
                Scale = 0
			};

            ///<summary>名称（text8000）</summary>
            public static readonly Field TxtText = new Field
            {
                Name = __.TxtText,
				ColumnName = "txt_text",
                DisplayName = "名称text8000",
                Description = "名称（text8000）",
                DataType = DbType.String,
                DefaultValue = "",
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 65535,
                Precision = 0,
                Scale = 0
			};

            ///<summary>是否启用（bool替代值enumyn）</summary>
            public static readonly Field BoolEnum = new Field
            {
                Name = __.BoolEnum,
				ColumnName = "bool_enum",
                DisplayName = "是否启用bool替代值enumyn",
                Description = "是否启用（bool替代值enumyn）",
                DataType = DbType.Boolean,
                DefaultValue = "false",
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = false,
                Length = 1,
                Precision = 0,
                Scale = 0
			};

            ///<summary>扩展枚举（可多重选择1,2,3）</summary>
            public static readonly Field ExtEnum = new Field
            {
                Name = __.ExtEnum,
				ColumnName = "ext_enum",
                DisplayName = "扩展枚举可多重选择1,2,3",
                Description = "扩展枚举（可多重选择1,2,3）",
                DataType = DbType.String,
                DefaultValue = "",
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 5,
                Precision = 0,
                Scale = 0
			};

            ///<summary>类型（tinyint2）</summary>
            public static readonly Field NumTinyint = new Field
            {
                Name = __.NumTinyint,
				ColumnName = "num_tinyint",
                DisplayName = "类型tinyint2",
                Description = "类型（tinyint2）",
                DataType = DbType.SByte,
                DefaultValue = null,
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 3,
                Precision = 3,
                Scale = 0
			};

            ///<summary>价格（decimal10,2）</summary>
            public static readonly Field NumDecimal = new Field
            {
                Name = __.NumDecimal,
				ColumnName = "num_decimal",
                DisplayName = "价格decimal10,2",
                Description = "价格（decimal10,2）",
                DataType = DbType.Decimal,
                DefaultValue = null,
                IsPrimaryKey = false,
				Identity = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 10,
                Precision = 10,
                Scale = 2
			};

            ///<summary>注册日期（date）</summary>
            public static readonly Field DtDate = new Field
            {
                Name = __.DtDate,
				ColumnName = "dt_date",
                DisplayName = "注册日期date",
                Description = "注册日期（date）",
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

            ///<summary>修改时间（datetime）</summary>
            public static readonly Field DtDatetime = new Field
            {
                Name = __.DtDatetime,
				ColumnName = "dt_datetime",
                DisplayName = "修改时间datetime",
                Description = "修改时间（datetime）",
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

            ///<summary>时间戳</summary>
            public static readonly Field DtTimestamp = new Field
            {
                Name = __.DtTimestamp,
				ColumnName = "dt_timestamp",
                DisplayName = "时间戳",
                Description = "时间戳",
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

			///<summary>所有字段列表</summary>
			public static readonly IList<Field> AllFields = new List<Field>
            {
				OriginalKeyId,			
				KeyId,
				OriginalKeyStr,			
				KeyStr,			
				IdxCode,			
				IdxNum,			
				RefCategory,			
				TxtChar,			
				TxtText,			
				BoolEnum,			
				ExtEnum,			
				NumTinyint,			
				NumDecimal,			
				DtDate,			
				DtDatetime,			
				DtTimestamp,
            };

        }

        #endregion
    }
}