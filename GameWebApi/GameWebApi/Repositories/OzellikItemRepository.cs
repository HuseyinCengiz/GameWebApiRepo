using Dapper;
using GameWebApi.Entities;
using GameWebApi.Infrastructure;
using GameWebApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Repositories
{
    public class OzellikItemRepository : RepositoryBase,IRepository<OzellikItem>
    {
        public OzellikItemRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public IEnumerable<OzellikItem> getAll()
        {
            return Connection.Query<OzellikItem>("SELECT * FROM OzellikItem", transaction: Transaction);
        }

        public OzellikItem getById(int id)
        {
            return Connection.Query<OzellikItem>("GetOzellikItemById", new { OzellikItemID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction).FirstOrDefault();
        }

        public int Insert(OzellikItem entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@ozellikID", entity.ozellikId, dbType: DbType.Int32);
                parameters.Add("@itemID", entity.itemId, dbType: DbType.Int32);

                Connection.Execute("AddOzellikItem", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

            }
            catch (Exception)
            {
                entity.id = -1;
            }

            return entity.id;
        }

        public bool Remove(int id)
        {
            try
            {
                Connection.Execute("RemoveOzellikItemById", new { OzellikItemID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(OzellikItem entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@ozellikId", entity.ozellikId, dbType: DbType.Int32);
                parameters.Add("@itemId", entity.itemId, dbType: DbType.Int32);

                Connection.Execute("UpdateOzellikItem", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
