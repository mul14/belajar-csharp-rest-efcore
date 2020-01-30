using System;
using System.Collections;
using System.Collections.Generic;
using BelajarMembuatRESTServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BelajarMembuatRESTServer.Controllers
{
    [Route("/articles")]
    [ApiController]
    public class ArticlesController
    {
        private AppDbContext _appDbContext;

        public ArticlesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // /articles
        [HttpGet]
        public ActionResult<IEnumerable<Article>> Get()
        {
            return _appDbContext.Articles;
        }

        // /articles/32
        [HttpGet("{id}")]
        public ActionResult<Article> Get(int id)
        {
            return _appDbContext.Articles.Find(id);
        }

        // /articles/32
        [HttpPost]
        public ActionResult<Article> Post([FromBody] Article article)
        {
            _appDbContext.Add(article);
            _appDbContext.SaveChanges();

            return article;
        }

        [HttpPatch("{id}")]
        public ActionResult<Article> Update(int id, [FromBody] Article articleRequest)
        {
            var article = _appDbContext.Articles.Find(id);
            article.Title = articleRequest.Title;
            _appDbContext.SaveChanges();

            return article;
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var article = _appDbContext.Articles.Find(id);
            _appDbContext.Attach(article);
            _appDbContext.Remove(article);
            _appDbContext.SaveChanges();

            return $"Menghapus data ID: {id}";
        }
    }
}
