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

        private async Task<bool> SaveAsync() {
            try {
                var rows = await _context.SaveChangesAsync();

                if (rows > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch {
                return false;
            }
        }

        public async Task<BookViewModel> GetAllBooksAsync() {
            try {
                var bookList = new BookViewModel();

                bookList.Books = await _context.Books.Include(b => b.Genere).ToListAsync();

                return bookList;
            } catch {
                return new BookViewModel() { Books = new List<Book>() };
            }
        }

        public async Task<Book> GetBookByIdAsync(Guid id) {

            var book = await _context.Books.Include(b => b.Genere).FirstOrDefaultAsync(b => b.IdBook == id);

            if (book == null) {
                return null;
            }

            return book;
        }

        public async Task<bool> DeleteBookByIdAsync(Guid id) {

            var book = await _context.Books.FindAsync(id);

            if (book == null) {
                return false;
            }

            _context.Books.Remove(book);

            return await SaveAsync();
        }

        public async Task<bool> AddBookAsync(AddBookViewModel addBookViewModel) {

            var book = new Book() {
                IdBook = Guid.NewGuid(),
                Title = addBookViewModel.Title,
                Autore = addBookViewModel.Autore,
                IdGenere = addBookViewModel.IdGenere,
                Disponibilità = addBookViewModel.Disponibilità
            };

            _context.Books.Add(book);

            return await SaveAsync();
        }

        public async Task<bool> UpdateBookAsync(EditBookViewModel editBookViewModel) {

            var book = await _context.Books.FindAsync(editBookViewModel.IdBook);

            if (book == null) {
                return false;
            }

            book.Title = editBookViewModel.Title;
            book.Autore = editBookViewModel.Autore;
            book.IdGenere = editBookViewModel.IdGenere;
            book.Disponibilità = editBookViewModel.Disponibilità;

            return await SaveAsync();
        }
    }
}
