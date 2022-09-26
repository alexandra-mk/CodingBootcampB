using CodingBootcampB.Entities;
using CodingBootcampB.RepositoryServices;
using CodingBootcampB.Views.StudentsPerCourseView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Services
{
    class StudentsPerCourseService : IService
    {
        public void ReadingService()
        {
            try
            {
                StudentsPerCourseRepository repo = new StudentsPerCourseRepository();
                PrintStudentsPerCourse print = new PrintStudentsPerCourse();
                var students = repo.GetAll();
                print.PrintList(students);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void CreatingService()
        {
            try
            {
                StudentsPerCourseRepository repo = new StudentsPerCourseRepository();
                InputStudentsPerCourse input = new InputStudentsPerCourse();
                var course = input.GetData();
                repo.Add(course);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void UpdatingService()
        {
            try
            {
                StudentsPerCourseRepository rep = new StudentsPerCourseRepository();
                InputStudentsPerCourse input = new InputStudentsPerCourse();
                StudentsPerCourse student = input.GetDataToUpdate();
                if (student != null)
                {
                    rep.Update(student);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeletingService()
        {
            try
            {
                StudentsPerCourseRepository rep = new StudentsPerCourseRepository();
                InputStudentsPerCourse input = new InputStudentsPerCourse();
                StudentsPerCourse student = input.GetDataToDelete();
                if (student != null)
                {
                    rep.Delete(student);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
