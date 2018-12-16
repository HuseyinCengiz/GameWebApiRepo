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
    public class KullaniciRepository : RepositoryBase,IRepository<Kullanici>
    {
        public KullaniciRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Kullanici> getAll()
        {
            return Connection.Query<Kullanici>("SELECT * FROM Kullanici", transaction: Transaction);
        }

        public Kullanici getById(int id)
        {
            return Connection.Query<Kullanici>("GetKullaniciById", new { KullaniciID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction).FirstOrDefault();
        }

        public int Insert(Kullanici entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@adi", entity.adi);
                parameters.Add("@kullaniciAdi", entity.kullaniciAdi);
                parameters.Add("@dogumTarihi", entity.dogumTarihi, DbType.DateTime);
                parameters.Add("@sifre", entity.sifre);
                parameters.Add("@bakiye", entity.bakiye,dbType:DbType.Decimal);

                Connection.Execute("AddKullanici", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);

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
                Connection.Execute("RemoveKullaniciById", new { KullaniciID = id }, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Kullanici entity)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@id", entity.id, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@adi", entity.adi);
                parameters.Add("@kullaniciAdi", entity.kullaniciAdi);
                parameters.Add("@dogumTarihi", entity.dogumTarihi, DbType.DateTime);
                parameters.Add("@sifre", entity.sifre);
                parameters.Add("@bakiye", entity.bakiye, dbType: DbType.Decimal);

                Connection.Execute("UpdateKullanici", parameters, commandType: System.Data.CommandType.StoredProcedure, transaction: Transaction);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int IsLogin(Kullanici entity)
        {
            return Connection.Query<Kullanici>("SELECT id FROM Kullanici WHERE kullaniciAdi=@kullaniciAdi and sifre=@sifre", new { kullaniciAdi = entity.kullaniciAdi, sifre = entity.sifre }, transaction: Transaction).FirstOrDefault().id;
        }

        public string getUserName(int kullaniciId)
        {
            return Connection.Query<string>("SELECT kullaniciAdi FROM Kullanici WHERE id=@kullaniciId", new { kullaniciId = kullaniciId }, transaction: Transaction).FirstOrDefault();
        }
    }
}
