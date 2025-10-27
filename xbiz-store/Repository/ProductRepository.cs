using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbiz_store.Context;
using xbiz_store.Models;

namespace xbiz_store.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = @"
                SELECT ivprdcprd AS Codigo,
                       ivprdcbrr AS CodigoBarras,
                       ivprdnomb AS Nombre,
                       ivprddesc AS Descripcion,
                       A.ivcondesc AS UnidadMedida,
                       ISNULL(CAST(ivimgimag AS VARBINARY(8000)), NULL) AS Imagen,
                       ISNULL((SELECT ivmarnomb FROM ivmar WHERE ivmarcmar = ivprdmarc), 'Sin Marca') AS MarcaDescripcion,
                       ISNULL((SELECT CAST(SUM(ivdtrcant) AS DECIMAL(18,2)) FROM ivdtr, ivalm
                               WHERE ivdtrstat = 0 AND ivalmstat = 0
                                 AND ivalmcalm = ivdtrcalm
                                 AND ivdtrcalm = 1
                                 AND ivdtrcprd = ivprdcprd), 0) AS StockActual,
                       ISNULL((SELECT CAST(MAX(ivprepmve) AS DECIMAL(18,2)) FROM ivpre
                               WHERE ivprestat = 0 AND ivprenofi = 1
                                 AND ivpretpre = 1
                                 AND ivprecprd = ivprdcprd), 0) AS PrecioVenta
                FROM ivprd
                INNER JOIN ivimg ON ivprdcprd = ivimgcprd,
                     ivcon A
                WHERE ivprdstat = 0
                  AND ivimgstat = 0
                  AND A.ivconpref = 2
                  AND A.ivconcorr = ivprdumba
                  AND ivprdfact = 1";

            return await _context.Set<Product>().FromSqlRaw(sql).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var sql = @"
                SELECT ivprdcprd AS Codigo,
                       ivprdcbrr AS CodigoBarras,
                       ivprdnomb AS Nombre,
                       ivprddesc AS Descripcion,
                       A.ivcondesc AS UnidadMedida,
                       ISNULL(CAST(ivimgimag AS VARBINARY(8000)), NULL) AS Imagen,
                       ISNULL((SELECT ivmarnomb FROM ivmar WHERE ivmarcmar = ivprdmarc), 'Sin Marca') AS MarcaDescripcion,
                       ISNULL((SELECT CAST(SUM(ivdtrcant) AS DECIMAL(18,2)) FROM ivdtr, ivalm
                               WHERE ivdtrstat = 0 AND ivalmstat = 0
                                 AND ivalmcalm = ivdtrcalm
                                 AND ivdtrcalm = 1
                                 AND ivdtrcprd = ivprdcprd), 0) AS StockActual,
                       ISNULL((SELECT CAST(MAX(ivprepmve) AS DECIMAL(18,2)) FROM ivpre
                               WHERE ivprestat = 0 AND ivprenofi = 1
                                 AND ivpretpre = 1
                                 AND ivprecprd = ivprdcprd), 0) AS PrecioVenta
                FROM ivprd
                INNER JOIN ivimg ON ivprdcprd = ivimgcprd,
                     ivcon A
                WHERE ivprdstat = 0
                  AND ivimgstat = 0
                  AND A.ivconpref = 2
                  AND A.ivconcorr = ivprdumba
                  AND ivprdfact = 1
                    AND ivprdcprd = @id";
            var parameters = new[]
            {
                new SqlParameter("@id", id),
            };

            return await _context.Set<Product>().
                FromSqlRaw(sql, parameters).
                AsNoTracking().
                FirstOrDefaultAsync();
        }
    }
}
