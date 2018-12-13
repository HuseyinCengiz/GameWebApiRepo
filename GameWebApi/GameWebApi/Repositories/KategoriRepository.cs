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
    public class KategoriRepository : RepositoryBase,IRepository<Kategori>
    {
        public KategoriRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Kategori> getAll()
        {
            return Connection.Query<Kategori>("SELECT * FROM Kategori", transaction: Transaction);
        }

        public Kategori getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Kategori entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@kategoriAdi", entity.kategoriAdi);
  
                Connection.Execute("AddKategori", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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

        public bool Update(Kategori entity)
        {
            throw new NotImplementedException();
        }
    }
}
