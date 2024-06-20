using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ToolsMenagement.Models;

namespace ToolsMenagement.Controllers
{
    public class TechnologyViewController : Controller
    {
        [Required(ErrorMessage = "Pole nie może być puste.")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Data wymagana.")]
        [DataType(DataType.Date)]
        public DateTime DataUtworzenia { get; set; }

        public List<Narzedzie> Narzedzia { get; set; }

        public List<int> SelectedNarzedziaIds { get; set; }
    }
}
