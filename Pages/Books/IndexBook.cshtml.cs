using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BasicWebApplication.Pages.Books
{
    public class IndexBookModel : PageModel
    {
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

                var reader  = command.ExecuteReader();
                while (reader.Read())
                {
                    Books book = new Books();
                    book.Id = reader.GetString(0);
                    book.BookName = reader.GetString(1);
                    book.Author = reader.GetString(2);
                    book.Publication = (string)reader["PUBLICATION"];
                    book.Price = (double)reader["PRICE"];

                    BookList.Add(book);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    public class Books
    {
        public string Id { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }
        public string Publication { get; set; }
        public double Price { get; set; }
    }
}
