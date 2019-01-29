namespace HealthInsurance.Core.Entities
{
    public class OfficeReview : Review
    {
        public Office Recipient { get; set; }
        public int RecipientId { get; set; }
    }
}
