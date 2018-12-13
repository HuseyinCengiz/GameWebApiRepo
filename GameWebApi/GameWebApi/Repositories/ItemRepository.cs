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
    public class ItemRepository : RepositoryBase, IRepository<Item>
    {
        public ItemRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Item> getAll()
        {
            return Connection.Query<Item>("SELECT * FROM Item", transaction: Transaction);
        }

        public Item getById(int id)
        {
            return Connection.Query<Item>("Select * From Item Where id=@id", new { id = id }, transaction: Transaction).FirstOrDefault();
        }

        public int Insert(Item entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@adi", entity.adi);
                parameters.Add("@aciklama", entity.aciklama);
                parameters.Add("@oyunID", entity.oyunId, DbType.Int32);
                parameters.Add("@marketID", entity.marketId, DbType.Int32);
                parameters.Add("@isSilah", entity.isSilah,DbType.Boolean);
                parameters.Add("@isKiyafet", entity.isKiyafet, DbType.Boolean);
                parameters.Add("@isBoost", entity.isBoost, DbType.Boolean);

                Connection.Execute("AddItem", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

                entity.id = parameters.Get<int>("@id");
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

        public bool Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
