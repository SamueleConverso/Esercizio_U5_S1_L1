using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercizio_U5_S1_L1.Models {
    public class Book {

        [Key]
        public Guid IdBook {
            get; set;
        }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        public required string Title {
            get; set;
        }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public required string Autore {
            get; set;
        }

        [Required]
        public int IdGenere {
            get; set;
        }

        [ForeignKey("IdGenere")]
        public Genere Genere {
            get; set;
        }

        [Required]
        public required bool Disponibilità {
            get; set;
        }
    }
}
