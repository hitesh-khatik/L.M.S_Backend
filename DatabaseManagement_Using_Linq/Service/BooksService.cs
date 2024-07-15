using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;
using System.Collections.Generic;

namespace DatabaseManagement_Using_Linq.Service
{
    public class BooksService : IBooks
    {
        private readonly DataDbContext _sql;

        public BooksService(DataDbContext IdbContext)
        {
            _sql = IdbContext;
        }

        public Books AddBook(Books request)
        {
            try
            {
                if (_sql.books.Any(u => u.Name== request.Name))
                {
                    throw new ArgumentException(" Book already Exists.");
                }
                _sql.books.Add(request);
                _sql.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteBook(int id)
        {
            bool returval = false;
            try
            {
                var ExistsBook = _sql.books.Find(id);
                if (ExistsBook != null)
                {
                    _sql.books.Remove(ExistsBook);
                    _sql.SaveChanges();
                    returval = true;
                    return returval;
                }
                else
                {
                    throw new ArgumentException("Book  Not Found.");

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public Books EditBook(Books request)
        {
            try
            {
                var ExistsBook = _sql.books.Find(request.BookId);
                if (ExistsBook != null)
                {
                    ExistsBook.ImageUrl = request.ImageUrl;
                    ExistsBook.Name = request.Name;
                    ExistsBook.Decription = request.Decription;
                    ExistsBook.Prize = request.Prize;
                    _sql.SaveChanges();
                    return request;
                }
                else
                {
                    throw new ArgumentException("Book Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Books> GetBooksByCategoryId(int id)
        {
            List<Books> bookList = new List<Books>();
            try
            {
                // Perform inner join between Books and BooksCategory
                var booksInCategory = (from book in _sql.books
                                       join category in _sql.Bookscatagory on book.Catid equals category.Catid
                                       where category.Catid == id
                                       select book).ToList();

                if (booksInCategory.Any())
                {
                    bookList.AddRange(booksInCategory); // Add found books to the bookList
                }
                else
                {
                    throw new ArgumentException("No books available for the given category");
                }

                return bookList; // Return the list of books found
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw new Exception("Error retrieving books by category", ex);
            }
        }

        public List<Books> ViewBook()
        {
            List<Books> booklist = new List<Books>();
            booklist = _sql.books.ToList();
            return booklist;
        }
    }
}
