using Esercizio_U5_S1_L1.Data;
using Esercizio_U5_S1_L1.Models;
using Esercizio_U5_S1_L1.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_U5_S1_L1.Services {
    public class GenereService {
        private readonly Esercizio_U5_S1_L1_EfCore _context;

        public GenereService(Esercizio_U5_S1_L1_EfCore context) {
            _context = context;
        }

        public async Task<GeneriViewModel> GetAllGeneriAsync() {
            try {
                var generiList = new GeneriViewModel();

                generiList.Generi = await _context.Generi.ToListAsync();

                return generiList;
            } catch {
                return new GeneriViewModel() { Generi = new List<Genere>() };
            }
        }

    }
}
