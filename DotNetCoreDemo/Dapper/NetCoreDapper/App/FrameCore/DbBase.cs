using System.Data;

namespace App.FrameCore
{
    public abstract class DbBase
    {
        public IDbConnection DbConn { get; private set; }

        public DbBase() : this(null)
        {
        }

        public DbBase(IDbConnection dbcon)
        {
            if (dbcon != null)
            {
                DbConn = dbcon;
            }
            else
            {
                // TODO:根据类型自动构建
            }
        }
    }
}
