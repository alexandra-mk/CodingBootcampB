using CodingBootcampB.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.RepositoryServices.TrainerRepository
{
    class TrainerRepository : IRepository<Trainer, int>
    {
        static readonly string connectionString = @"Server = DESKTOP-Q7S1IN5\SQLEXPRESS;Database = CodingBootcamp; Trusted_Connection = True;";
        public List<Trainer> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    List<Trainer> trainers = new List<Trainer>();
                    SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Trainers", sqlConnection);
                    SqlDataReader readerTrainers = cmdSelect.ExecuteReader();

                    while (readerTrainers.Read())
                    {
                        Trainer trainer = new Trainer()
                        {
                            ID = readerTrainers.GetInt32(0),
                            FirstName = readerTrainers.GetString(1),
                            LastName = readerTrainers.GetString(2),
                            Subject = readerTrainers.GetString(3)
                        };
                        trainers.Add(trainer);
                    }
                    readerTrainers.Close();

                    return trainers;

                }
                catch
                {
                    throw new Exception("ERROR GET ALL TRAINERS");
                }
            }
        }

        public void Add(Trainer trainer)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO Trainers(FirstName, LastName, Subject) VALUES('{trainer.FirstName}', '{trainer.LastName}', '{trainer.Subject}') ", sqlConnection);
                    int insertedRows = cmdInsert.ExecuteNonQuery();
                    if (insertedRows > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Trainer", "added", insertedRows);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Update(Trainer trainer)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE Trainers SET FirstName = '{trainer.FirstName}', LastName = '{trainer.LastName}'," +
                        $"Subject = '{trainer.Subject}' WHERE ID = '{trainer.ID}'", sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Trainer", "updated", rowsUpdated);
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
                    SqlCommand cmdDelete = new SqlCommand($"DELETE FROM TrainersPerCourse WHERE TrainerID = '{id}'", sqlConnection);
                    int rowsDeleted = cmdDelete.ExecuteNonQuery();
                    cmdDelete = new SqlCommand($"DELETE FROM Trainers WHERE ID = '{id}'", sqlConnection);
                    rowsDeleted += cmdDelete.ExecuteNonQuery();
                    if (rowsDeleted > 0)
                    {
                        ApplicationPrint.SuccessfullAction("Trainer", "deleted", rowsDeleted);
                    }
                    else
                    {
                        ApplicationPrint.NotFound404("Trainer", id);
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
