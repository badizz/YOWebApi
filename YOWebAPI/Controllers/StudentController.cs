using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YOWebAPI.Models;

namespace YOWebAPI.Controllers
{
    //routeprefix class'lar için, route metodlar için kullanılır
    [RoutePrefix("/ogrenci")]
    public class StudentController : ApiController
    {
        List<StudentModel> model = new List<StudentModel>();

        public StudentController()
        {/*
            model.Add(new StudentModel
            {
                Id = 1,
                Name = "ali",
                Surname = "ozaksut"
            }); model.Add(new StudentModel
            {
                Id = 2,
                Name = "Furkan",
                Surname = "Boz"
            });*/

        }
        [HttpGet]
        [Route("ogrencilerigetir")]
        public List<StudentModel> GetStudents()
        {
            using (StudentContext context = new StudentContext())
            {
                return context.Student.ToList();
            }
        }
        [HttpGet]
        [Route("ogrencigetir/{Id}")]
        public StudentModel GetStudent(int Id)
        {/*
            // sql sorgunun c# tipinde yazım şekli aşağıda
            var selectedStudent = model.FirstOrDefault(degisken => degisken.Id == 2);
            return selectedStudent;
            */
            using (StudentContext context = new StudentContext())
            {
                return context.Student.FirstOrDefault(x => x.Id == Id);
            }

        }
        [HttpPost]
        [Route("ogrenciekle")]
        public bool InsertStudent(StudentModel insertModel)
        {/*
            try
            {
                model.Add(insertModel);
                //throw new Exception();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            */
            using (StudentContext context = new StudentContext())
            {
                try
                {
                    context.Student.Add(insertModel);
                    int result = context.SaveChanges();
                    return result == 1 ? true : false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        [HttpDelete]
        [Route("ogrencisil /{Id}")]
        public bool DeleteStudent(int Id)
        {/*
            var selectedStudent = model.FirstOrDefault(x => x.Id == Id);
            return model.Remove(selectedStudent);*/
            using (StudentContext context = new StudentContext())
            {
                var selectedStudent = context.Student.FirstOrDefault(x => x.Id == Id);
                context.Student.Remove(selectedStudent);
                int result = context.SaveChanges();
                return result == 1 ? true : false;

            }
        }
        [HttpPut]
        [Route("ogrenciguncelle")]
        public bool Update (StudentModel model)
        {
            using (StudentContext context = new StudentContext())
            {
                context.Student.Attach(model);
                context.Entry(model).State = EntityState.Modified;
                int result = context.SaveChanges();
                return result == 1 ? true : false;
            }
        }
    }
}
