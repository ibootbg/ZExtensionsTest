using System.ComponentModel.DataAnnotations;

namespace ZExtensionsTest
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Address { get; set; }
    }
}