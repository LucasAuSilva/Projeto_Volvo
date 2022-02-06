using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class SaleDto : IDto<Sale>
    {
        public DateTime Data { get; set; }
        public float SaleValue { get; set; }
        public virtual BuyerDto? Buyer { get; set; }
        public virtual CarDto? Car { get; set; }
        public virtual DealershipDto? Dealership { get; set; }
        public virtual WorkerDto? Worker { get; set; }

        public Sale CreateEntity()
        {
            return new Sale()
            {
                Data = this.Data,
                SaleValue = this.SaleValue,
                Buyer = Buyer.CreateEntity(),
                Car = Car.CreateEntity(),
                Dealership = Dealership.CreateEntity(),
                Worker = Worker.CreateEntity(),
            };
        }
    }
}