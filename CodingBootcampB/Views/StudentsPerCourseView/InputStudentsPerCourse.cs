using CodingBootcampB.Entities;
using CodingBootcampB.RepositoryServices;
using CodingBootcampB.Services;
using CodingBootcampB.Views.StudentView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.StudentsPerCourseView
{
    class InputStudentsPerCourse : IInputPerCourse<StudentsPerCourse>
    {
        public StudentsPerCourse GetData()
        {
            int studentID = HumanService.GetStudentID();
            int courseID = LearningMaterialService.GetCourseID();
            return new StudentsPerCourse(studentID, courseID);
        }

        public StudentsPerCourse GetDataToUpdate()
        {
            InputStudent input = new InputStudent();
            int studentId = input.GetIDToDeleteOrUpdate("update");
            int id = LearningMaterialService.GetCourseID();
            StudentsPerCourseRepository repo = new StudentsPerCourseRepository();
            StudentsPerCourse stPerCrs = repo.GetAllIdsPerCourse().FirstOrDefault(s => s.StudentID == studentId && s.CourseID == id);
            if (stPerCrs == null)
            {
                ApplicationPrint.RegistrationNotFound404();
            }
          
            return stPerCrs;
        }

        public StudentsPerCourse GetDataToDelete()
        {
            InputStudent input = new InputStudent();
            int studentId = input.GetIDToDeleteOrUpdate("delete");
            int id = LearningMaterialService.GetCourseID();
            StudentsPerCourseRepository repo = new StudentsPerCourseRepository();
            StudentsPerCourse stPerCrs = repo.GetAllIdsPerCourse().FirstOrDefault(s => s.StudentID == studentId && s.CourseID == id);
            if (stPerCrs == null)
            {
                ApplicationPrint.RegistrationNotFound404();
            }

            return stPerCrs;
        }

    }
}
