using CodingBootcampB.Entities;
using CodingBootcampB.RepositoryServices;
using CodingBootcampB.Views.TrainersPerCourseView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Services
{
    class TrainersPerCourseService : IService
    {
        public void ReadingService()
        {
            try
            {
                TrainersPerCourseRepository repo = new TrainersPerCourseRepository();
                PrintTrainersPerCourse print = new PrintTrainersPerCourse();
                var trainers = repo.GetAll();
                print.PrintList(trainers);
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
                TrainersPerCourseRepository repo = new TrainersPerCourseRepository();
                InputTrainersPerCourse input = new InputTrainersPerCourse();
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
                TrainersPerCourseRepository rep = new TrainersPerCourseRepository();
                InputTrainersPerCourse input = new InputTrainersPerCourse();
                TrainersPerCourse trainer = input.GetDataToUpdate();
                if (trainer != null)
                {
                    rep.Update(trainer);
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
                TrainersPerCourseRepository rep = new TrainersPerCourseRepository();
                InputTrainersPerCourse input = new InputTrainersPerCourse();
                TrainersPerCourse trainer = input.GetDataToDelete();
                if (trainer != null)
                {
                    rep.Delete(trainer);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
