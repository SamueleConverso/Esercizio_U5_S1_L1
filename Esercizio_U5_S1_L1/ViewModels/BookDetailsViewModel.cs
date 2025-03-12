using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S1_L1.ViewModels {
    public class BookDetailsViewModel {

        public Guid IdBook {
            get; set;
        }


        public string? Title {
            get; set;
        }


        public string? Autore {
            get; set;
        }


        public int IdGenere {
            get; set;
        }

        public string TipoGenere {
            get; set;
        }

        public bool Disponibilità {
            get; set;
        }
    }
}
