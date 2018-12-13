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
    public class YapimciRepository : RepositoryBase, IRepository<Yapimci>
    {
        public YapimciRepository(IDbTransaction transaction) : base(transaction) { }

        public IEnumerable<Yapimci> getAll()
        {
            return Connection.Query<Yapimci>("SELECT * FROM Yapimci", transaction: Transaction);
        }

        public Yapimci getById(int id)
        {
            return Connection.Query<Yapimci>("GetYapimciById", new { YapimciID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction).FirstOrDefault();
        }

        public int Insert(Yapimci entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@adi", entity.adi);
                parameters.Add("@kurulusTarihi", entity.kurulusTarihi, DbType.DateTime);
                parameters.Add("@slogan", entity.slogan);

                Connection.Execute("AddYapimci", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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
            try
            {
                Connection.Execute("RemoveYapimciById", new { YapimciID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }



        public bool Update(Yapimci entity)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@adi", entity.adi);
                parameters.Add("@kurulusTarihi", entity.kurulusTarihi, DbType.DateTime);
                parameters.Add("@slogan", entity.slogan);

                Connection.Execute("UpdateYapimci", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
