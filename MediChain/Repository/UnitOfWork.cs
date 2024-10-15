﻿using MediChain.Data;
using MediChain.Repository.IRepository;

namespace MediChain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext db;
        public ICategoryRepository Category { get;private set; }
        public UnitOfWork(AppDbContext _db)
        {
            db = _db;
            Category = new CategoryRepository(db);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}