namespace Faid.DTOs
{
    public class FoodCollReq
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? PickupAddress { get; set; }

        public string? FoodType { get; set; }

        public DateOnly? PreferredPickupDate { get; set; }

        public TimeOnly? PreferredPickupTime { get; set; }
    }
}
