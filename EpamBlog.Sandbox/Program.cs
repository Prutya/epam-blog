using System;
using EpamBlog.Business;

namespace EpamBlog.Sandbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            var authorHelper = new AuthorHelper();

            var authors = authorHelper.GetAll();

            foreach (var author in authors)
            {
                Console.WriteLine(author.Name);
                foreach (var article in author.Articles)
                {
                    Console.WriteLine("\t{0}", article.Title);
                    foreach (var feedback in article.Feedbacks)
                    {
                        Console.WriteLine("\t{0}", feedback.Name);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
