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
    public class OyunKategoriRepository : RepositoryBase,IRepository<OyunKategori>
    {
        public OyunKategoriRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<OyunKategori> getAll()
        {
            throw new NotImplementedException();
        }

        public OyunKategori getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(OyunKategori entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@oyunID", entity.oyunId, DbType.Int32);
                parameters.Add("@kategoriID", entity.kategoriId, DbType.Int32);

                Connection.Execute("AddOyunKategori", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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

        public bool Update(OyunKategori entity)
        {
            throw new NotImplementedException();
        }
    }
}
