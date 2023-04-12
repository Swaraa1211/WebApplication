using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Reflection.Metadata.BlobBuilder;

namespace BasicWebApplication.Pages.Books
{
    public class CreateBookModel : PageModel
    {
        //Books book = new Books();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Books book = new Books();

            SqlConnection sqlConnection = new SqlConnection("Data Source=5CG7324TYL;Initial Catalog = LMS_DB; Encrypt=False; Integrated Security=True;");
            sqlConnection.Open();

            //book.BookCode = Request.Form["BookCode"];
            //book.BookTitle = Request.Form["BookTitle"];
            //book.Category = Request.Form["Category"];
            //book.Author = Request.Form["Author"];
            //book.Publication = Request.Form["Publication"];
            //book.Published_Date = Convert.ToDateTime(Request.Form["Published_Date"]);
            //book.BookEdition = Convert.ToInt32(Request.Form["BookEdition"]);
            //book.Price = Convert.ToDouble(Request.Form["Price"]);

            // book.RackNum = "A1";
            // book.DateArrival = Convert.ToDateTime("2023-04-01");
            // book.SupplierId = "S03";

            //SqlCommand cmd = sqlConnection.CreateCommand();
            //try
            //{
            //    successMessage = "";
            //    errorMessage = "";
            //    cmd.CommandText = $"INSERT INTO LMS_BOOK_DETAILS(BOOK_CODE,BOOK_TITLE,AUTHOR,CATEGORY,PUBLICATION," +
            //                $"PUBLISH_DATE,BOOK_EDITION,PRICE,RACK_NUM,DATE_ARRIVAL,SUPPLIER_ID)  VALUES" +
            //                       $"('{book.BookCode}','{book.BookTitle}','{book.Category}'," +
            //                       $"'{book.Author}','{book.Publication}','{book.Published_Date}'," +
            //                       $"{book.BookEdition},{book.Price},'{book.RackNum}'," +
            //                       $"'{book.DateArrival}','{book.SupplierId}');"; 
            //    cmd.ExecuteNonQuery();
            //    successMessage = "Book has been added successfully";
            // }
            //catch (Exception ex)
            //{
            //        Console.WriteLine("Error: "+ ex.Message);
            //        errorMessage = ex.Message;
            //}

            string BookCode = Request.Form["BookCode"];
            string BookTitle = Request.Form["BookTitle"];
            try
            {
                SqlCommand command = new SqlCommand("INSERT_BOOK", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@bookCode", SqlDbType.VarChar).Value = BookCode;
                command.Parameters.AddWithValue("@bookTitle", SqlDbType.VarChar).Value = BookTitle;
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
