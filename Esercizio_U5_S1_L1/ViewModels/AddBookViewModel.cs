using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S1_L1.ViewModels {
    public class AddBookViewModel {
        [Display(Name = "Titolo")]
        [Required(ErrorMessage = "Il titolo è obbligatorio!")]
        [StringLength(200, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 5)]
        public required string Title {
            get; set;
        }

        [Display(Name = "Autore")]
        [Required(ErrorMessage = "L'autore è obbligatorio!")]
        [StringLength(100, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 5)]
        public required string Autore {
            get; set;
        }

        [Display(Name = "Genere")]
        [Required(ErrorMessage = "Il genere è obbligatorio!")]
        //[StringLength(100, ErrorMessage = "La lunghezza deve essere compresa tra {2} e {1}.", MinimumLength = 5)]
        public required int IdGenere {
            get; set;
        }

        [Display(Name = "Disponibilità")]
        [Required]
        public required bool Disponibilità {
            get; set;
        }
    }
}
