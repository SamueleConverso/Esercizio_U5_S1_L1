using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S1_L1.Models {
    public class Book {

        [Key]
        public Guid Id {
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
        [StringLength(100, MinimumLength = 10)]
        public required string Genere {
            get; set;
        }

        [Required]
        public required bool Disponibilità {
            get; set;
        }
    }
}
