using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proj_3_Github_Test.Repository;
using Proj_3_Github_Test.Models;
using System.Reflection.Metadata.Ecma335;
using Proj_3_Github_Test.datamodels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Proj_3_Github_Test.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(BookRepository bookRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
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

            //ViewBag.Languages = new List<string>() { "Marathi", "Hindi", "English" };

            //use ViewBag.Languages directly
            ViewBag.Languages = new SelectList(new List<string>() { "Marathi", "Hindi", "English" });

            //ViewBag.Languages =new SelectList (GetLanguages(),"LanguageID","Language", Optional_Selected_Language);


            return View();
        }

        [HttpPost]
        public async Task <IActionResult> AddNewBook(Book_Master Book)
        {
            if (ModelState.IsValid) { 

                if(Book.BookImage != null)
                {
                    string imagePath = "books/cover/" + Guid.NewGuid().ToString() + Book.BookImage.FileName;
                    string serverImagePath = Path.Combine(_webHostEnvironment.WebRootPath , imagePath);
                    Book.BookImagePath = imagePath;
                    
                    await Book.BookImage.CopyToAsync(new FileStream(serverImagePath,FileMode.Create));
                    Book.BookImage = null;
                }

                await _bookRepository.AddNewBook(Book);
                if (Book.Book_ID > 0){
                    return RedirectToAction("AddNewBook", "Book", new { isSuccess=true, bookID = Book.Book_ID, errorMessage ="" });
                }
                else {
                    return RedirectToAction("AddNewBook", "Book", new { isSuccess = false, bookID = -1, errorMessage = "Error" });
                }
            }

            ViewBag.Languages = new SelectList(new List<string>() { "Marathi", "Hindi", "English" });

            return View();
        }

    }
}