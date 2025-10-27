using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xbiz_store.Context;
using Microsoft.Data.SqlClient;

namespace xbiz_store.Data
{
    public class SqlHelper
    {
        private readonly StoreContext _context;

        public SqlHelper(StoreContext context)
        {
            _context = context;
        }
        //   🧩 1. Problema actual
        //Tu StoreContext:
        //• Implementa métodos como obtenerDatosSQL, ejecutarSQL, etc., manualmente.
        //• Está mezclando lógica de acceso a datos con la infraestructura de EF Core.
        //•Implementa IStoreContext, pero no queda claro cómo ni para qué lo estás usando(podría ser redundante).
        //• Tiene DbSet<ivprd> pero en tu repositorio trabajas con Product.
        //⚠️ Eso rompe parcialmente el principio de responsabilidad única (SRP): el DbContext debería limitarse a exponer entidades (DbSet<T>), no ejecutar SQL ni abrir conexiones manualmente.
        #region Metodos No Permitidos 


        public DataTable obtenerDatosSQL(string lsSQL)
        {
            DbConnection loConx = _context.Database.GetDbConnection();
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
            DbConnection loConx = _context.Database.GetDbConnection();
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
            DbConnection loConx = _context.Database.GetDbConnection();
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
                return _context.Database.ExecuteSqlRaw(lsSQL, parameters);
            }
            else
            {
                return _context.Database.ExecuteSqlRaw(lsSQL);
            }


        }


        #endregion

    }
}
