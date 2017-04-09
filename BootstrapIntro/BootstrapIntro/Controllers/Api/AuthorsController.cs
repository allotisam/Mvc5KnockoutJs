using AutoMapper.Mappers;
using BootstrapIntro.DAL;
using BootstrapIntro.Models;
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
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace BootstrapIntro.Controllers.Api
{
    public class AuthorsController : ApiController
    {
        private BookContext db = new BookContext();

        // GET: api/Authors
        public ResultList<AuthorViewModel> Get([FromUri]QueryOptions queryOptions)
        {
            var start = (queryOptions.CurrentPage - 1) * queryOptions.PageSize;
            var authors = db.Authors.OrderBy(queryOptions.Sort).Skip(start).Take(queryOptions.PageSize);

            queryOptions.TotalPages = (int)Math.Ceiling((double)db.Authors.Count() / queryOptions.PageSize);

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Author, AuthorViewModel>();
            });

            return new ResultList<AuthorViewModel>
            {
                QueryOptions = queryOptions,
                Results = AutoMapper.Mapper.Map<List<Author>, List<AuthorViewModel>>(authors.ToList())
            };
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
