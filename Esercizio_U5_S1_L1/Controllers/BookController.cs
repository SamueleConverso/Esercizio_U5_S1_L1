using Microsoft.AspNetCore.Mvc;
using Esercizio_U5_S1_L1.Services;
using System.Threading.Tasks;

namespace Esercizio_U5_S1_L1.Controllers {
    public class BookController : Controller {

        private readonly BookService _bookService;

        public BookController(BookService bookService) {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index() {
            var bookList = await _bookService.GetAllBooksAsync();
            return View(bookList);
        }
    }
}
