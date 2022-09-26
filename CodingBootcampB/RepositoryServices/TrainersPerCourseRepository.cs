using CodingBootcampB.Entities;
using CodingBootcampB.Services;
using CodingBootcampB.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.RepositoryServices
{
    class TrainersPerCourseRepository :IRepository<TrainersPerCourse, TrainersPerCourse>
    {
        static readonly string connectionString = @"Server = DESKTOP-Q7S1IN5\SQLEXPRESS;Database = CodingBootcamp; Trusted_Connection = True;";


        public List<TrainersPerCourse> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<TrainersPerCourse> trainers = new List<TrainersPerCourse>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT Courses.Title, Trainers.FirstName, Trainers.LastName FROM " +
                        "Courses, Trainers, TrainersPerCourse WHERE Courses.ID = TrainersPerCourse.CourseID AND " +
                        "Trainers.ID = TrainersPerCourse.TrainerID ORDER BY Courses.Title", sqlConnection);
                    SqlDataReader readerTrainers = cmdSelect.ExecuteReader();

                    while (readerTrainers.Read())
                    {
                        TrainersPerCourse trPerCrs = new TrainersPerCourse()
                        {
                            Title = readerTrainers.GetString(0),
                            FirstName = readerTrainers.GetString(1),
                            LastName = readerTrainers.GetString(2)
                        };
                        trainers.Add(trPerCrs);
                    }
                    readerTrainers.Close();

                    return trainers;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL TRAINERS PER COURSE");
                }
            }
        }

        public List<TrainersPerCourse> GetAllIdsPerCourse()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<TrainersPerCourse> trainers = new List<TrainersPerCourse>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM TrainersPerCourse", sqlConnection);
                    SqlDataReader readerTrainers = cmdSelect.ExecuteReader();

                    while (readerTrainers.Read())
                    {
                        TrainersPerCourse trPerCrs = new TrainersPerCourse()
                        {
                            TrainerID = readerTrainers.GetInt32(0),
                            CourseID = readerTrainers.GetInt32(1)
                        };
                        trainers.Add(trPerCrs);
                    }
                    readerTrainers.Close();

                    return trainers;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL IDs PER COURSE");
                }
            }
        }

        public void Add(TrainersPerCourse trainersPerCourse)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO TrainersPerCourse(TrainerID, CourseID) VALUES('{trainersPerCourse.TrainerID}', '{trainersPerCourse.CourseID}') ", sqlConnection);
                    int insertedRows = cmdInsert.ExecuteNonQuery();
                    if (insertedRows > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Trainer to course", "added", insertedRows);
                    }
                }
                catch
                {

                    throw new Exception("ERROR ADD TRAINERS PER COURSE");
                }
            }
        }

        public void Update(TrainersPerCourse trainersPerCourse)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    Console.WriteLine("New Course ID");
                    int newId = LearningMaterialService.GetCourseID();
                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE TrainersPerCourse SET CourseID = '{newId}' WHERE TrainerID = '{trainersPerCourse.TrainerID}' AND CourseID = '{trainersPerCourse.CourseID}'", sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    { 
                        ApplicationPrint.SuccessfullAction("Trainer to course", "updated", rowsUpdated);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Delete(TrainersPerCourse trainersPerCourse)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdDelete = new SqlCommand($"DELETE FROM TrainersPerCourse WHERE TrainerID = '{trainersPerCourse.TrainerID}' AND CourseID = '{trainersPerCourse.CourseID}'", sqlConnection);
                    int rowsDeleted = cmdDelete.ExecuteNonQuery();
                    if (rowsDeleted > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Registration", "deleted", rowsDeleted);
                    }
                    else
                    {
                        ApplicationPrint.RegistrationNotFound404();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
