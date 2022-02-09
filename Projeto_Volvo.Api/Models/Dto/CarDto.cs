using Projeto_Volvo.Api.Contracts;

namespace Projeto_Volvo.Api.Models.Dto
{
    public class CarDto : IDto<Car>
    {
        public int? IdCar { get; set; }
        public int Kilometrage { get; set; }
        public int Year { get; set; }
        public string? NumberChassis { get; set; }
        public string? Color { get; set; }
        public float Price { get; set; }
        public string? Model { get; set; }
        public string? VersionSystem { get; set; }
        public OwnerDto? Owner { get; set; }

        public Car CreateEntity()
        {
            return new Car()
            {
                Kilometrage = this.Kilometrage,
                Year = this.Year,
                NumberChassis = this.NumberChassis,
                Color = this.Color,
                Price = this.Price,
                Model = this.Model,
                VersionSystem = this.VersionSystem,
                Owner = this.Owner == null ? null : this.Owner.CreateEntity()
            };
        }
    }
}