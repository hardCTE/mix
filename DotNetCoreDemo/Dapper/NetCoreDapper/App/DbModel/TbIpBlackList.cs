using System;
using System.Collections.Generic;
using System.Data;
using DapperMapExt;

namespace App.DbModel
{
    public partial class TbIpBlackList: ModelBase
    {
        #region 属性

        public virtual Int64 OriginalId { get; set; }
        public virtual Int64 Id { get; set; }
        public virtual string Ip { get; set; }

        [Column(Name = "add_time")]
        public virtual DateTime AddTime { get; set; }

        [Column(Name = "end_time")]
        public virtual DateTime? EndTime { get; set; }

        [Column(Name = "is_enable")]
        public virtual bool IsEnable { get; set; }

        public virtual string Descr { get; set; }

        #endregion

        #region 获取/设置 字段值

        /// <summary>
        /// 获取/设置 字段值。
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.OriginalId:
                        return OriginalId;
                    case __.Id:
                        return Id;
                    case __.Ip:
                        return Ip;
                    case __.AddTime:
                        return AddTime;
                    case __.EndTime:
                        return EndTime;
                    case __.IsEnable:
                        return IsEnable;
                    case __.Descr:
                        return Descr;
                    default:
                        return null;
                }
            }
            set
            {
                switch (name)
                {
                    case __.OriginalId:
                        OriginalId = Convert.ToInt64(value);
                        break;
                    case __.Id:
                        Id = Convert.ToInt64(value);
                        break;
                    case __.Ip:
                        Ip = Convert.ToString(value);
                        break;
                    case __.AddTime:
                        AddTime = Convert.ToDateTime(value);
                        break;
                    case __.EndTime:
                        EndTime = value == null ? (DateTime?) null : Convert.ToDateTime(value);
                        break;
                    case __.IsEnable:
                        IsEnable = Convert.ToBoolean(value);
                        break;
                    case __.Descr:
                        Descr = Convert.ToString(value);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region 字段信息

        /// <summary>
        /// 获取属性字段名称快捷方式
        /// </summary>
        public partial class __
        {
            /// <summary>
            /// 数据库表名
            /// </summary>
            public const string DataBaseTableName = "tb_ip_blacklist";

            public const string OriginalId = "OriginalId";
            public const string Id = "Id";
            public const string Ip = "Ip";
            public const string AddTime = "AddTime";
            public const string EndTime = "EndTime";
            public const string IsEnable = "IsEnable";
            public const string Descr = "Descr";
        }

        /// <summary>
        /// 获取字段定义快捷方式
        /// </summary>
        public partial class _
        {
            public static readonly Field OriginalId = new Field
            {
                Name = __.OriginalId,
                ColumnName = "id",
                DisplayName = "自增Id",
                Description = "自增Id",
                DataType = DbType.Int64,
                IsPrimaryKey = true,
                IsReadonly = true,
                IsNullable = false,
            };

            public static readonly Field Id = new Field
            {
                Name = __.Id,
                ColumnName = "id",
                DisplayName = "自增Id",
                Description = "自增Id",
                DataType = DbType.Int64,
                IsPrimaryKey = true,
                IsReadonly = false,
                IsNullable = false,
            };

            public static readonly Field Ip = new Field
            {
                Name = __.Ip,
                ColumnName = "ip",
                DisplayName = "Ip地址",
                Description = "Ip地址",
                DataType = DbType.String,
                DefaultValue = string.Empty,
                IsPrimaryKey = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 200,
            };

            public static readonly Field AddTime = new Field
            {
                Name = __.AddTime,
                ColumnName = "add_time",
                DisplayName = "添加时间",
                Description = "添加时间",
                DataType = DbType.DateTime,
                DefaultValue = "",
                IsPrimaryKey = false,
                IsReadonly = false,
                IsNullable = false,
            };

            public static readonly Field EndTime = new Field
            {
                Name = __.EndTime,
                ColumnName = "end_time",
                DisplayName = "修改时间",
                Description = "修改时间",
                DataType = DbType.DateTime,
                DefaultValue = "",
                IsPrimaryKey = false,
                IsReadonly = false,
                IsNullable = true,
            };

            public static readonly Field IsEnable = new Field
            {
                Name = __.IsEnable,
                ColumnName = "is_enable",
                DisplayName = "是否启用",
                Description = "是否启用",
                DataType = DbType.Boolean,
                DefaultValue = "0",
                IsPrimaryKey = false,
                IsReadonly = false,
                IsNullable = false,
            };

            public static readonly Field Descr = new Field
            {
                Name = __.Descr,
                ColumnName = "descr",
                DisplayName = "描述",
                Description = "描述",
                DataType = DbType.String,
                DefaultValue = string.Empty,
                IsPrimaryKey = false,
                IsReadonly = false,
                IsNullable = true,
                Length = 800,
            };

            public static readonly IList<Field> AllFields = new List<Field>
            {
                OriginalId,
                Id,
                Ip,
                AddTime,
                EndTime,
                IsEnable,
                Descr
            };
        }

        #endregion
    }

    public class Field
    {
        public string Name { get; set; }
        public string ColumnName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DbType DataType { get; set; }
        public string DefaultValue { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsNullable { get; set; }
        public int? Length { get; set; }
        public int? Precision { get; set; }
        public int? Scale { get; set; }
    }

    /// <summary>
    /// 索引器接访问口。
    ///   该接口用于通过名称快速访问对象属性或字段（属性优先）
    /// </summary>
    public interface IIndexAccessor
    {
        /// <summary>
        /// 获取/设置 指定名称的属性或字段的值
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns/>
        object this[string name] { get; set; }
    }

    public abstract class _Base
    {
        public static readonly IList<Field> AllFields;
    }

    public abstract class __Base
    {
        public const string DataBaseTableName = "";
    }

    public abstract class ModelBase : IIndexAccessor
    {
        public class __ : __Base
        {
        }

        public class _ : _Base
        {
        }

        #region IIndexAccessor

        public virtual object this[string name]
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        #endregion
    }
}
