﻿using Microsoft.AspNetCore.Mvc;
using awww_az.Models;

namespace awww_az.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index(int id=1)
        {
            var articles = new  List<Article>
            {
                new Article{
                Id = 1,
                Title = "Artykuł 1",
                Content = "Lorem ipsum...",
                CreationDate = DateTime.Now,
                },
                new Article { 
                Id = 2,
                Title = "Artykuł 2",
                Content = "Lorem ipsum...",
                CreationDate = DateTime.Now,
                },
                new Article {
                Id = 3,
                Title = "Artykuł 3",
                Content = "Lorem ipsum...",
                CreationDate = DateTime.Now,
                }
            };

            return View(articles[id-1]);
        }
    }
}
