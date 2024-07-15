using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;

namespace DatabaseManagement_Using_Linq.Service
{
    public class BooksCategoryService : IBooksCategory
    {
        private readonly DataDbContext _sql;

        public BooksCategoryService(DataDbContext IDbContext)
        {
            _sql = IDbContext;
        }

        public BooksCategory AddCategory(BooksCategory request)
        {
            try
            {
            if (_sql.Bookscatagory.Any(u => u.CategoryName == request.CategoryName))
            {
                throw new ArgumentException("Category is already Exists.");
            }
            _sql.Bookscatagory.Add(request);
            _sql.SaveChanges();
            return request;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteBooksCategory(int id)
        {
            bool returval = false;
            try
            {
            var ExistsCat = _sql.Bookscatagory.Find(id);
            if (ExistsCat != null)
            {
                _sql.Bookscatagory.Remove(ExistsCat);
                _sql.SaveChanges();
                returval = true;
                return returval;
            }
            else
            {
                throw new ArgumentException("Category  Not Found.");
               
            }
           }catch (Exception ex)
            {
                throw ex;

            }

        }

        public BooksCategory EditBooksCategory(BooksCategory request)
        {
            try { 
           var ExistCat = _sql.Bookscatagory.Find(request.Catid);
            if (ExistCat != null)
            {
                ExistCat.CategoryName = request.CategoryName;
                _sql.SaveChanges();
                return request;
            }
            else
            {
                throw new ArgumentException("Category Not Found");
            }
            }catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<BooksCategory>GetBooksCategory()
        {
           List<BooksCategory> catlist = new List<BooksCategory>();
            catlist = _sql.Bookscatagory.ToList();  
            return catlist;
        }
    }
}
