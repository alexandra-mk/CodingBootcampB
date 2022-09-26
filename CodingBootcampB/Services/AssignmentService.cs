using CodingBootcampB.RepositoryServices.AssignmentRepository;
using CodingBootcampB.Views.AssignmentView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Services
{
    class AssignmentService : IService
    {
        public void ReadingService()
        {
            try
            {
                AssignmentRepository repo = new AssignmentRepository();
                PrintAssignment print = new PrintAssignment();
                var assignments = repo.GetAll();
                print.PrintList(assignments);
            }
            catch
            {
                throw new Exception("ERROR READING ASSIGNMENT SERVICE");
            }

        }

        public void CreatingService()
        {
            try
            {
                AssignmentRepository repo = new AssignmentRepository();
                InputAssignment input = new InputAssignment();
                var assignment = input.GetData();
                repo.Add(assignment);
            }
            catch
            {

                throw new Exception("ERROR CREATING ASSIGNMENT SERVICE");
            }
        }

        public void UpdatingService()
        {
            try
            {
                AssignmentRepository rep = new AssignmentRepository();
                InputAssignment input = new InputAssignment();
                Assignment assignment = input.GetDataToUpdate();
                if (assignment != null)
                {
                    rep.Update(assignment);
                }
            }
            catch
            {

                throw new Exception("ERROR UPDATING ASSIGNMENT SERVICE");
            }
        }
        public void DeletingService()
        {
            try
            {
                AssignmentRepository rep = new AssignmentRepository();
                InputAssignment input = new InputAssignment();
                int id = input.GetIDToDeleteOrUpdate("delete");
                rep.Delete(id);
            }
            catch
            {
                throw new Exception("ERROR DELETING ASSIGNMENT SERVICE");
            }

        }

        public void ReadingAssignmentsPerCourseService()
        {
            try
            {
                AssignmentRepository repo = new AssignmentRepository();
                PrintAssignment print = new PrintAssignment();
                var assignments = repo.GetAssignmentsPerCourse();
                print.PrintAssignmentsPerCourse(assignments);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void ReadingAssignmentsPerStudentsPerCourseService()
        {
            try
            {
                AssignmentRepository repo = new AssignmentRepository();
                PrintAssignment print = new PrintAssignment();
                var assignments = repo.GetAssignmentsPerStudentsPerCourse();
                print.PrintAssignmentsPerStudentPerCourse(assignments);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

      

    }
}
