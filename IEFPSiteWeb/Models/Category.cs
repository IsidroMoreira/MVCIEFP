using System.ComponentModel.DataAnnotations;

namespace IEFPSiteWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "O Campo é de Preenchimento Obrigatório")] /*Mudar mensagem de Validação*/
        public string Name { get; set; } = null!;

        [Display(Name = "Display Order")] /*Mudar mensagem de Validação*/
        [Range(1,100, ErrorMessage ="Display order must be betwen 1 and 100")]
        public int DisplayOrder { get; set; }


        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
