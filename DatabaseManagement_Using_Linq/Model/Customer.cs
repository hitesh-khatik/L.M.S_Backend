using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseManagement_Using_Linq.Model
{
    public class Customer
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int CustId { get; set; } 
        public string CustName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate {  get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
