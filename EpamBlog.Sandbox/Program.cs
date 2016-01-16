using EpamBlog.DataAccess;
using System;
using static System.Console;

namespace EpamBlog.Sandbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            var uow = new UnitOfWork();

            var authors = uow.AuthorRepository.Get();

            foreach (var author in authors)
            {
                WriteLine(author.Name);
            }

            ReadLine();
        }
    }
}
