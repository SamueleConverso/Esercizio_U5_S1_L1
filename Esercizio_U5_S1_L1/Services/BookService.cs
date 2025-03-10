using Esercizio_U5_S1_L1.Models;
using Esercizio_U5_S1_L1.Data;
using Esercizio_U5_S1_L1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_U5_S1_L1.Services {
    public class BookService {
        private readonly Esercizio_U5_S1_L1_EfCore _context;

        public BookService(Esercizio_U5_S1_L1_EfCore context) {
            _context = context;
        }

        public async Task<BookViewModel> GetAllBooksAsync() {
            try {
                var bookList = new BookViewModel();

                bookList.Books = await _context.Books.ToListAsync();

                return bookList;
            } catch {
                return new BookViewModel() { Books = new List<Book>() };
            }
        }
    }
}
