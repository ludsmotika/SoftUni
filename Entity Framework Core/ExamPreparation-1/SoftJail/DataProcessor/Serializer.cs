namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                                  .Where(x => ids.Contains(x.Id))
                                  .OrderBy(x => x.FullName)
                                  .ThenBy(x => x.Id)
                                  .Select(x => new
                                  {
                                      Id = x.Id,
                                      Name = x.FullName,
                                      CellNumber = x.Cell.CellNumber,
                                      Officers = x.PrisonerOfficers.Select(o=> new {OfficerName= o.Officer.FullName, Department=o.Officer.Department.Name }).OrderBy(o=>o.OfficerName).ToList(),
                                      TotalOfficerSalary = Math.Round(x.PrisonerOfficers.Sum(po => po.Officer.Salary), 2)
                                  })
                                  .ToList();

            return JsonConvert.SerializeObject(prisoners);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Prisoners");
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(String.Empty,String.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(PrisonerExportDTO[]),xmlRoot);
            string[] names = prisonersNames.Split(",").ToArray();
            PrisonerExportDTO[] prisoners = context.Prisoners.Where(x=>names.Contains(x.FullName)).OrderBy(x=>x.FullName).ThenBy(x=>x.Id)
                                   .Select(x=> new PrisonerExportDTO
                                   {
                                   Id=x.Id,
                                   Name=x.FullName,
                                   IncarcerationDate= x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture),
                                   EncryptedMessages = x.Mails.Select(m=> new MessagesDTO{Description= String.Join("",m.Description.Reverse()) }) .ToList()
                                   }).ToArray();

            StringWriter sr = new StringWriter();
            serializer.Serialize(sr,prisoners,xmlSerializerNamespaces);
            return sr.ToString().Trim();
        }
    }
}