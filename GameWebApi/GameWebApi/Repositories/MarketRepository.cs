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
    public class MarketRepository : RepositoryBase, IRepository<Market>
    {
        public MarketRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Market> getAll()
        {
            return Connection.Query<Market>("SELECT * FROM Market", transaction: Transaction);
        }

        public Market getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Market entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@adi", entity.adi);
                parameters.Add("@oyunID", entity.oyunid, DbType.Int32);

                Connection.Execute("AddMarket", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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

        public bool Update(Market entity)
        {
            throw new NotImplementedException();
        }
    }
}
