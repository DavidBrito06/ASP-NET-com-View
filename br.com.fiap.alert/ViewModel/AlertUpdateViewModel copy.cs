using System.ComponentModel.DataAnnotations;

namespace br.com.fiap.alert.ViewModel
{
    public class AlertUpdateViewModel
    {

            public string? TypeAlert { get; set; }
            [Required(ErrorMessage = "A observação de desastre é obrigatório.")]
            [Display(Name = "Observação")]
            [StringLength(50, ErrorMessage = "O observação não pode exceder 200 caracteres.")]
            public string? Message { get; set; }
            [Required(ErrorMessage = "A cordenada de desastre é obrigatório.")]
            [Display(Name = "Cordenada")]
            public string? Coords { get; set; }
            [Required(ErrorMessage = " A Author de desastre é obrigatório.")]
            [Display(Name = "Nome do author")]
            public String? Author { get; set; }
       
    }
}
