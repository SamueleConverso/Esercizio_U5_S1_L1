using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercizio_U5_S1_L1.Models {
    public class Prestito {
        [Key]
        public int IdPrestito {
            get; set;
        }

        [Required]
        public Guid IdBook {
            get; set;
        }

        [ForeignKey("IdBook")]
        public Book Book {
            get; set;
        }

        [Required]
        public DateTime DataPrestito {
            get; set;
        }

        [Required]
        public DateTime DataRestituzione {
            get; set;
        }
    }
}
