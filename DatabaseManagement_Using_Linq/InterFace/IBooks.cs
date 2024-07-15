using DatabaseManagement_Using_Linq.Model;

namespace DatabaseManagement_Using_Linq.InterFace
{
    public interface IBooks
    {
        public Books AddBook(Books request);
        public List<Books> ViewBook();
        public Books EditBook(Books request);
        public bool DeleteBook(int id);
        public List<Books> GetBooksByCategoryId(int id);
    }
}
