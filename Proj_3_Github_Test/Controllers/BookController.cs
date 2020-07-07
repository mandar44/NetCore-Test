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
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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

        public IActionResult AddNewBook(bool isSuccess = false, int bookID=0, string errorMessage="")
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookID = bookID;
            ViewBag.errorMessage = errorMessage;
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> AddNewBook(Book_Master Book)
        {
            await _bookRepository.AddNewBook(Book);
            if (Book.Book_ID > 0){
                return RedirectToAction("AddNewBook", "Book", new { isSuccess=true, bookID = Book.Book_ID, errorMessage ="" });
            }
            else {
                return RedirectToAction("AddNewBook", "Book", new { isSuccess = false, bookID = -1, errorMessage = "Error" });
            }

        }

    }
}