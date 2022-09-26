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
    class StudentsPerCourseRepository : IRepository<StudentsPerCourse, StudentsPerCourse>
    {
        static readonly string connectionString = @"Server = DESKTOP-Q7S1IN5\SQLEXPRESS;Database = CodingBootcamp; Trusted_Connection = True;";


        public List<StudentsPerCourse> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<StudentsPerCourse> students = new List<StudentsPerCourse>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT Courses.Title, Students.FirstName, Students.LastName " +
                        "FROM Courses, Students, StudentsPerCourse WHERE Courses.ID = StudentsPerCourse.CourseID AND " +
                        "Students.ID = StudentsPerCourse.StudentID ORDER BY Courses.Title", sqlConnection);
                    SqlDataReader readerStudents = cmdSelect.ExecuteReader();

                    while (readerStudents.Read())
                    {
                        StudentsPerCourse stuPerCrs = new StudentsPerCourse()
                        {
                            Title = readerStudents.GetString(0),
                            FirstName = readerStudents.GetString(1),
                            LastName = readerStudents.GetString(2)
                        };
                        students.Add(stuPerCrs);
                    }
                    readerStudents.Close();

                    return students;

                }
                catch
                {

                    throw new Exception("ERROR GET ALL STUDENTS PER COURSE");
                }

            }
        }

        public List<StudentsPerCourse> GetAllIdsPerCourse()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<StudentsPerCourse> students = new List<StudentsPerCourse>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM StudentsPerCourse", sqlConnection);
                    SqlDataReader readerStudents = cmdSelect.ExecuteReader();

                    while (readerStudents.Read())
                    {
                        StudentsPerCourse stuPerCrs = new StudentsPerCourse()
                        {
                            StudentID = readerStudents.GetInt32(0),
                            CourseID = readerStudents.GetInt32(1)
                        };
                        students.Add(stuPerCrs);
                    }
                    readerStudents.Close();

                    return students;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL IDs PER COURSE");
                }
            }
        }

        public void Add(StudentsPerCourse studentsPerCourse)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO StudentsPerCourse(StudentID, CourseID) VALUES('{studentsPerCourse.StudentID}', '{studentsPerCourse.CourseID}') ", sqlConnection);
                    int insertedRows = cmdInsert.ExecuteNonQuery();
                    if (insertedRows > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Student to course", "added", insertedRows);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Update(StudentsPerCourse studentsPerCourse)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    Console.WriteLine("New Course ID");
                    int newId = LearningMaterialService.GetCourseID();
                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE StudentsPerCourse SET CourseID = '{newId}' WHERE StudentID = '{studentsPerCourse.StudentID}' AND CourseID = '{studentsPerCourse.CourseID}'", sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Student to course", "updated", rowsUpdated);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Delete(StudentsPerCourse studentsPerCourse)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdDelete = new SqlCommand($"DELETE FROM StudentsPerCourse WHERE StudentID = '{studentsPerCourse.StudentID}' AND CourseID = '{studentsPerCourse.CourseID}'", sqlConnection);
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
