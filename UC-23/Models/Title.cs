namespace UC_23.Models
{
    public class Title
    {
        public int Id { get; set; }
        public string TitleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string AgeCertification { get; set; } = string.Empty;
        public int Runtime { get; set; }
        public string Genres { get; set; } = string.Empty;
        public string ProductionCountry { get; set; } = string.Empty;
        public int? Seasons { get; set; }
    }
}
