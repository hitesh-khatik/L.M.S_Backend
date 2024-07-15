using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseManagement_Using_Linq.Model
{
    public class BooksCategory
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Catid { get; set; }  
        public string CategoryName { get; set; }
    }
}
