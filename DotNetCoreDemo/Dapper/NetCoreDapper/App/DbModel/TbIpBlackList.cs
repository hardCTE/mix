using System;
using DapperMapExt;

namespace App.DbModel
{
    public partial class TbIpBlackList
    {
        public virtual Int64 Id { get; set; }
        public virtual string Ip { get; set; }

        [Column(Name = "add_time")]
        public virtual DateTime AddTime { get; set; }

        [Column(Name = "end_time")]
        public virtual DateTime? EndTime { get; set; }

        [Column(Name = "is_enable")]
        public virtual bool IsEnable { get; set; }
        public virtual string Descr { get; set; }
    }
}
