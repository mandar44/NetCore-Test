using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proj_3_Github_Test.Models;
using Proj_3_Github_Test.datamodels;
using Microsoft.AspNetCore.Mvc;

namespace Proj_3_Github_Test.Repository
{
    public class BookRepository
    {

        private readonly MandarDBContext _databaseContext = null;

        public BookRepository(MandarDBContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task <Book_Master> AddNewBook(Book_Master Book)
        {
            Book_Master newBook = Book;
            await _databaseContext.Book_Master.AddAsync(newBook);
            await _databaseContext.SaveChangesAsync();
            return newBook;
        }

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
