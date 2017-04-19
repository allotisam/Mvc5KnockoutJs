using AutoMapper.Mappers;
using BootstrapIntro.DAL;
using BootstrapIntro.Filters;
using BootstrapIntro.Models;
using BootstrapIntro.ViewModels;
using BootstrapIntro.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace BootstrapIntro.Controllers
{
    //[RoutePrefix("Writer")]
    public class AuthorsController : Controller
    {
        private BookContext db = new BookContext();
        private AuthorService authorService = new AuthorService();

        // GET: Authors
        [GenerateResultListFilter(typeof(Author), typeof(AuthorViewModel))]
        //[Route("~/Writers")]
        public async Task<ActionResult> Index([Form] QueryOptions queryOptions)
        {
            var start = (queryOptions.CurrentPage - 1) * queryOptions.PageSize;
            var authors = await db.Authors.OrderBy(queryOptions.Sort).Skip(start).Take(queryOptions.PageSize).ToListAsync();

            queryOptions.TotalPages = (int)Math.Ceiling((double)db.Authors.Count() / queryOptions.PageSize);
            ViewData["QueryOptions"] = queryOptions;

            return View(authors.ToList());
        }

        // GET: Authors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                throw new ObjectNotFoundException(string.Format("Unable to find author with id {0}", id));
            }
            return View(author);
        }

        //[Route("Details/{id:int:min(0)?}")]
        //public async Task<ActionResult> GetById(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var author = await authorService.GetById(id.Value);

        //    return View(AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        //}

        //[Route("Details/{name}")]
        //public async Task<ActionResult> GetByName(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var author = await authorService.GetByName(name);

        //    return View(AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        //}

        // GET: Authors/Create
        [BasicAuthorization]
        public ActionResult Create()
        {
            return View("Form", new AuthorViewModel());
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Biography")] AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                AutoMapper.Mapper.Initialize(config =>
                {
                    config.CreateMap<AuthorViewModel, Author>();
                });
                db.Authors.Add(AutoMapper.Mapper.Map<AuthorViewModel, Author>(author));
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        [BasicAuthorization]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                return HttpNotFound();
            }

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Author, AuthorViewModel>();
            });
            return View("Form", AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Biography")] AuthorViewModel author)
        {
            if (ModelState.IsValid)
            {
                AutoMapper.Mapper.Initialize(config =>
                {
                    config.CreateMap<AuthorViewModel, Author>();
                });
                db.Entry(AutoMapper.Mapper.Map<AuthorViewModel, Author>(author)).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Form", author);
        }

        // GET: Authors/Delete/5
        [BasicAuthorization]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Author, AuthorViewModel>();
            });
            return View(AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [BasicAuthorization]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Author author = await db.Authors.FindAsync(id);
            db.Authors.Remove(author);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
