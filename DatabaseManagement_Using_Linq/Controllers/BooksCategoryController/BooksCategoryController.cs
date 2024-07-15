using DatabaseManagement_Using_Linq.Common;
using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace DatabaseManagement_Using_Linq.Controllers.BooksCategoryController
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class BooksCategoryController : ControllerBase
    {
        Response res = new Response();
        IBooksCategory Category;
        public BooksCategoryController(IBooksCategory category)
        {
            Category = category;
        }
        [HttpPost("AddBooksCategory")]
        public Response AddBooksCategory(BooksCategory request)
        {
            try
            {
                var result = Category.AddCategory(request);

                res.Data = result;
                res.ErrorCode = 0;
                res.Message = "Category Add Sucessfully";
            }
            catch (Exception ex)
            {
                res.Data = ex.Message;
                res.ErrorCode = 101;
                res.Message = ex.Message;

            }
            return res;
        }
        [HttpGet("ViewBooksCategory")]
        public Response GetBooksCategory()
        {

            try
            {
                var result = Category.GetBooksCategory();

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


        [HttpPut("EditBooksCategory")]
        public Response EditBooksCategory(BooksCategory request)
        {
            try
            {
                var result = Category.EditBooksCategory(request);

                if (result != null)
                {
                    res.Data = result;
                    res.ErrorCode = 0;
                    res.Message = "Category Edited Sucessfully";
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
                var result = Category.DeleteBooksCategory(id);

                if (result)
                {
                   
                    res.ErrorCode = 0;
                    res.Message = "Category Deleted Sucessfully";
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
