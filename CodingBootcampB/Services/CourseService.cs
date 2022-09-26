using CodingBootcampB.RepositoryServices.CourseRepository;
using CodingBootcampB.Views.CourseView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Services
{
    class CourseService : IService
    {
        public void ReadingService()
        {
            try
            {
                CourseRepository repo = new CourseRepository();
                PrintCourse print = new PrintCourse();
                var courses = repo.GetAll();
                print.PrintList(courses);
            }
            catch
            {
                throw new Exception("ERROR READING COURSE SERVICE");
            }

        }

        public void CreatingService()
        {
            try
            {
                CourseRepository repo = new CourseRepository();
                InputCourse input = new InputCourse();
                var course = input.GetData();
                repo.Add(course);
            }
            catch
            {

                throw new Exception("ERROR CREATING COURSE SERVICE");
            }
        }

        public void UpdatingService()
        {
            try
            {
                CourseRepository rep = new CourseRepository();
                InputCourse input = new InputCourse();
                Course course = input.GetDataToUpdate();
                if (course != null)
                {
                    rep.Update(course);
                }
            }
            catch
            {

                throw new Exception("ERROR UPDATING COURSE SERVICE");
            }
        }
        public void DeletingService()
        {
            try
            {
                CourseRepository rep = new CourseRepository();
                InputCourse input = new InputCourse();
                int id = input.GetIDToDeleteOrUpdate("delete");
                rep.Delete(id);
            }
            catch
            {
                throw new Exception("ERROR DELETING COURSE SERVICE");
            }

        }
    }
}
