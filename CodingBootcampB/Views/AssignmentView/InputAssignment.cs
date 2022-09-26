using CodingBootcampB.RepositoryServices.AssignmentRepository;
using CodingBootcampB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.AssignmentView
{
    class InputAssignment : IInput<Assignment, int>
    {
        public Assignment GetData()
        {
            string title = LearningMaterialService.GetTitle();
            string description = LearningMaterialService.GetDescription();
            DateTime submissionDate = LearningMaterialService.GetSubmissionDate();
            int oralMark = LearningMaterialService.GetOralMark();
            int totalMark = LearningMaterialService.GetTotalMark();
            int courseId = LearningMaterialService.GetCourseID();
            return new Assignment(title, description, submissionDate, oralMark, totalMark, courseId);
        }

        public Assignment GetDataToUpdate()
        {
            int id = GetIDToDeleteOrUpdate("update");
            AssignmentRepository repo = new AssignmentRepository();
            Assignment assignment = repo.GetAll().FirstOrDefault(s => s.ID == id);
            if (assignment == null)
            {
                ApplicationPrint.NotFound404("Assignment", id);
            }
            else
            {
                assignment.Title = LearningMaterialService.GetTitleToUpdate(assignment);
                assignment.Description = GetDescriptionToUpdate(assignment);
                assignment.SubmissionDate = GetSubmissionDateToUpdate(assignment);
                assignment.OralMark = GetOralMarkToUpdate(assignment);
                assignment.TotalMark = GetTotalMarkToUpdate(assignment);
                assignment.CourseID = GetCourseIDToUpdate(assignment);
            }
            return assignment;
        }
        
        public int GetIDToDeleteOrUpdate(string action)
        {
            bool isInt;
            int id;
            string input;
            do
            {
                ApplicationPrint.EnterIDToDeleteOrUpdate("assignment", action);
                input = Console.ReadLine();
                isInt = int.TryParse(input, out id);
            } while (!isInt);

            return id;
        }

        public string GetDescriptionToUpdate(Assignment assignment)
        {
            ApplicationPrint.EnterDataToUpdate("description");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                assignment.Description = LearningMaterialService.GetDescription();
            }
            return assignment.Description;
        }

        public DateTime GetSubmissionDateToUpdate(Assignment assignment)
        {
            ApplicationPrint.EnterDataToUpdate("submission date");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                assignment.SubmissionDate = LearningMaterialService.GetSubmissionDate();
            }
            return assignment.SubmissionDate;
        }

        public int GetOralMarkToUpdate(Assignment assignment)
        {
            ApplicationPrint.EnterDataToUpdate("oral mark");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                assignment.OralMark = LearningMaterialService.GetOralMark();
            }
            return assignment.OralMark;
        }

        public int GetTotalMarkToUpdate(Assignment assignment)
        {
            ApplicationPrint.EnterDataToUpdate("total mark");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                assignment.TotalMark = LearningMaterialService.GetTotalMark();
            }
            return assignment.TotalMark;
        }

        public int GetCourseIDToUpdate(Assignment assignment)
        {
            ApplicationPrint.EnterDataToUpdate("course to the assignment");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                assignment.CourseID = LearningMaterialService.GetCourseID();
            }
            return assignment.CourseID;
        }
    }
}
