using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercizio_U5_S1_L1.Models {
    public class Genere {
        [Key]
        public int IdGenere {
            get; set;
        }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public required string TipoGenere {
            get; set;
        }

        [NotMapped]
        public ICollection<Book> Books {
            get; set;
        }
    }
}
