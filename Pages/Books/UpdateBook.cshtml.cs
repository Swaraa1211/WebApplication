using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace BasicWebApplication.Pages.Books
{
    public class UpdateBookModel : PageModel
    {
        public Books books = new Books();
        //public string Published_Date = "";
        //public string errorMessage = "";
        //public string successMessage = "";
        public string message = "";
        public string BookId = "";
        public void OnGet()
        {
            //var cultureInfo = new CultureInfo("en-US");
            try
            {
                //string BookId = Request.Query["Id"];//same as form name
                SqlConnection sqlConnection = new SqlConnection("Data Source=5CG7324TYL;Initial Catalog = LMS_DB; Encrypt=False; Integrated Security=True;");
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT BOOK_CODE,BOOK_TITLE,AUTHOR,CATEGORY,PUBLICATION," +
                    $"PUBLIC_DATE,BOOK_EDITION,PRICE FROM LMS_BOOK_DETAILS WHERE BOOK_CODE = '{BookId}'";

                //var reader = command.ExecuteReader();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //books.Id = reader.GetString(0);
                    books.BookName = (string)reader["BOOK_TITLE"];
                    books.Author = (string)reader["AUTHOR"];
                    books.Category = (string)reader["CATEGORY"];
                    books.Publication = (string)reader["PUBLICATION"];
                    books.Published_Date = (DateTime)reader["PUBLISHED_DATE"];
                    books.Book_Edition = (int)reader["BOOK_EDITION"];
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
        //public void OnPost()
        //{

        //    SqlConnection sqlConnection = new SqlConnection("Data Source=5CG7324TYL;Initial Catalog = LMS_DB; Encrypt=False; Integrated Security=True;");
        //    sqlConnection.Open();

        //    //books.Id = Request.Form["id"];
        //    books.BookName = Request.Form["BookName"];
        //    //book.BookName = "C#";
        //    books.Category = Request.Form["Category"];
        //    books.Author = Request.Form["Author"];
        //    books.Publication = Request.Form["Publication"];
        //    books.Published_Date = Convert.ToDateTime(Request.Form["Published_Date"]);
        //    books.Book_Edition = Convert.ToInt32(Request.Form["Book_Edition"]);
        //    books.Price = Convert.ToInt32(Request.Form["Price"]);

        //    //if (books.Price > 100)
        //    //{
        //    //    errorMessage = "The price can't be more than 100";
        //    //    return;
        //    //}

        //    //books.Rack_Num = "A1";
        //    //books.Date_Arrival = Convert.ToDateTime("2023-04-01");
        //    //books.Supplier_Id = "S03";

        //    try
        //    {
        //        successMessage = "";
        //        errorMessage = "";
        //        //string query = $"INSERT INTO LMS_BOOK_DETAILS VALUES" +
        //        //                   $"('{book.Id}','{book.BookName}','{book.Category}'," +
        //        //                   $"'{book.Author}','{book.Publication}','{book.Published_Date}'," +
        //        //                   $"{book.Book_Edition},{book.Price},'{book.Rack_Num}'," +
        //        //                   $"'{book.Date_Arrival}','{book.Supplier_Id}');";


        //        string query = $"UPDATE LMS_BOOK_DETAILS SET BOOK_TITLE = '{books.BookName}'," +
        //                        $"BOOK_CATEGORY='{books.Category}', " +
        //                        $"" +
        //                        $"";
        //        //SqlCommand command = new SqlCommand(query, sqlConnection);
        //        Console.WriteLine(query);
        //        SqlCommand cmd = new SqlCommand(query, sqlConnection);
        //        cmd.ExecuteNonQuery();
        //        successMessage = "Book updated successfully";
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //        errorMessage = ex.Message;
        //    }




        //}
    }
}