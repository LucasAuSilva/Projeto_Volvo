
namespace Projeto_Volvo.Api.Models.Dto
{
    public class DateDto
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public DateTime CreateEntity()
        {
            return new DateTime(this.Year, this.Month, this.Day);
        }
    }
}