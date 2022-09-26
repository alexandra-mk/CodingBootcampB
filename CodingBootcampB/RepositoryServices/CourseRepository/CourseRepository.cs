using CodingBootcampB.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.RepositoryServices.CourseRepository
{
    class CourseRepository : IRepository<Course, int>
    {
        static readonly string connectionString = @"Server = DESKTOP-Q7S1IN5\SQLEXPRESS;Database = CodingBootcamp; Trusted_Connection = True;";
        public List<Course> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<Course> courses = new List<Course>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Courses", sqlConnection);
                    SqlDataReader readerCourses = cmdSelect.ExecuteReader();

                    while (readerCourses.Read())
                    {
                        Course course = new Course()
                        {
                            ID = readerCourses.GetInt32(0),
                            Title = readerCourses.GetString(1),
                            Stream = readerCourses.GetString(2),
                            Type = readerCourses.GetString(3),
                            StartingDate = readerCourses.GetDateTime(4),
                            EndingDate = readerCourses.GetDateTime(5)
                        };
                        courses.Add(course);
                    }
                    readerCourses.Close();

                    return courses;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL COURSES");
                }
            }
        }

        public void Add(Course course)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO Courses(Title, Stream, Type, StartingDate, EndingDate) VALUES('{course.Title}', '{course.Stream}', '{course.Type}', '{course.StartingDate}', '{course.EndingDate}') ", sqlConnection);
                    int insertedRows = cmdInsert.ExecuteNonQuery();
                    if (insertedRows > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Course", "added", insertedRows);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Update(Course course)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE Courses SET Title = '{course.Title}', Stream = '{course.Stream}'," +
                        $"Type = '{course.Type}', StartingDate = '{course.StartingDate}', " +
                        $"EndingDate = '{course.EndingDate}' WHERE ID = '{course.ID}'", sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Course", "updated", rowsUpdated);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdDelete = new SqlCommand($"DELETE FROM Assignments WHERE CourseID = '{id}'", sqlConnection);
                    int rowsDeleted = cmdDelete.ExecuteNonQuery();
                    cmdDelete = new SqlCommand($"DELETE FROM StudentsPerCourse WHERE CourseID = '{id}'", sqlConnection);
                    rowsDeleted += cmdDelete.ExecuteNonQuery();
                    cmdDelete = new SqlCommand($"DELETE FROM TrainersPerCourse WHERE CourseID = '{id}'", sqlConnection);
                    rowsDeleted += cmdDelete.ExecuteNonQuery();
                    cmdDelete = new SqlCommand($"DELETE FROM Courses WHERE ID = '{id}'", sqlConnection);
                    rowsDeleted += cmdDelete.ExecuteNonQuery();
                   
                    if (rowsDeleted > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Course and all related students, trainers and assignments",
                            "deleted", rowsDeleted);
                    }
                    else
                    {
                        ApplicationPrint.NotFound404("Course", id);
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
