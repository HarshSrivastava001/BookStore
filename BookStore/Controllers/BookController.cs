using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class BookController : ApiController
    {
        IRepository<Book> _repository=new Repository();
        // GET api/Book
        public IEnumerable<Book> Get()
        {
            try
            {
                IEnumerable<Book> books = _repository.GetAllAsync();
                return books;
            }
            catch (Exception ex) 
            { 
             throw ex;
            }
           
        }

        // GET api/Book/5
        public Book Get(int id)
        {
            try
            {
                Book book = _repository.GetByIdAsync(id);
                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // POST api/Book
        public void Post( Book book)
        {
            try
            {
                _repository.AddAsync(book);
            }
             catch (Exception ex) 
            {
                throw ex;
            }
        }

        // PUT api/Book/5
        public void Put(Book book)
        {
            try
            {
                _repository.UpdateAsync(book);
            }
             catch (Exception ex) 
 {
                throw ex;
            }
           
        }

        // DELETE api/Book/5
        public void Delete(int id)
        {
            try
            {
                _repository.DeleteAsync(id);
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}