using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypeAuthTest.Data;
using TypeAuthTest.Repos.Interfaces;

namespace TypeAuthTest.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TypeAuthDbContext context;

        public UnitOfWork(TypeAuthDbContext context)
        {
            this.context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
