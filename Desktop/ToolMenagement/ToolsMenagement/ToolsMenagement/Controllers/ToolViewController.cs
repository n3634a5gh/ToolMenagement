using System.ComponentModel.DataAnnotations;
using ToolsMenagement.Models;

namespace ToolsMenagement.Controllers
{
    public class ToolViewController
    {
        [Required(ErrorMessage = "Pole wymagane")]
        public string Nazwa { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Φ>0")]
        public double Srednica { get; set; }

        [Required(ErrorMessage = "Kategoria wymagana")]
        public int SelectedKategoriaId { get; set; }

        [Required(ErrorMessage = "Trwałoś wymagana.")]
        [Range(101, int.MaxValue, ErrorMessage = "VALUE: INT>100.")]
        public int Trwalosc { get; set; }

        public List<Kategorium> Kategorie { get; set; }
    }
}