using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL
{


    public class TbSchoolInfoDal : DbBase
    {
        #region 定义

        public TbSchoolInfoDal(IDbConnection dbCon = null) : base(dbCon)
        {

        }

        #endregion

    }
}
