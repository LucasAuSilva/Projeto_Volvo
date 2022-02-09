namespace Projeto_Volvo.Api.Models.Dto
{
    public class SalaryDto
    {
        public float SalaryOfMonth { get; set; }
        public ICollection<Sale> Sales { get; set; }

        public SalaryDto(float SalaryOfMonth, ICollection<Sale> Sales)
        {
            this.SalaryOfMonth = SalaryOfMonth;
            this.Sales = Sales;
        }
    }
}