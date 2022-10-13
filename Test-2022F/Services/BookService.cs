using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using Test_2022F.Models;

namespace Test_2022F.Services
{
    public class BookService
    {
        public bool IsPublicDomain(Book book)
        {
            // TestNote: Return true if the book was published 75 years ago or more
            DateTime dateTime = DateTime.Now;
            int new_year = dateTime.Year;
            int old_year = book.Published.Year;
            if(new_year-old_year>75)
                return true;
            else
                return false;
                
        }
    }
}