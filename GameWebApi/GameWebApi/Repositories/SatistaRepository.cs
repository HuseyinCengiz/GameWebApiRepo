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
    public class SatistaRepository : RepositoryBase,IRepository<Satista>
    {
        public SatistaRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Satista> getAll()
        {
            return Connection.Query<Satista>("Select s.id,s.itemId,s.satisFiyati,i.adi,i.aciklama,k.kullaniciAdi,ir.url From Satista s join Item i on s.itemId=i.id join ItemResim ir on ir.itemId=s.itemId join Kullanici k on  k.id=s.kullaniciId", transaction: Transaction);
        }


        public IEnumerable<Satislar> getAlll()
        {
            return Connection.Query<Satislar>("Select s.id,s.itemId,s.satisFiyati,i.adi,i.aciklama,k.kullaniciAdi,ir.url From Satista s join Item i on s.itemId=i.id join ItemResim ir on ir.itemId=s.itemId join Kullanici k on  k.id=s.kullaniciId", transaction: Transaction);
        }



        public Satista getById(int id)
        {
            return Connection.Query<Satista>("GetSatistaById", new { SatistaID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction).FirstOrDefault();
        }

        public int Insert(Satista entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32);
                parameters.Add("@satisFiyati", entity.satisFiyati, dbType: DbType.Decimal);
                parameters.Add("@itemId", entity.satisFiyati, dbType: DbType.Int32);
                parameters.Add("@kullaniciId", entity.satisFiyati, dbType: DbType.Int32);

                Connection.Execute("AddSatista", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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
                Connection.Execute("RemoveSatistaById", new { SatistaID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Satista entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@satisFiyati", entity.satisFiyati, dbType: DbType.Decimal);
                parameters.Add("@itemId", entity.satisFiyati, dbType: DbType.Int32);

                Connection.Execute("UpdateSatista", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
