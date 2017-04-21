using AutoMapper.Mappers;
using BootstrapIntro.DAL;
using BootstrapIntro.Filters;
using BootstrapIntro.Models;
using BootstrapIntro.Services;
using BootstrapIntro.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace BootstrapIntro.Controllers.Api
{
    public class AuthorsController : ApiController
    {
        private AuthorService authorService;

        public AuthorsController()
        {
            authorService = new AuthorService();

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Author, AuthorViewModel>();
                config.CreateMap<AuthorViewModel, Author>();
            });
        }

        // GET: api/Authors
        public async Task<ResultList<AuthorViewModel>> Get([FromUri]QueryOptions queryOptions)
        {
            var authors = await authorService.Get(queryOptions);
            return new ResultList<AuthorViewModel>(AutoMapper.Mapper.Map<List<Author>, List<AuthorViewModel>>(authors.ToList()), queryOptions);
        }

        // GET: api/Authors/5
        [ResponseType(typeof(AuthorViewModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var author = await authorService.GetById(id);
            return Ok(AutoMapper.Mapper.Map<Author, AuthorViewModel>(author));
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(AuthorViewModel author)
        {
            var model = AutoMapper.Mapper.Map<AuthorViewModel, Author>(author);
            await authorService.Update(model);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Authors
        [ResponseType(typeof(AuthorViewModel))]
        public async Task<IHttpActionResult> Post(AuthorViewModel author)
        {
            var model = AutoMapper.Mapper.Map<AuthorViewModel, Author>(author);
            await authorService.Insert(model);
            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> DeleteAuthor(int id)
        {
            var author = await authorService.GetById(id);
            await authorService.Delete(author);
            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                authorService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
