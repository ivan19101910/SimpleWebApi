namespace SimpleWebApi.DTOs
{
    public class AccountDTO
    {
        public string Name { get; set; }

        public string? IncidentId { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactEmail { get; set; }
    }
}
