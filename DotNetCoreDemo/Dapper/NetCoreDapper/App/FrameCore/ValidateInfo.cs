namespace App.FrameCore
{
    /// <summary>
    /// 验证信息
    /// </summary>
    public class ValidateInfo
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>
        public object DataValue { get; set; }
    }
}
