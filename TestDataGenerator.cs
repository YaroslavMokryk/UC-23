using Bogus;
using CsvHelper;
using System.Globalization;
using UC_23.Models;

namespace UC_23
{
    public class TestDataGenerator
    {
        private static readonly string[] AgeCertifications = { "G", "PG", "PG-13", "R", "NC-17", "U", "U/A", "A", "S", "AL", "6", "9", "12", "12A", "15", "18", "18R", "R18", "R21", "M", "MA15+", "R16", "R18+", "X18", "T", "E", "E10+", "EC", "C", "CA", "GP", "M/PG", "TV-Y", "TV-Y7", "TV-G", "TV-PG", "TV-14", "TV-MA" };
        private static readonly string[] Roles = { "Director", "Producer", "Screenwriter", "Actor", "Actress", "Cinematographer", "Film Editor", "Production Designer", "Costume Designer", "Music Composer" };

        public void GenerateTestData()
        {
            var random = new Random();
            var titleFaker = new Faker<Title>()
                .RuleFor(t => t.Id, f => f.UniqueIndex)
                .RuleFor(t => t.TitleName, f => f.Lorem.Word())
                .RuleFor(t => t.Description, f => f.Lorem.Sentence())
                .RuleFor(t => t.ReleaseYear, f => f.Date.Between(new DateTime(1880, 1, 1), DateTime.Now).Year)
                .RuleFor(t => t.AgeCertification, f => f.PickRandom(AgeCertifications))
                .RuleFor(t => t.Runtime, f => f.Random.Int(60, 240))
                .RuleFor(t => t.Genres, f => string.Join(", ", f.Lorem.Words(random.Next(1, 5))))
                .RuleFor(t => t.ProductionCountry, f => f.Address.CountryCode())
                .RuleFor(t => t.Seasons, f => f.Random.Bool(0.7f) ? (int?)null : f.Random.Int(1, 10));

            var creditFaker = new Faker<Credit>()
                .RuleFor(c => c.Id, f => f.UniqueIndex)
                .RuleFor(c => c.TitleId, f => f.Random.Int(0, 100))
                .RuleFor(c => c.RealName, f => f.Name.FullName())
                .RuleFor(c => c.CharacterName, f => f.Name.FullName())
                .RuleFor(c => c.Role, f => f.PickRandom(Roles));

            var titles = titleFaker.Generate(100);
            var credits = creditFaker.Generate(100);

            WriteToCsv(titles, "Titles.csv");
            WriteToCsv(credits, "Credits.csv");
        }

        private void WriteToCsv<T>(IEnumerable<T> records, string path)
        {
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }
    }
}
