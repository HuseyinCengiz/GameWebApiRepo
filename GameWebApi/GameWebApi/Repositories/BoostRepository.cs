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
    public class BoostRepository : RepositoryBase, IRepository<Boost>
    {
        public BoostRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Boost> getAll()
        {
            throw new NotImplementedException();
        }

        public Boost getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Boost entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Boost entity)
        {
            throw new NotImplementedException();
        }
    }
}
