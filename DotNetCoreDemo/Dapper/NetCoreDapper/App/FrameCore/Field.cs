using System.Data;

namespace App.FrameCore
{
    public class Field
    {
        public string Name { get; set; }
        public string ColumnName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DbType DataType { get; set; }
        public string DefaultValue { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool Identity { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsNullable { get; set; }
        public int? Length { get; set; }
        public int? Precision { get; set; }
        public int? Scale { get; set; }
    }

}
