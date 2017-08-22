using System;
using SQLite;
using VTSClient.DAL.Enums;

namespace VTSClient.DAL.Entities
{
    [Table("Vacation")]
    public class Vacation 
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public VacationStatus VacationStatus { get; set; }

        public VacationType VacationType { get; set; }
    }
}
