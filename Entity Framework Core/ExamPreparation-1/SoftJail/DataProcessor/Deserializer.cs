namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            DepartmentDTO[] deps = JsonConvert.DeserializeObject<DepartmentDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder(); 

            List<Department> toAdd = new List<Department>();
            foreach (var dep in deps)
            {
                if (!IsValid(dep) || dep.Cells.Count==0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool toSkip = false;
                foreach (var cell in dep.Cells)
                {
                    if (!IsValid(cell))
                    {
                        toSkip = true;
                        break;
                    }
                }
                if (toSkip) 
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                toAdd.Add(new Department() { Name = dep.Name, Cells = dep.Cells.Select(x=> new Cell() {CellNumber = x.CellNumber,HasWindow = x.HasWindow }).ToList() }) ;
                sb.AppendLine($"Imported {dep.Name} with {dep.Cells.Count} cells");
            }

            context.Departments.AddRange(toAdd);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            PrisonerDTO[] prisonerDtos = JsonConvert.DeserializeObject<PrisonerDTO[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (PrisonerDTO prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;
                if (!String.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner p = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = new List<Mail>()
                };

                bool areMailsValid = true;
                foreach (MailDTO mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        areMailsValid = false;
                        continue;
                    }

                    p.Mails.Add(new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if (!areMailsValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                prisoners.Add(p);
                sb.AppendLine($"Imported {p.FullName} {p.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OfficerDTO[]), xmlRootAttribute);
            StringBuilder sb = new StringBuilder();
            StringReader sr = new StringReader(xmlString);
            OfficerDTO[] officerDTOs = (OfficerDTO[])xmlSerializer.Deserialize(sr);
            List<Officer> toAdd = new List<Officer>();
            foreach (var of in officerDTOs)
            {
                if (!IsValid(of))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }



                bool IsPosValid = Enum.TryParse(typeof(Position), of.Position, out object position);
                bool IsWeaValid = Enum.TryParse(typeof(Weapon), of.Weapon, out object weapon);

                if ((!IsPosValid || !IsWeaValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                

                Officer officer = new Officer() 
                {
                    FullName = of.FullName,
                    Salary= of.Salary,
                    Position= (Position)position,
                    Weapon= (Weapon)weapon,
                    DepartmentId= of.DepartmentId
                };

                foreach (var item in of.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner() { OfficerId = officer.Id, PrisonerId= item.Id });
                }

                toAdd.Add(officer);
                sb.AppendLine($"Imported {of.FullName} ({of.Prisoners.Count} prisoners)");
            }

            context.Officers.AddRange(toAdd);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}