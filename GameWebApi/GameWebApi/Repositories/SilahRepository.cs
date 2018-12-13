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
    public class SilahRepository : RepositoryBase, IRepository<Silah>
    {
        public SilahRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<Silah> getAll()
        {
            throw new NotImplementedException();
        }

        public Silah getById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Silah entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Silah entity)
        {
            throw new NotImplementedException();
        }
    }
}
