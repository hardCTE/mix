namespace WebApp.BootStrapHelper.DataTables
{
    /// <summary>
    /// 排序条件
    /// </summary>
    public class Order
    {
        public int column { get; set; }

        private string _dir = null;
        public string dir
        {
            get
            {
                if (_dir != null && string.Equals(_dir.Trim(), "desc", System.StringComparison.OrdinalIgnoreCase))
                {
                    return "DESC";
                }
                else
                {
                    return "ASC";
                }
            }
            set { _dir = value; }
        }
    }
}
