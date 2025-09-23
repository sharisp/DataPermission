using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPermission.Infra.Repository
{
    public class CommonQuery(AppDbContext dbContext)
    {
        public IQueryable<T> Query<T>() where T : class
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public string GetTableNameWithDbName<TEntity>() where TEntity : class
        {
            return $"{GetDbName()}.{GeTableName<TEntity>()}";
        }
        public string GetDbName()
        {
            return dbContext.Database.GetDbConnection().Database;
        }

        public string GeTableName<TEntity>() where TEntity : class
        {

            var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
            if (entityType == null)
                throw new InvalidOperationException($"Entity {typeof(TEntity).Name} not found in DbContext.");

            var tableName = entityType.GetTableName();
            //var schema = entityType.GetSchema();
            return  tableName;
        }
    }
}
