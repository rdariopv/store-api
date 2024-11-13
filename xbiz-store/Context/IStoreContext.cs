
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbiz_store.Models;

namespace xbiz_store.Context
{
    public interface IStoreContext
    {
        DbContext Instance { get; }
        DbSet<ivprd> ivprd { get; set; }
        DataTable obtenerDatosSQL(string lsSQL);
        DataTable obtenerDatosSQL(string lsSQL, List<SqlParameter> parameters);
        int ejecutarSQL(string lsSQL, IDbContextTransaction loTrans = null);
        int ejecutarSQL2(string lsSQL, List<SqlParameter> parameters = null);

    }
}
