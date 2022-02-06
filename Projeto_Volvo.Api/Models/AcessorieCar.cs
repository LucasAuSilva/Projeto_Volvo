using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Volvo.Api.Models
{
    public class AcessorieCar
    {
        [Key]
        public int IdAcessorieCar { get; set; }

        [ForeignKey("AcessoryId")]
        public virtual Acessory? Acessorie { get; set; }
        [ForeignKey("CarId")]
        public virtual Car? Car { get; set; }
    }
}
