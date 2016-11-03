namespace App
{
    public class ConfigSettingModel
    {
        public string appKey { get; set; }
        public AppExa appExa { get; set; }
    }

    public class AppExa
    {
        public string exaColumnConfig { get; set; }
        public bool exaIsExplicit { get; set; }
        public int exaStartNum { get; set; }
    }
}
