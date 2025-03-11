using Microsoft.AspNetCore.Mvc;
using Esercizio_U5_S1_L1.Services;
using System.Threading.Tasks;
using Esercizio_U5_S1_L1.ViewModels;

namespace Esercizio_U5_S1_L1.Controllers {
    public class BookController : Controller {

        private readonly BookService _bookService;

        public BookController(BookService bookService) {
            _bookService = bookService;
        }

        [HttpGet("library")]
        public async Task<IActionResult> Index() {
            var bookList = await _bookService.GetAllBooksAsync();
            return View(bookList);
        }

        [HttpGet("details/{id:guid}")]
        public async Task<IActionResult> Details(Guid id) {

            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null) {
                TempData["Error"] = "Libro non trovato!";
                return RedirectToAction("Index");
            }

            var bookDetailsViewModel = new BookDetailsViewModel() {
                Id = book.Id,
                Title = book.Title,
                Autore = book.Autore,
                Genere = book.Genere,
                Disponibilità = book.Disponibilità
            };

            return View(bookDetailsViewModel);
        }

        [HttpGet("delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) {

            var result = await _bookService.DeleteBookByIdAsync(id);

            if (!result) {
                TempData["Error"] = "Errore durante l'eliminazione del libro!";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("add")]
        public IActionResult Add() {
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel) {

            if (!ModelState.IsValid) {
                TempData["Error"] = "Errore durante l'aggiunta del libro!";
                return RedirectToAction("Index");
            }

            var result = await _bookService.AddBookAsync(addBookViewModel);

            if (!result) {
                TempData["Error"] = "Errore durante l'aggiunta del libro!";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id) {

            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null) {
                TempData["Error"] = "Libro non trovato!";
                return RedirectToAction("Index");
            }

            var editBookViewModel = new EditBookViewModel() {
                Id = book.Id,
                Title = book.Title,
                Autore = book.Autore,
                Genere = book.Genere,
                Disponibilità = book.Disponibilità
            };

            return View(editBookViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBookViewModel) {

            if (!ModelState.IsValid) {
                TempData["Error"] = "Errore durante la modifica del libro!";
                return RedirectToAction("Index");
            }

            var result = await _bookService.UpdateBookAsync(editBookViewModel);

            if (!result) {
                TempData["Error"] = "Errore durante la modifica del libro!";
            }

            return RedirectToAction("Index");
        }
    }
}
