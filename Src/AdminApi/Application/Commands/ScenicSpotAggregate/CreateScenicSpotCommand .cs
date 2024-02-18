using MediatR;

namespace AdminApi.Application.Commands.ScenicSpotsAggregate
{
    public class CreateScenicSpotCommand : IRequest<bool>
    {
        public string SpotName { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public decimal TicketPrice { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Images { get; set; }
    }
}
