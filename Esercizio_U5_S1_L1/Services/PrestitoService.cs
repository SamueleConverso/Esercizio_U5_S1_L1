using Esercizio_U5_S1_L1.Data;
using Esercizio_U5_S1_L1.Models;
using Esercizio_U5_S1_L1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_U5_S1_L1.Services {
    public class PrestitoService {
        private readonly Esercizio_U5_S1_L1_EfCore _context;

        public PrestitoService(Esercizio_U5_S1_L1_EfCore context) {
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

        public async Task<PrestitoViewModel> GetAllPrestitiAsync() {
            try {
                var prestitoList = new PrestitoViewModel();

                prestitoList.Prestiti = await _context.Prestiti.Include(p => p.Book).ThenInclude(p => p.Genere).ToListAsync();

                return prestitoList;
            } catch {
                return new PrestitoViewModel() { Prestiti = new List<Prestito>() };
            }
        }

        public async Task<bool> AddPrestitoAsync(Guid id) {

            var prestito = new Prestito() {
                IdBook = id,
            };

            _context.Prestiti.Add(prestito);

            return await SaveAsync();
        }

        public async Task<bool> RemovePrestitoAsync(int idPrestito) {

            var prestito = await _context.Prestiti.FindAsync(idPrestito);

            if (prestito == null) {
                return false;
            }

            _context.Prestiti.Remove(prestito);

            return await SaveAsync();
        }
    }
}
