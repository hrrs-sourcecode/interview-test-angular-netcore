using System;
using System.ComponentModel.DataAnnotations;
using TMS.DTO.Shared;

namespace TMS.DTO
{
    public class Tender : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string TenderID { get; set; }
        public string ContractNo { get; set; }
        public string TenderName { get; set; }
        public decimal TenderValue { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ClosingDate { get; set; }     
    }
}
