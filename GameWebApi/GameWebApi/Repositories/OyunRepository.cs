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
    public class OyunRepository : RepositoryBase, IRepository<Oyun>
    {
        public OyunRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Oyun> getAll()
        {
            return Connection.Query<Oyun>("SELECT * FROM Oyun", transaction: Transaction);
        }

        public Oyun getById(int id)
        {
            return Connection.Query<Oyun>("Select * From Oyun Where id=@id", new { id = id }, transaction: Transaction).FirstOrDefault();
        }

        public int Insert(Oyun entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@adi", entity.adi);
                parameters.Add("@aciklama", entity.aciklama);
                parameters.Add("@fiyat", entity.fiyat, DbType.Decimal);
                parameters.Add("@cikisTarihi", entity.cikisTarihi, DbType.DateTime);
                parameters.Add("@boyut", entity.boyut, DbType.Double);
                parameters.Add("@yapimciID", entity.yapimciId, DbType.Int32);

                Connection.Execute("AddOyun", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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

        public bool Update(Oyun entity)
        {
            throw new NotImplementedException();
        }
    }
}
