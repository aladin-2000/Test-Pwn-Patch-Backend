using System.ComponentModel.DataAnnotations;

namespace test_Pwn_Pach.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string role { get; set; }

    }
}
