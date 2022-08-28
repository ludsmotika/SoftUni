namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaters = context.Theatres
                                  .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                                  .OrderByDescending(x => x.NumberOfHalls)
                                  .ThenBy(x => x.Name)
                                  .Select(x => new
                                  {
                                      Name = x.Name,
                                      Halls = x.NumberOfHalls,
                                      TotalIncome = Decimal.Parse(x.Tickets.Where(r => r.RowNumber <= 5).Sum(p => p.Price).ToString()),
                                      Tickets = x.Tickets.Where(r => r.RowNumber <= 5).OrderByDescending(p => p.Price).Select(t => new { Price = t.Price, RowNumber = t.RowNumber }).ToArray()
                                  }).ToArray();

            string answer = JsonConvert.SerializeObject(theaters, Formatting.Indented);
            return answer.Trim();
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);
            StringWriter sb = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(PlayExportDTO[]), xmlRoot);

            PlayExportDTO[] plays = context.Plays
                                     .Where(p => p.Rating <= rating)
                                     .OrderBy(x => x.Title)
                                     .ThenByDescending(x => x.Genre)
                                     .Select(x => new PlayExportDTO()
                                     {
                                         Title = x.Title,
                                         Duration = TimeSpan.ParseExact(x.Duration.ToString(), "c", CultureInfo.InvariantCulture).ToString(),
                                         Rating = x.Rating==0 ? "Primier": x.Rating.ToString(),
                                         Genre = x.Genre,
                                         Actors = x.Casts.Where(c => c.IsMainCharacter == true).OrderByDescending(c=>c.FullName).Select(c => new CastExportDTO() { FullName = c.FullName, MainCharacter = $"Plays main character in '{c.Play.Title}'." }).ToList()
                                     })
                                     .ToArray();

            serializer.Serialize(sb, plays, namespaces);
            return sb.ToString().Trim();
        }
    }
}
