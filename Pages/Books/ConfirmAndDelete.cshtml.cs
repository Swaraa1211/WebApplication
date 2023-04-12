using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace BasicWebApplication.Pages.Books
{
    public class ConfirmAndDeleteModel : PageModel
    {
        public Books books = new Books();
        public string BookCode = "";
        //public string message = "";
        public void OnGet()
        {
            BookCode = Request.Query["BookCode"];
            
            try
            {
                //string BookId = Request.Query["Id"];//same as form name
                BookCode = Request.Query["BookCode"];
                SqlConnection sqlConnection = new SqlConnection("Data Source=5CG7324TYL;Initial Catalog = LMS_DB; Encrypt=False; Integrated Security=True;");
                sqlConnection.Open();

                SqlCommand command = sqlConnection.CreateCommand();
                command.CommandText = $"SELECT BOOK_CODE,BOOK_TITLE,AUTHOR,CATEGORY,PUBLICATION," +
                    $"PUBLISH_DATE,BOOK_EDITION,PRICE FROM LMS_BOOK_DETAILS WHERE BOOK_CODE = '{BookCode}'";

                //var reader = command.ExecuteReader();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //books.Id = reader.GetString(0);
                    books.BookTitle = (string)reader["BOOK_TITLE"];
                    books.Author = (string)reader["AUTHOR"];
                    books.Category = (string)reader["CATEGORY"];
                    books.Publication = (string)reader["PUBLICATION"];
                    books.Published_Date = (DateTime)reader["PUBLISH_DATE"];
                    books.BookEdition = (int)reader["BOOK_EDITION"];
                    books.Price = (double)reader["PRICE"];

                    //Published_Date = books.Published_Date.ToString("");

                    //Console.WriteLine(DateTime.Parse(books.Published_Date.ToString(), cultureInfo,
                    //       DateTimeStyles.NoCurrentDateDefault));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void OnPost()
        {
            //message = "";
            BookCode = Request.Query["BookCode"];
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=5CG7324TYL;Initial Catalog = LMS_DB; Encrypt=False; Integrated Security=True;");
                sqlConnection.Open();


                SqlCommand cmd = sqlConnection.CreateCommand();
                Console.WriteLine(BookCode);

            
                 
                cmd.CommandText = $"DELETE FROM LMS_BOOK_DETAILS WHERE BOOK_CODE = '{BookCode}'";
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);
                if (rowsAffected > 0)
                {
                    Response.Redirect("/Books/IndexBook");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }




        }
    }
}
