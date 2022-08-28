namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(PlayDTO[]), xmlRoot);
            StringReader sr = new StringReader(xmlString);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(String.Empty, String.Empty);
            PlayDTO[] playsDTOs = (PlayDTO[])serializer.Deserialize(sr);
            List<Play> plays = new List<Play>();
            StringBuilder sb = new StringBuilder();

            foreach (var play in playsDTOs)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!Enum.TryParse(typeof(Genre), play.Genre, out object genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                TimeSpan timeSpan = TimeSpan.ParseExact(play.Duration, "c", CultureInfo.InvariantCulture);

                if (timeSpan.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                plays.Add(new Play()
                {
                    Title = play.Title,
                    Duration = timeSpan,
                    Rating = play.Rating,
                    Genre = (Genre)genre,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                });
                sb.AppendLine($"Successfully imported {play.Title} with genre {play.Genre.ToString()} and a rating of {play.Rating}!");
            }
            context.Plays.AddRange(plays);
            context.SaveChanges();
            return sb.ToString().Trim();

        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(CastDTO[]), xmlRoot);
            StringReader sr = new StringReader(xmlString);
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(String.Empty, String.Empty);
            CastDTO[] castsDTOs = (CastDTO[])serializer.Deserialize(sr);
            List<Cast> casts = new List<Cast>();
            StringBuilder sb = new StringBuilder();

            foreach (var item in castsDTOs)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                casts.Add(new Cast()
                {
                    FullName = item.FullName,
                    IsMainCharacter = item.IsMainCharacter,
                    PhoneNumber = item.PhoneNumber,
                    PlayId = item.PlayId
                });
                if (item.IsMainCharacter==true)
                {
                    sb.AppendLine($"Successfully imported actor {item.FullName} as a main character!");
                }
                else
                {
                    sb.AppendLine($"Successfully imported actor {item.FullName} as a lesser character!");
                }
               
            }
            context.Casts.AddRange(casts);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            TheatreDTO[] theatreDTOs = JsonConvert.DeserializeObject<TheatreDTO[]>(jsonString);

            List<Theatre> theatres = new List<Theatre>();
            foreach (var item in theatreDTOs)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre() { Name= item.Name, NumberOfHalls = item.NumberOfHalls,Director= item.Director,Tickets= new List<Ticket>()};

                foreach (var ticket in item.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Ticket tick = new Ticket() { RowNumber = ticket.RowNumber, PlayId = ticket.PlayId, Price = ticket.Price };
                    theatre.Tickets.Add(tick);
                    context.Tickets.Add(tick);
                }

                theatres.Add(theatre);
                sb.AppendLine($"Successfully imported theatre {item.Name} with #{theatre.Tickets.Count} tickets!");
            }
            context.Theatres.AddRange(theatres);
            context.SaveChanges();
            return sb.ToString().Trim();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
