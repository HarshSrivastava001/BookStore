using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices.ComTypes;

namespace BookStore.Models
{
    public class Repository : IRepository<Book>
    {
        private DataTable dt = new DataTable();
        private DBManager db = new DBManager();
        public void AddAsync(Book entity)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
             {
                new SqlParameter("@Author",entity.Author),
                new SqlParameter("@ISBN",entity.ISBN),
                new SqlParameter("@PublishedDate",entity.PublishedDate),
                new SqlParameter("@Title",entity.Title),
                new SqlParameter("@Action",1),
             };
            dt = db.Crud("sp_book", sqlParameters);
        }

        public void  DeleteAsync(int id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
             {
                new SqlParameter("@Id",id),
                new SqlParameter("@Action",4),
             };
            dt = db.Crud("sp_book", sqlParameters);
        }

        public IEnumerable<Book> GetAllAsync()
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Action",2),
            };
            dt = db.Crud("sp_book", sqlParameters);
            List<Book> books=new List<Book>();
            foreach (DataRow dr in dt.Rows)
            {
                books.Add(new Book()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Author = dr["Author"].ToString(),
                    ISBN = dr["ISBN"].ToString(),
                    PublishedDate = Convert.ToDateTime(dr["PublishedDate"]),
                    Title = dr["Title"].ToString()
                });
            }
            return  books;
        }

        public Book GetByIdAsync(int id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Id",id),
                new SqlParameter("@Action",2),
            };
            dt = db.Crud("sp_book", sqlParameters);
            Book book = new Book();
            if(dt!=null && dt.Rows.Count>0)
            {
                book.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                book.Title = dt.Rows[0]["Title"].ToString();
                book.ISBN = dt.Rows[0]["ISBN"].ToString();
                book.Author = dt.Rows[0]["Author"].ToString();
                book.PublishedDate = Convert.ToDateTime(dt.Rows[0]["PublishedDate"]);
            }
            return book;
        }

        public void UpdateAsync(Book entity)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
              {
                new SqlParameter("@Id",entity.Id),
                new SqlParameter("@Author",entity.Author),
                new SqlParameter("@ISBN",entity.ISBN),
                new SqlParameter("@PublishedDate",entity.PublishedDate),
                new SqlParameter("@Title",entity.Title),
                new SqlParameter("@Action",3),
              };
            dt = db.Crud("sp_book", sqlParameters);
        }
    }
}