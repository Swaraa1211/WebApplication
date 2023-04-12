using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BasicWebApplication.Pages.Books
{
    public class IndexBookModel : PageModel
    {

        //Books book = new Books();
        public List<Books> BookList = new List<Books>();
        //public static string str = "static";

        public void OnGet()
        {

            try
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=5CG7324TYL;Initial Catalog = LMS_DB; Encrypt=False; Integrated Security=True;");
                sqlConnection.Open();
                string query = "SELECT BOOK_CODE, BOOK_TITLE, AUTHOR, PUBLICATION, PRICE FROM LMS_BOOK_DETAILS";
                SqlCommand command = new SqlCommand(query, sqlConnection) ;

                SqlDataReader reader  = command.ExecuteReader();
                while (reader.Read())
                {
                    Books book = new Books();
                    book.BookCode = (string)reader["BOOK_CODE"];
                    book.BookTitle = (string)reader["BOOK_TITLE"];
                    book.Author = (string)reader["AUTHOR"];
                    book.Publication = (string)reader["PUBLICATION"];
                    book.Price = (double)reader["PRICE"];

                    BookList.Add(book);
                    //Console.WriteLine(BookList);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    public class Books
    {
        public string BookCode { get; set; }

        public string BookTitle { get; set; }

        public string Category { get;set; }

        public string Author { get; set; }

        public string Publication { get; set; }

        public DateTime Published_Date { get; set; }

        public int BookEdition { get; set; }

        public double Price { get; set; }

        public string RackNum { get; set; }

        public DateTime DateArrival { get; set; }

        public string SupplierId { get; set; }
    }
}
