using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace bpkp_fe.Models
{
    public class MsStorageLocation
    {
        [Key]
        public string LocationId { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
    }
}
