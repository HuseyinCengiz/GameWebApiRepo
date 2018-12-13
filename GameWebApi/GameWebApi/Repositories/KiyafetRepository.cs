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
    public class KiyafetRepository : RepositoryBase, IRepository<Kiyafet>
    {
        public KiyafetRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Kiyafet> getAll()
        {
            throw new NotImplementedException();
        }

        public Kiyafet getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Kiyafet entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Kiyafet entity)
        {
            throw new NotImplementedException();
        }
    }
}
