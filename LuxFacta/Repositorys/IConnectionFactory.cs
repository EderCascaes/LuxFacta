using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LuxFacta.Repositorys
{
    public interface IConnectionFactory
    {
        IDbConnection Connection();
    }

   
}
