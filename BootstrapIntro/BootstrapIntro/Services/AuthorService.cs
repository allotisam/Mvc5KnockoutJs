using BootstrapIntro.Behaviors;
using BootstrapIntro.DAL;
using BootstrapIntro.Models;
using BootstrapIntro.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BootstrapIntro.Services
{
    public class AuthorService : IDisposable
    {
        private BookContext db = new BookContext();

        public async Task<List<Author>> Get(QueryOptions queryOptions)
        {
            var start = QueryOptionsCalculator.CalculateStart(queryOptions);

            var authors = await db.Authors.OrderBy(queryOptions.Sort).Skip(start).Take(queryOptions.PageSize).ToListAsync();
            queryOptions.TotalPages = QueryOptionsCalculator.CalculateTotalPages(db.Authors.Count(), queryOptions.PageSize);

            return authors;
        }

        public async Task<Author> GetById(long id)
        {
            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                throw new System.Data.Entity.Core.ObjectNotFoundException(string.Format("Unable to find author with id {0}", id));
            }

            return author;
        }

        public async Task<Author> GetByName(string name)
        {
            Author author = await db.Authors.Where(a => a.FirstName + ' ' + a.LastName == name).SingleOrDefaultAsync();
            if (author == null)
            {
                throw new System.Data.Entity.Core.ObjectNotFoundException(string.Format("Unable to find author with name {0}", name));
            }

            return author;
        }

        public void Insert(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public void Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Author author)
        {
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();    
        }
    }
}