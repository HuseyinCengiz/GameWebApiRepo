using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GameWebApi.Entities;
using GameWebApi.Infrastructure.Repositories;
using GameWebApi.Repositories;
using Microsoft.Extensions.Configuration;

namespace GameWebApi.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IRepository<Yapimci> _yapimciRepository;
        private IRepository<Video> _videoRepository;
        private IRepository<Resim> _resimRepository;
        private IRepository<Kullanici> _kullaniciRepository;
        private IRepository<Satista> _satistaRepository;
        private IRepository<SatinAlinanlar> _satinAlinanlarRepository;
        private IRepository<OzellikItem> _ozellikItemRepository;
        private IRepository<Ozellik> _ozellikRepository;
        private IRepository<OyunKullanici> _oyunKullaniciRepository;
        private IRepository<OyunKategori> _oyunKategoriRepository;
        private IRepository<Oyun> _oyunRepository;
        private IRepository<Market> _marketRepository;
        private IRepository<Kategori> _kategoriRepository;
        private IRepository<ItemResim> _itemResimRepository;
        private IRepository<Item> _itemRepository;
        private IRepository<Silah> _silahRepository;
        private IRepository<Kiyafet> _kiyafetRepository;
        private IRepository<Boost> _boostRepository;



        private readonly IConfiguration _config;
        private bool _disposed = false;

        public IRepository<Yapimci> YapimciRepository
        {
            get
            {
                return _yapimciRepository ?? (_yapimciRepository = new YapimciRepository(_transaction));
            }
        }

        public IRepository<Video> VideoRepository
        {
            get
            {
                return _videoRepository ?? (_videoRepository = new VideoRepository(_transaction));
            }
        }

        public IRepository<Resim> ResimRepository
        {
            get
            {
                return _resimRepository ?? (_resimRepository = new ResimRepository(_transaction));
            }
        }

        public IRepository<Kullanici> KullaniciRepository
        {
            get
            {
                return _kullaniciRepository ?? (_kullaniciRepository = new KullaniciRepository(_transaction));
            }
        }

        public IRepository<Satista> SatistaRepository
        {
            get
            {
                return _satistaRepository ?? (_satistaRepository = new SatistaRepository(_transaction));
            }
        }

        public IRepository<SatinAlinanlar> SatinAlinanlarRepository
        {
            get
            {
                return _satinAlinanlarRepository ?? (_satinAlinanlarRepository = new SatinAlinanlarRepository(_transaction));
            }
        }

        public IRepository<OzellikItem> OzellikItemRepository
        {
            get
            {
                return _ozellikItemRepository ?? (_ozellikItemRepository = new OzellikItemRepository(_transaction));
            }
        }

        public IRepository<Ozellik> OzellikRepository
        {
            get
            {
                return _ozellikRepository ?? (_ozellikRepository = new OzellikRepository(_transaction));
            }
        }
        public IRepository<OyunKullanici> OyunKullaniciRepository
        {
            get
            {
                return _oyunKullaniciRepository ?? (_oyunKullaniciRepository = new OyunKullaniciRepository(_transaction));
            }
        }

        public IRepository<OyunKategori> OyunKategoriRepository
        {
            get
            {
                return _oyunKategoriRepository ?? (_oyunKategoriRepository = new OyunKategoriRepository(_transaction));
            }
        }

        public IRepository<Oyun> OyunRepository
        {
            get
            {
                return _oyunRepository ?? (_oyunRepository = new OyunRepository(_transaction));
            }
        }

        public IRepository<Market> MarketRepository
        {
            get
            {
                return _marketRepository ?? (_marketRepository = new MarketRepository(_transaction));
            }
        }

        public IRepository<Kategori> KategoriRepository
        {
            get
            {
                return _kategoriRepository ?? (_kategoriRepository = new KategoriRepository(_transaction));
            }
        }

        public IRepository<ItemResim> ItemResimRepository
        {
            get
            {
                return _itemResimRepository ?? (_itemResimRepository = new ItemResimRepository(_transaction));
            }
        }

        public IRepository<Item> ItemRepository
        {
            get
            {
                return _itemRepository ?? (_itemRepository = new ItemRepository(_transaction));
            }
        }

        public IRepository<Kiyafet> KiyafetRepository
        {
            get
            {
                return _kiyafetRepository ?? (_kiyafetRepository = new KiyafetRepository(_transaction));
            }
        }

        public IRepository<Silah> SilahRepository
        {
            get
            {
                return _silahRepository ?? (_silahRepository = new SilahRepository(_transaction));
            }
        }

        public IRepository<Boost> BoostRepository
        {
            get
            {
                return _boostRepository ?? (_boostRepository = new BoostRepository(_transaction));
            }
        }

        public UnitOfWork(IConfiguration config)
        {
            _config = config;
            _connection = new SqlConnection(_config.GetConnectionString("MyConnectionString"));
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }


        private void ResetRepositories()
        {
            _yapimciRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
