using EpamBlog.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EpamBlog.DataAccess
{
    public class BlogDbInitializer : DropCreateDatabaseAlways<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            Random rand = new Random();

            var authors = new List<Author>();
            var authorsCount = rand.Next(10, 20);

            for (int i = 0; i < authorsCount; i++)
            {
                authors.Add(new Author()
                {
                    Name = "TEST_AUTHOR_" + i
                });

                var articles = new List<Article>();
                var articlesCount = rand.Next(1, 10);

                for (int j = 0; j < articlesCount; j++)
                {
                    articles.Add(new Article()
                    {
                        Author = authors[i],
                        AuthorId = authors[i].Id,
                        DateTime = DateTime.Now.AddDays(j * -1),
                        Text = "TEST_ARTICLE_TEXT_" + i + "_" + j,
                        Title = "TEST_ARTICLE_TITLE" + +i + "_" + j,
                    });

                    var feedbacks = new List<Feedback>();
                    var feedbacksCount = rand.Next(0, 30);

                    for (int k = 0; k < feedbacksCount; k++)
                    {
                        feedbacks.Add(new Feedback()
                        {
                            Article = articles[j],
                            ArticleId = articles[j].Id,
                            Email = "test" + i + "_" + j + "_" + k + "@test.com",
                            IsPositive = rand.Next(0, 100) >= 50,
                            Text = "TEST_FEEDBACK_TEXT_" + i + "_" + j + "_" + k,
                            Name = "TEST_FEEDBACK_NAME_" + i + "_" + j + "_" + k
                        });
                    }

                    articles[j].Feedbacks = feedbacks;
                }

                authors[i].Articles = articles;

            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
