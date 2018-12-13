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
    public class ResimRepository : RepositoryBase,IRepository<Resim>
    {
        public ResimRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Resim> getAll()
        {
            throw new NotImplementedException();
        }

        public Resim getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Resim entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@url", entity.url);
                parameters.Add("@oyunId", entity.oyunId, DbType.Int32);

                Connection.Execute("AddResim", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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

        public bool Update(Resim entity)
        {
            throw new NotImplementedException();
        }
    }
}
