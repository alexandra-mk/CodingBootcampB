using CodingBootcampB.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.RepositoryServices.AssignmentRepository
{
    class AssignmentRepository : IRepository<Assignment, int>
    {
        static readonly string connectionString = @"Server = DESKTOP-Q7S1IN5\SQLEXPRESS;Database = CodingBootcamp; Trusted_Connection = True;";
        public List<Assignment> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<Assignment> assignments = new List<Assignment>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Assignments", sqlConnection);
                    SqlDataReader readerAssignments = cmdSelect.ExecuteReader();

                    while (readerAssignments.Read())
                    {
                        Assignment assignment = new Assignment()
                        {
                            ID = readerAssignments.GetInt32(0),
                            Title = readerAssignments.GetString(1),
                            Description = readerAssignments.GetString(2),
                            SubmissionDate = readerAssignments.GetDateTime(3),
                            OralMark = readerAssignments.GetInt32(4),
                            TotalMark = readerAssignments.GetInt32(5),
                            CourseID = readerAssignments.GetInt32(6)
                        };
                        assignments.Add(assignment);
                    }
                    readerAssignments.Close();

                    return assignments;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL ASSIGNMENTS");
                }
            }
        }

        public void Add(Assignment assignment)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO Assignments(Title, Description, SubmissionDate, OralMark, TotalMark, CourseID) VALUES('{assignment.Title}', '{assignment.Description}', '{assignment.SubmissionDate}', '{assignment.OralMark}', '{assignment.TotalMark}', '{assignment.CourseID}') ", sqlConnection);
                    int insertedRows = cmdInsert.ExecuteNonQuery();
                    if (insertedRows > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Assignment", "added", insertedRows);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Update(Assignment assignment)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE Assignments SET Title = '{assignment.Title}', Description = '{assignment.Description}'," +
                        $"SubmissionDate = '{assignment.SubmissionDate}', OralMark = '{assignment.OralMark}', " +
                        $"TotalMark = '{assignment.TotalMark}', CourseID = '{assignment.CourseID}' WHERE ID = '{assignment.ID}'", sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Assignment", "updated", rowsUpdated);
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
                    SqlCommand cmdDelete = new SqlCommand($"DELETE FROM Assignments WHERE ID = '{id}'", sqlConnection);
                    int rowsDeleted = cmdDelete.ExecuteNonQuery();
                    if (rowsDeleted > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Assignment", "deleted", rowsDeleted);
                    }
                    else
                    {
                        ApplicationPrint.NotFound404("Assignment", id);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public List<Assignment> GetAssignmentsPerCourse()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<Assignment> assignments = new List<Assignment>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT Assignments.Title, Courses.Title FROM Assignments INNER JOIN Courses ON Assignments.CourseID = Courses.ID ORDER BY Courses.Title DESC", sqlConnection);
                    SqlDataReader readerAssignments = cmdSelect.ExecuteReader();

                    while (readerAssignments.Read())
                    {
                        Assignment assignment = new Assignment()
                        {
                            Title = readerAssignments.GetString(0),
                            Course = new Course() { Title = readerAssignments.GetString(1) }
                        };
                        assignments.Add(assignment);
                    }
                    readerAssignments.Close();

                    return assignments;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL ASSIGNMENTS PER COURSE");
                }
            }
        }

        public List<Assignment> GetAssignmentsPerStudentsPerCourse()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<Assignment> assignments = new List<Assignment>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT Assignments.Title, Courses.Title, Students.FirstName, " +
                        "Students.LastName FROM Students INNER JOIN StudentsPerCourse ON " +
                        "Students.ID = StudentsPerCourse.StudentID INNER JOIN Courses ON " +
                        "StudentsPerCourse.CourseID = Courses.ID INNER JOIN Assignments ON " +
                        "Courses.ID = Assignments.CourseID ORDER BY Students.FirstName", sqlConnection);
                    SqlDataReader readerAssignments = cmdSelect.ExecuteReader();
                   
                    while (readerAssignments.Read())
                    {
                        Assignment assignment = new Assignment()
                        {
                            Title = readerAssignments.GetString(0),
                            Course = new Course() { Title = readerAssignments.GetString(1) }
                        };
                        Student student = new Student()
                        {
                            FirstName = readerAssignments.GetString(2),
                            LastName = readerAssignments.GetString(3)
                        };
                        assignment.Course.Students.Add(student);
                        assignments.Add(assignment);
                    }
                    readerAssignments.Close();

                    return assignments;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL ASSIGNMENTS PER COURSE");
                }
            }
        }


       
    }
}
