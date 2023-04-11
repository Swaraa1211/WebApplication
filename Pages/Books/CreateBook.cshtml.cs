using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BasicWebApplication.Pages.Books
{
    public class CreateBookModel : PageModel
    {
        Books book = new Books();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
                
            SqlConnection sqlConnection = new SqlConnection("Data Source=5CG7324TYL;Initial Catalog = LMS_DB; Encrypt=False; Integrated Security=True;");
            sqlConnection.Open();

            book.Id = Request.Form["Id"];
            book.BookName = Request.Form["BookName"];
            //book.BookName = "C#";
            book.Category = Request.Form["Category"];
            book.Author = Request.Form["Author"];
            book.Publication = Request.Form["Publication"];
            book.Published_Date = Convert.ToDateTime(Request.Form["Published_Date"]);
            book.Book_Edition = Convert.ToInt32(Request.Form["Book_Edition"]);
            book.Price = Convert.ToInt32(Request.Form["Price"]);

            if(book.Price > 100)
            {
                errorMessage = "The price can't be more than 100";
                return;
            }

             book.Rack_Num = "A1";
             book.Date_Arrival = Convert.ToDateTime("2023-04-01");
             book.Supplier_Id = "S03";
            try
            {
                successMessage = "";
                errorMessage = "";
                string query = $"INSERT INTO LMS_BOOK_DETAILS VALUES" +
                                   $"('{book.Id}','{book.BookName}','{book.Category}'," +
                                   $"'{book.Author}','{book.Publication}','{book.Published_Date}'," +
                                   $"{book.Book_Edition},{book.Price},'{book.Rack_Num}'," +
                                   $"'{book.Date_Arrival}','{book.Supplier_Id}');"; 
                    //SqlCommand command = new SqlCommand(query, sqlConnection);
                Console.WriteLine(query);
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                successMessage = "Book has been added successfully";
             }
            catch (Exception ex)
            {
                    Console.WriteLine("Error: "+ ex.Message);
                    errorMessage = ex.Message;
            }
            

        }
    }
}
