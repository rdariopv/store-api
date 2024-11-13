

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using xbiz_store.Models;

namespace xbiz_store.Context
{
    public class StoreContext: DbContext,IStoreContext
    {
        public StoreContext() { }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options){}

        public DbContext Instance => this;

        public DbSet<ivprd> ivprd { get; set; }
    
        public DataTable obtenerDatosSQL(string lsSQL)
        {
            DbConnection loConx = Instance.Database.GetDbConnection();
            DbProviderFactory loFactory = DbProviderFactories.GetFactory(loConx);

            using (var loCommand = loFactory.CreateCommand())
            {
                loCommand.Connection = loConx;
                loCommand.CommandType = CommandType.Text;
                loCommand.CommandText = lsSQL;

                using (DbDataAdapter loAdapter = loFactory.CreateDataAdapter())
                {
                    loAdapter.SelectCommand = loCommand;
                    DataTable dt = new DataTable();
                    loAdapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable obtenerDatosSQL(string lsSQL, List<SqlParameter> parameters)
        {
            DbConnection loConx = Instance.Database.GetDbConnection();
            DbProviderFactory loFactory = DbProviderFactories.GetFactory(loConx);

            using (var loCommand = loFactory.CreateCommand())
            {
                loCommand.Connection = loConx;
                loCommand.CommandType = CommandType.Text;
                loCommand.CommandText = lsSQL;
                loCommand.Parameters.Clear();
                foreach (SqlParameter parameter in parameters)
                {
                    loCommand.Parameters.Add(parameter);
                }
                using (DbDataAdapter loAdapter = loFactory.CreateDataAdapter())
                {
                    loAdapter.SelectCommand = loCommand;
                    DataTable dt = new DataTable();
                    loAdapter.Fill(dt);
                    return dt;
                }
            }
        }
        public int ejecutarSQL(string lsSQL, IDbContextTransaction loTrans = null)
        {
            DbConnection loConx = Instance.Database.GetDbConnection();
            DbProviderFactory loFactory = DbProviderFactories.GetFactory(loConx);
            try
            {
                if (loConx.State != ConnectionState.Open)
                {
                    loConx.Open();
                }

                using (var loCommand = loFactory.CreateCommand())
                {
                    loCommand.Connection = loConx;
                    loCommand.CommandType = CommandType.Text;
                    loCommand.CommandText = lsSQL;
                    if (loTrans == null)
                    {
                        loCommand.Transaction = (DbTransaction)loTrans;
                    }
                    else
                    {
                        loCommand.Transaction = loTrans.GetDbTransaction();
                    }

                    return loCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                loConx.Close();
            }
        }
        public int ejecutarSQL2(string lsSQL, List<SqlParameter> parameters = null)
        {
            if (parameters != null)
            {
                return Instance.Database.ExecuteSqlRaw(lsSQL, parameters);
            }
            else
            {
                return Instance.Database.ExecuteSqlRaw(lsSQL);
            }


        }
    }
}
