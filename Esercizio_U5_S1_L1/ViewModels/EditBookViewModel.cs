﻿using System.ComponentModel.DataAnnotations;

namespace Esercizio_U5_S1_L1.ViewModels {
    public class EditBookViewModel {
        public required Guid IdBook {
            get; set;
        }


        public required string Title {
            get; set;
        }


        public required string Autore {
            get; set;
        }


        public required int IdGenere {
            get; set;
        }


        public required bool Disponibilità {
            get; set;
        }

        [Display(Name = "Carica immagine")]
        public IFormFile? Image {
            get; set;
        }

        public string? ImagePath {
            get; set;
        }
    }
}
