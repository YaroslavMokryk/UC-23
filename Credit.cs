namespace UC_23.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public string RealName { get; set; } = string.Empty;
        public string CharacterName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
