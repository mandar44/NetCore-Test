using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proj_3_Github_Test.Models;

namespace Proj_3_Github_Test.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return _dataSource().ToList();
        }

        public BookModel GetBookByID (int ID)
        {
            return _dataSource().Find(x => x.ID == ID);
            //return _dataSource().Where(x => x.ID == ID).FirstOrDefault();

        }

        public List<BookModel> SearchBooks(string Title, string Author)
        {
            
            return _dataSource().Where(X => X.Title.ToLower().Contains(Title.ToString().ToLower()) || X.Author.ToLower().Contains(Author.ToString().ToLower())).ToList();
        }

        private List<BookModel> _dataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { ID = 1, Title = "MVC", Author = "Mandar" },
                new BookModel() { ID = 2, Title = "Dotnet Core", Author = "Mandar" },
                new BookModel() { ID = 3, Title = "Java", Author = "Mangesh" },
                new BookModel() { ID = 4, Title = "C#", Author = "Mangesh" },
                new BookModel() { ID = 5, Title = "Angular", Author = "Milind" },
                new BookModel() { ID = 5, Title = "TypeScript", Author = "Milind" }
            };

        }

    }
}
