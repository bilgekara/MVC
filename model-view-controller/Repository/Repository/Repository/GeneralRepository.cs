using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Repository
{
    public class GeneralRepository
    {
        RepositoryContext _context;
        public GeneralRepository()
        {
            _context = new RepositoryContext();
        }
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity); _context.SaveChanges();
        }
        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity); _context.SaveChanges();
        }
        public void Update<TEntity>(int Id,TEntity updateEntity) where TEntity : class
        {
            TEntity orginalEntity = _context.Set<TEntity>().Find(Id);
            _context.Entry(orginalEntity).CurrentValues.SetValues(updateEntity);
        }
        public TEntity Get<TEntity>(int Id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(Id);
        }
        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().ToList();
        }
    }
    class Kullanimi
    {
        public void method()
        {
            GeneralRepository repo = new GeneralRepository();
            repo.Add<Ogrenci>(new Ogrenci());
            repo.Update<Ogrenci>(10, new Ogrenci());
            Ogrenci o = new Ogrenci();
            o.FullName = "Bilge";
            repo.Update<Ogrenci>(10, o);
            repo.Get<Ogrenci>(10);
            repo.GetAll<Ogrenci>();
        }
    }
}