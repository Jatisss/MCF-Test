using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace bpkp_be.Models
{
    public class TrBpkb
    {
        [Key]
        public string AgreementNumber { get; set; } = string.Empty;
        public string BpkbNo { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public DateTime BpkbDate { get; set; }
        public string FakturNo { get; set; } = string.Empty;
        public DateTime FakturDate { get; set; }
        public string LocationId { get; set; } = string.Empty;
        public string PoliceNo { get; set; } = string.Empty;
        public DateTime BpkbDateIn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; } = string.Empty;
        public DateTime LastUpdatedOn { get; set; }
    }
}