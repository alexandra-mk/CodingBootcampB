using CodingBootcampB.RepositoryServices.StudentRepository;
using CodingBootcampB.Views.StudentView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Services
{
    class StudentService : IService
    {
        public void ReadingService()
        {
            try
            {
                StudentRepository repo = new StudentRepository();
                PrintStudent print = new PrintStudent();
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
                StudentRepository repo = new StudentRepository();
                InputStudent input = new InputStudent();
                var student = input.GetData();
                repo.Add(student);
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
                StudentRepository rep = new StudentRepository();
                InputStudent input = new InputStudent();
                Student student = input.GetDataToUpdate();
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
                StudentRepository rep = new StudentRepository();
                InputStudent input = new InputStudent();
                int id = input.GetIDToDeleteOrUpdate("delete");
                rep.Delete(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void ReadingMoreCoursesService()
        {
            try
            {
                StudentRepository repo = new StudentRepository();
                PrintStudent print = new PrintStudent();
                var students = repo.GetStudentsInMoreThanOneCourse();
                print.PrintList(students);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
