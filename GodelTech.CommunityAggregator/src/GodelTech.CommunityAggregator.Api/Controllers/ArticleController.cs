using System;
using System.Collections.Generic;
using System.Linq;
using GodelTech.CommunityAggregator.Api.Models;
using GodelTech.CommunityAggregator.Bll.Dto;
using GodelTech.CommunityAggregator.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace GodelTech.CommunityAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IMapper mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            this.articleService = articleService;
            this.mapper = mapper;
        }

        //GET: api/Article
        [HttpGet]
        public ActionResult<IEnumerable<ArticleView>> GetCollection()
        {
            try
            {
                var articles = articleService.GetAllArticles()
                    .Select(item => mapper.Map<ArticleDto, ArticleView>(item)).ToList();

                return Ok(articles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Article/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ArticleView> Get(int id)
        {
            try
            {
                var article = articleService.GetArticle(id);
                var result = mapper.Map<ArticleDto, ArticleView>(article);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Article
        [HttpPost]
        public ActionResult Create([FromBody] ArticleView value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid");
            }

            var article = mapper.Map<ArticleView, ArticleDto>(value);
            articleService.CreateArticle(article);

            return Ok("Object has been created");
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ArticleView value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid");
            }

            var article = mapper.Map<ArticleView, ArticleDto>(value);
            articleService.UpdateArticle(id, article);

            return Ok($"Object (id: {id}) has been updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                articleService.RemoveArticle(id);
                return Ok($"Object (id: {id}) has been deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
