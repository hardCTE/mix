namespace WebApp.BootStrapHelper.DataTables
{
    /// <summary>
    /// 参数信息
    /// </summary>
    public class Param
    {
        public int draw { get; set; }

        private int _start = 0;
        public int start
        {
            get
            {
                return _start = _start <= 0 ? 0 : _start;
            }
            set { _start = value; }
        }

        public int length { get; set; }
        public Column[] columns { get; set; }
        public Order[] order { get; set; }
        public Search search { get; set; }

        /// <summary>
        /// TODO:根据字段描述验证列信息 columns、search
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return true;
        }

        /// <summary>
        /// 获取排序列名
        /// </summary>
        /// <returns></returns>
        public string GetOrderColumnName()
        {
            if (order != null && order.Length > 0)
            {
                if (columns != null && columns.Length > order[0].column && columns[order[0].column].orderable)
                {
                    return columns[order[0].column].data;
                }
            }

            return null;
        }

        /// <summary>
        /// 是否升序
        /// </summary>
        /// <returns></returns>
        public bool? IsAsc()
        {
            return string.Equals(GetOrderDir(), "asc", System.StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 获取排序方向(ASC、DESC、Null)
        /// </summary>
        /// <returns></returns>
        public string GetOrderDir()
        {
            if (order != null && order.Length > 0)
            {
                return order[0].dir;
            }

            return null;
        }

        /// <summary>
        /// 获取sql排序语句(只按照单列排序、不含Order By)
        ///     Eg： XXCloumn Desc
        /// </summary>
        /// <returns></returns>
        public string GetSqlOrderClause()
        {
            var result = string.Empty;

            if (order != null && order.Length > 0)
            {
                if (columns != null && columns.Length > order[0].column && columns[order[0].column].orderable)
                {
                    result = $"{columns[order[0].column].data} {order[0].dir}";
                }
            }

            return result;
        }
    }
}
