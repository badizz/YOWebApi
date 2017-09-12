using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YOWebAPI.Models;

namespace YOWebAPI
{
    public class StudentContext : DbContext
    {
        // bizde webconfig içinde connection isimli bir tanımlama yapılmadı.O yüzden çalışmaz
        public StudentContext() : base("Connection")
        {

        }
        public DbSet<StudentModel> Student { get; set; }
    }
}