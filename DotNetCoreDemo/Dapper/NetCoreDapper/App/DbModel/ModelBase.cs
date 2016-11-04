using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace App.DbModel
{
    /// <summary>
    /// ModelBase
    /// </summary>
    public abstract class ModelBase : IIndexAccessor
    {
        /// <summary>
        /// 获取模型所有字段
        /// </summary>
        /// <returns></returns>
        public virtual IList<Field> GetAllFields()
        {
            throw new NotImplementedException();
        }

        #region IIndexAccessor

        public virtual object this[string name]
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        #endregion

        /// <summary>
        /// 验证数据
        /// </summary>
        /// <param name="isNew">是否新添加</param>
        /// <param name="validAll">是否需要验证所有字段</param>
        /// <param name="errorList">出错信息</param>
        /// <returns></returns>
        public virtual bool Valid(bool isNew, bool validAll, out IList<ValidateInfo> errorList)
        {
            errorList = new List<ValidateInfo>();

            var fields = GetAllFields();
            foreach (var field in fields)
            {
                if (isNew)
                {
                    if (field.IsPrimaryKey && field.IsReadonly || field.Identity)
                    {
                        continue;   // 只读主键（原始主键） 或者 标示（自增）
                    }
                }

                var error = Valid(field);

                if (!string.IsNullOrWhiteSpace(error))
                {
                    errorList.Add(new ValidateInfo
                    {
                        Name = field.Name,
                        Error = error,
                        DataValue = this[field.Name]
                    });

                    if (!validAll)
                    {
                        return false;
                    }
                }
            }
            
            return !errorList.Any();
        }

        /// <summary>
        /// 验证指定字段信息
        /// </summary>
        /// <param name="field">要验证的字段</param>
        /// <returns>错误信息</returns>
        protected virtual string Valid(Field field)
        {
            var errorList = new List<string>();

            var val = this[field.Name];

            // 非空
            if (!field.IsNullable)
            {
                if (val == null || field.DataType == DbType.String && (string) val == "")
                {
                    errorList.Add("非空");
                }
            }

            // 数据长度---文本
            if (field.Length.HasValue && field.Length.Value > 0)
            {
                if (val != null && field.DataType == DbType.String && ((string) val).Length > field.Length.Value)
                {
                    errorList.Add($"最长{field.Length.Value}");
                }
            }

            // 精度---数字 DECIMAL、SByte
            if (field.Precision.HasValue && field.Precision.Value > 0 && val != null)
            {
                if ((field.DataType == DbType.Decimal &&
                     (Decimal) val > (Decimal) Math.Pow(10, field.Precision.Value))
                    || (field.DataType == DbType.SByte &&
                        (SByte) val > (SByte) Math.Pow(10, field.Precision.Value)))
                {
                    errorList.Add($"最大精度{field.Precision.Value}");
                }
            }

            //TODO: 唯一索引是否重复

            return string.Join(";", errorList);
        }

        /// <summary>
        /// 尝试根据字段名称和字段值初始化模型
        /// </summary>
        /// <param name="fieldNameValueDic">字段名称、字段值字典</param>
        /// <param name="errorList">出错信息</param>
        /// <returns></returns>
        public virtual bool TryInit(IDictionary<string, string> fieldNameValueDic, out IList<ValidateInfo> errorList)
        {
            errorList = new List<ValidateInfo>();

            var fields = GetAllFields().Where(p => fieldNameValueDic.ContainsKey(p.Name));
            foreach (var field in fields)
            {
                var val = fieldNameValueDic[field.Name];

                #region 去空格处理
                switch (field.DataType)
                {
                    //case DbType.AnsiString:
                    //case DbType.AnsiStringFixedLength:
                    //case DbType.Byte:
                    //case DbType.Guid:
                    //case DbType.Object:
                    //case DbType.String:
                    //case DbType.StringFixedLength:
                    //case DbType.Xml:
                    //case DbType.Boolean:
                    //case DbType.Binary:
                    //    break;
                    case DbType.Currency:
                    case DbType.Date:
                    case DbType.DateTime:
                    case DbType.DateTime2:
                    case DbType.DateTimeOffset:
                    case DbType.Decimal:
                    case DbType.Double:
                    case DbType.Int16:
                    case DbType.Int32:
                    case DbType.Int64:
                    case DbType.SByte:
                    case DbType.Single:
                    case DbType.Time:
                    case DbType.UInt16:
                    case DbType.UInt32:
                    case DbType.UInt64:
                    case DbType.VarNumeric:
                        val = val?.Trim();
                        break;
                }
                #endregion

                try
                {
                    this[field.Name] = val;
                }
                catch (Exception ex)
                {
                    errorList.Add(new ValidateInfo
                    {
                        Name = field.Name,
                        DataValue = val,
                        Error = "数据类型转换失败"
                    });

                    // TOOD:LOG
                    continue;
                }

                var error = Valid(field);

                if (!string.IsNullOrWhiteSpace(error))
                {
                    errorList.Add(new ValidateInfo
                    {
                        Name = field.Name,
                        Error = error,
                        DataValue = this[field.Name]
                    });
                }
            }

            return !errorList.Any();
        }
    }
}
