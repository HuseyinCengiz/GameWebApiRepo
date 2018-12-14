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
    public class OzellikRepository : RepositoryBase,IRepository<Ozellik>
    {
        public OzellikRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Ozellik> getAll()
        {
            return Connection.Query<Ozellik>("SELECT * FROM Ozellik", transaction: Transaction);
        }

        public Ozellik getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Ozellik entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@adi", entity.Adi);
                parameters.Add("@degeri", entity.Degeri, DbType.Int32);
                
                Connection.Execute("AddOzellik", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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

        public bool Update(Ozellik entity)
        {
            throw new NotImplementedException();
        }
    }
}
