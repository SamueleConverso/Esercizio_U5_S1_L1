using Esercizio_U5_S1_L1.Services;
using Esercizio_U5_S1_L1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_U5_S1_L1.Controllers {
    public class PrestitoController : Controller {
        private readonly PrestitoService _prestitoService;
        private readonly BookService _bookService;

        public PrestitoController(PrestitoService prestitoService, BookService bookService) {
            _prestitoService = prestitoService;
            _bookService = bookService;
        }

        [HttpGet("prestito")]
        public async Task<IActionResult> Index() {
            var prestitoList = await _prestitoService.GetAllPrestitiAsync();
            return View(prestitoList);
        }

        [HttpGet("prestito/{id:guid}")]
        public async Task<IActionResult> TakeBook(Guid id) {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null) {
                TempData["Error"] = "Libro non trovato!";
                return RedirectToAction("Index", "Book");
            }

            if (!book.Disponibilità) {
                TempData["Error"] = "Libro non disponibile!";
                return RedirectToAction("Index", "Book");
            }

            book.Disponibilità = false;

            var result = await _prestitoService.AddPrestitoAsync(id);

            if (!result) {
                TempData["Error"] = "Errore durante l'aggiunta del libro!";
                return RedirectToAction("Index", "Book");
            }

            return RedirectToAction("Index");
        }

        [HttpGet("remove-prestito/{idPrestito:int}%20{idBook:guid}")]
        public async Task<IActionResult> EndBook(int idPrestito, Guid idBook) {
            var book = await _bookService.GetBookByIdAsync(idBook);

            if (book == null) {
                TempData["Error"] = "Libro non trovato!";
                return RedirectToAction("Index", "Book");
            }

            book.Disponibilità = true;

            var result = await _prestitoService.RemovePrestitoAsync(idPrestito);

            if (!result) {
                TempData["Error"] = "Errore durante l'aggiunta del libro!";
                return RedirectToAction("Index", "Book");
            }

            return RedirectToAction("Index");
        }
    }
}
