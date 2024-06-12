using System.ComponentModel.DataAnnotations;

namespace bpkp_fe.Models
{
    public class MsUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
