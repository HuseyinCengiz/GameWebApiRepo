using GameWebApi.Entities;
using GameWebApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Yapimci> YapimciRepository { get; }
        IRepository<Video> VideoRepository { get; }
        IRepository<Resim> ResimRepository { get; }
        IRepository<Kullanici> KullaniciRepository { get; }
        IRepository<Satista> SatistaRepository { get; }
        IRepository<SatinAlinanlar> SatinAlinanlarRepository { get; }
        IRepository<OzellikItem> OzellikItemRepository { get; }
        IRepository<Ozellik> OzellikRepository { get; }
        IRepository<OyunKullanici> OyunKullaniciRepository { get; }
        IRepository<OyunKategori> OyunKategoriRepository { get; }
        IRepository<Oyun> OyunRepository { get; }
        IRepository<Market> MarketRepository { get; }
        IRepository<Kategori> KategoriRepository { get; }
        IRepository<ItemResim> ItemResimRepository { get; }
        IRepository<Item> ItemRepository { get; }
        IRepository<Kiyafet> KiyafetRepository { get; }
        IRepository<Silah> SilahRepository { get; }
        IRepository<Boost> BoostRepository { get; }

        void Commit();
    }
}
