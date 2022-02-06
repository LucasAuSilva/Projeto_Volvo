using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class SaleDto
    {
        public int IdSale { get; set; }
        public DateTime Data { get; set; }
        public float SaleValue { get; set; }
        public virtual int idBuyer { get; set; }
        public virtual int idCar { get; set; }
        public virtual int idDealership { get; set; }
        public virtual int idWorker { get; set; }
    }
}