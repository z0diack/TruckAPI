namespace TruckAPI.Models
{
    // Define a class named Truck within the namespace TruckAPI.Models
    public class Truck
    {
        // Properties representing various attributes of a truck

        // Unique identifier for the truck (required)
        public required Guid Id { get; set; }

        // Registration number of the truck (required)
        public required string Registration { get; set; }

        // Gross weight of the truck (required)
        public required double GrossWeight { get; set; }

        // Tare weight of the truck (required)
        public required double TareWeight { get; set; }

        // Net weight of the truck (automatically calculated, not required)
        public double NetWeight { get; set; }

        // Name of the haulier (required)
        public required string Haulier { get; set; }

    }
}