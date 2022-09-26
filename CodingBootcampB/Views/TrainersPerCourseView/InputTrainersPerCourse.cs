using CodingBootcampB.Entities;
using CodingBootcampB.RepositoryServices;
using CodingBootcampB.Services;
using CodingBootcampB.Views.TrainerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.TrainersPerCourseView
{
    class InputTrainersPerCourse : IInputPerCourse<TrainersPerCourse>
    {
        public TrainersPerCourse GetData()
        {
            int trainerID = HumanService.GetTrainerID();
            int courseID = LearningMaterialService.GetCourseID();
            return new TrainersPerCourse(trainerID, courseID);
        }

        public TrainersPerCourse GetDataToUpdate()
        {
            InputTrainer input = new InputTrainer();
            int trainerId = input.GetIDToDeleteOrUpdate("update");
            int id = LearningMaterialService.GetCourseID();
            TrainersPerCourseRepository repo = new TrainersPerCourseRepository();
            TrainersPerCourse trPerCrs = repo.GetAllIdsPerCourse().FirstOrDefault(t => t.TrainerID == trainerId && t.CourseID == id);
            if (trPerCrs == null)
            {
                ApplicationPrint.RegistrationNotFound404();
            }

            return trPerCrs;
        }

        public TrainersPerCourse GetDataToDelete()
        {
            InputTrainer input = new InputTrainer();
            int trainerId = input.GetIDToDeleteOrUpdate("delete");
            int id = LearningMaterialService.GetCourseID();
            TrainersPerCourseRepository repo = new TrainersPerCourseRepository();
            TrainersPerCourse trPerCrs = repo.GetAllIdsPerCourse().FirstOrDefault(t => t.TrainerID == trainerId && t.CourseID == id);
            if (trPerCrs == null)
            {
                ApplicationPrint.RegistrationNotFound404();
            }

            return trPerCrs;
        }
    }
}
