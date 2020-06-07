using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Model;

namespace TokoBeDia.Repository
{
    public class DBSingleton
    {
        private static TokoBeDiaDBEntities db;

        public static TokoBeDiaDBEntities GetInstance()
        {
            if (db == null) db = new TokoBeDiaDBEntities();
            return db;
        }

    }
}