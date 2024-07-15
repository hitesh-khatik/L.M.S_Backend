using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseManagement_Using_Linq.Model
{
    public class Books
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int BookId { get; set; }
      
        public int Catid { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public string Prize { get; set; }
        
    }
}
