using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseManagement_Using_Linq.Model
{
    public class Account
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int AccountId { get; set; }
        public int CustId { get; set; }
        public string Accountno { get; set; }
        public string Accounttype { get; set;}
        public string AccountStatus { get; set;}
        public DateTime CteateDate { get; set; }
        public DateTime UpdateDate { get; set;}

    }
}
