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
    public class ItemResimRepository : RepositoryBase,IRepository<ItemResim>
    {
        public ItemResimRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<ItemResim> getAll()
        {
            throw new NotImplementedException();
        }

        public ItemResim getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ItemResim entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@url", entity.url);
                parameters.Add("@itemID", entity.itemId, DbType.Int32);

                Connection.Execute("AddItemResim", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

            }
            catch (Exception)
            {
                entity.id = -1;
            }

            return entity.id;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ItemResim entity)
        {
            throw new NotImplementedException();
        }
    }
}
