using Dapper;
using GameWebApi.Contracts.Responses;
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
    public class SatinAlinanlarRepository : RepositoryBase,IRepository<SatinAlinanlar>
    {
        public SatinAlinanlarRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<SatinAlinanlar> getAll()
        {
            return Connection.Query<SatinAlinanlar>("SELECT * FROM SatinAlinanlar", transaction: Transaction);
        }

        public SatinAlinanlar getById(int id)
        {
            return Connection.Query<SatinAlinanlar>("GetSatinAlinanlarById", new { SatinAlinanlarID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction).FirstOrDefault();
        }

        public int Insert(SatinAlinanlar entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@userID", entity.userId, dbType: DbType.Int32);
                parameters.Add("@itemID", entity.itemId, dbType: DbType.Int32);

                Connection.Execute("AddSatinAlinanlar", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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
                Connection.Execute("RemoveSatinAlinanlarById", new { SatinAlinanlarID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(SatinAlinanlar entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@userId", entity.userId, dbType: DbType.Int32);
                parameters.Add("@itemId", entity.itemId, dbType: DbType.Int32);

                Connection.Execute("UpdateSatinAlinanlar", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<SatinAlinanResponse> getAllItemByUserId(int userId)
        {
            return Connection.Query<SatinAlinanResponse>(@"SELECT s.id as satinAlinanId,s.itemId,i.adi,i.aciklama,ir.url FROM SatinAlinanlar as s INNER JOIN Item as i ON s.itemId = i.id INNER JOIN ItemResim as ir ON ir.itemId = i.id INNER JOIN Oyun as o ON o.id = i.oyunId where s.userId=@userId",new {userId=userId}, transaction: Transaction);
            
        }
    }
}
