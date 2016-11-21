namespace WebApp.BootStrapHelper.DataTables
{
    /// <summary>
    /// 列信息
    /// </summary>
    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }
}
