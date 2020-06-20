using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proj_3_Github_Test.Repository;
using Proj_3_Github_Test.Models;
using System.Reflection.Metadata.Ecma335;
using Proj_3_Github_Test.datamodels;

namespace Proj_3_Github_Test.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            //_bookRepository = new BookRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<BookModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookModel GetBook(int ID)
        {
            return _bookRepository.GetBookByID(ID);
        }

        public List<BookModel> Search(string Name , string Author)
        {
            return _bookRepository.SearchBooks(Name, Author);
        }

        public IActionResult AddNewBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewBook(Book_Master Book)
        {
            return View();
        }

    }
}