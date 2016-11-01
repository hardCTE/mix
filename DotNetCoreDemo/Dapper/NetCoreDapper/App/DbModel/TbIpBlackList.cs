using System;
using System.Collections.Generic;
using System.Data;
using App.DAL;
using DapperMapExt;

namespace App.DbModel
{
    public partial class TbIpBlackList
    {
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

        public partial class _
        {
            public static readonly Field OriginalId = new Field
            {
                Name = "OriginalId",
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
                Name = "Id",
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
                Name = "Ip",
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
                Name = "AddTime",
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
                Name = "EndTime",
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
                Name = "IsEnable",
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
                Name = "Descr",
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
}
