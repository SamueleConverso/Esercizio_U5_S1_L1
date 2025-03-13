using Microsoft.AspNetCore.Mvc;
using Esercizio_U5_S1_L1.Services;
using System.Threading.Tasks;
using Esercizio_U5_S1_L1.ViewModels;

namespace Esercizio_U5_S1_L1.Controllers {
    public class BookController : Controller {

        private readonly BookService _bookService;
        private readonly GenereService _genereService;

        public BookController(BookService bookService, GenereService genereService) {
            _bookService = bookService;
            _genereService = genereService;
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
                IdBook = book.IdBook,
                Title = book.Title,
                Autore = book.Autore,
                IdGenere = book.IdGenere,
                TipoGenere = book.Genere.TipoGenere,
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
        public async Task<IActionResult> Add() {
            var listGeneri = await _genereService.GetAllGeneriAsync();
            ViewBag.Generi = listGeneri.Generi;
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

        [HttpGet("edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id) {

            var listGeneri = await _genereService.GetAllGeneriAsync();
            ViewBag.Generi = listGeneri.Generi;

            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null) {
                TempData["Error"] = "Libro non trovato!";
                return RedirectToAction("Index");
            }

            var editBookViewModel = new EditBookViewModel() {
                IdBook = book.IdBook,
                Title = book.Title,
                Autore = book.Autore,
                IdGenere = book.IdGenere,
                Disponibilità = book.Disponibilità,
                ImagePath = book.ImagePath
            };

            return View(editBookViewModel);
        }


        [HttpPost("edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, EditBookViewModel editBookViewModel) {

            editBookViewModel.IdBook = id;

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
