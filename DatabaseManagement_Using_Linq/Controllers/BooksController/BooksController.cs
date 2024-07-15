using DatabaseManagement_Using_Linq.Common;
using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseManagement_Using_Linq.Controllers.BooksController
{
    [Route("api/[controller]")]
   // [Authorize]
    [ApiController]
    public class BooksController : ControllerBase
    {
        Response res = new Response();
        IBooks Book;

        public BooksController(IBooks book)
        {
            Book = book;
        }
        [HttpPost("AddBooks")]
        public Response AddBooks(Books request)
        {
            try
            {
                var result = Book.AddBook(request);

                res.Data = result;
                res.ErrorCode = 0;
                res.Message = "Book Adaid Sucessfully";
            }
            catch (Exception ex)
            {
                res.Data = ex.Message;
                res.ErrorCode = 101;
                res.Message = ex.Message;

            }
            return res;
        }
        //[Authorize]
        [HttpGet("ViewBooks")]
        public Response ViewBooks()
        {
            try
            {
                var result = Book.ViewBook();
                res.Data = result;
                res.ErrorCode = 0;
            }
            catch (Exception ex)
            {
                res.ErrorCode = 101;
                res.Message = ex.Message;
            }
            return res;

        }

        [HttpGet("ViewBooksByid")]
        public Response ViewBooksByid(int id)
        {
            try
            {
                var result = Book.GetBooksByCategoryId(id);
                res.Data = result;
                res.ErrorCode = 0;
            }
            catch (Exception ex)
            {
                res.ErrorCode = 101;
                res.Message = ex.Message;
            }
            return res;

        }

        [HttpPut("EditBooks")]
        public Response EditBooks(Books request)
        {
            try
            {
                var result = Book.EditBook(request);

                if (result != null)
                {
                    res.Data = result;
                    res.ErrorCode = 0;
                    res.Message = "Book Edited Sucessfully";
                }

            }
            catch (Exception ex)
            {
                res.ErrorCode = 101;
                res.Message = ex.Message;
            }
            return res;

        }

        [HttpDelete("DeleteBooksCategory")]
        public Response DeleteBooksCategory(int id)
        {
            try
            {
                var result = Book.DeleteBook(id);

                if (result)
                {

                    res.ErrorCode = 0;
                    res.Message = "Book Deleted Sucessfully";
                }

            }
            catch (Exception ex)
            {
                res.ErrorCode = 101;
                res.Message = ex.Message;
            }
            return res;

        }

    }
}
