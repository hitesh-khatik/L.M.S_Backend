using DatabaseManagement_Using_Linq.Model;

namespace DatabaseManagement_Using_Linq.InterFace
{
    public interface IBooksCategory
    {
        public BooksCategory AddCategory(BooksCategory request);
        public List<BooksCategory> GetBooksCategory();
        public BooksCategory EditBooksCategory(BooksCategory request);
        public bool DeleteBooksCategory(int id);
    }
}
