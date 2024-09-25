namespace Faid.DTOs
{
    public class MoneyDon
    {
        public decimal DonationAmount { get; set; }

        public string DonationFrequency { get; set; } = null!;

        public string FundUsage { get; set; } = null!;
    }
}
