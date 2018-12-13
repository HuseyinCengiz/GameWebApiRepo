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
    public class OyunKullaniciRepository : RepositoryBase, IRepository<OyunKullanici>
    {
        public OyunKullaniciRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<OyunKullanici> getAll()
        {
            throw new NotImplementedException();
        }

        public OyunKullanici getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(OyunKullanici entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@userID", entity.userId, DbType.Int32);
                parameters.Add("@oyunID", entity.oyunId, DbType.Int32);

                Connection.Execute("AddOyunKullanici", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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

        public bool Update(OyunKullanici entity)
        {
            throw new NotImplementedException();
        }
    }
}
