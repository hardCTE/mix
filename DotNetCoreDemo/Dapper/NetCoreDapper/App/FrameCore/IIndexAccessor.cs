namespace App.FrameCore
{
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
}
