namespace TruckAPI.Models
{
    public class Truck
    {
        public required Guid Id { get; set; }
        public required string Registration {  get; set; }
        public required double GrossWeight { get; set; }
        public required double TareWeight { get; set; }
        public double NetWeight { get; set; }
        public required string Haulier { get; set; }

    }
}
