using CodingBootcampB.Views;
using CodingBootcampB.Views.StudentView;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.RepositoryServices.StudentRepository
{
    class StudentRepository : IRepository<Student, int>
    {
        static readonly string connectionString = @"Server = DESKTOP-Q7S1IN5\SQLEXPRESS;Database = CodingBootcamp; Trusted_Connection = True;";

        public List<Student> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<Student> students = new List<Student>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Students", sqlConnection);
                    SqlDataReader readerStudents = cmdSelect.ExecuteReader();

                    while (readerStudents.Read())
                    {
                        Student student = new Student()
                        {
                            ID = readerStudents.GetInt32(0),
                            FirstName = readerStudents.GetString(1),
                            LastName = readerStudents.GetString(2),
                            DateOfBirth = readerStudents.GetDateTime(3),
                            TuitionFees = readerStudents.GetDecimal(4)
                        };
                        students.Add(student);
                    }
                    readerStudents.Close();

                    return students;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL STUDENTS");
                }
            }
        }

        public void Add(Student student)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO Students(FirstName, LastName, DateOfBirth, TuitionFees) VALUES('{student.FirstName}', '{student.LastName}', '{student.DateOfBirth}', '{student.TuitionFees}') ", sqlConnection);
                    int insertedRows = cmdInsert.ExecuteNonQuery();
                    if (insertedRows > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Student", "added", insertedRows);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Update(Student student)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE Students SET FirstName = '{student.FirstName}', LastName = '{student.LastName}'," +
                        $"DateOfBirth = '{student.DateOfBirth}', TuitionFees = '{student.TuitionFees}' WHERE ID = '{student.ID}'", sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Student", "updated", rowsUpdated);
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
                    SqlCommand cmdDelete = new SqlCommand($"DELETE FROM StudentsPerCourse WHERE StudentID = '{id}'", sqlConnection);
                    int rowsDeleted = cmdDelete.ExecuteNonQuery();
                    cmdDelete = new SqlCommand($"DELETE FROM Students WHERE ID = '{id}'", sqlConnection);
                    rowsDeleted += cmdDelete.ExecuteNonQuery();
                    if (rowsDeleted > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Student", "deleted", rowsDeleted);
                    }
                    else
                    {
                        ApplicationPrint.NotFound404("Student", id);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public List<Student> GetStudentsInMoreThanOneCourse()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<Student> students = new List<Student>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Students WHERE ID IN(SELECT StudentID FROM " +
                        "StudentsPerCourse GROUP BY StudentID HAVING COUNT(*) > 1)", sqlConnection);
                    SqlDataReader readerStudents = cmdSelect.ExecuteReader();

                    while (readerStudents.Read())
                    {
                        Student student = new Student()
                        {
                            ID = readerStudents.GetInt32(0),
                            FirstName = readerStudents.GetString(1),
                            LastName = readerStudents.GetString(2),
                            DateOfBirth = readerStudents.GetDateTime(3),
                            TuitionFees = readerStudents.GetDecimal(4)
                        };
                        students.Add(student);
                    }
                    readerStudents.Close();

                    return students;

                }
                catch
                {
                    throw new Exception("ERROR GET STUDENTS IN MORE THAN ONE COURSE");
                }
            }
        }



    }
}
