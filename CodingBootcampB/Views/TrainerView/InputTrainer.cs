using CodingBootcampB.RepositoryServices.TrainerRepository;
using CodingBootcampB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.TrainerView
{
    class InputTrainer : IInput<Trainer, int>
    {
        public Trainer GetData()
        {
            string firstname = HumanService.GetFirstName();
            string lastname = HumanService.GetLastName();
            string subject = HumanService.GetSubject();
            return new Trainer(firstname, lastname, subject);
        }

        public int GetIDToDeleteOrUpdate(string action)
        {

            bool isInt;
            int id;
            string input;
            do
            {
                ApplicationPrint.EnterIDToDeleteOrUpdate("trainer", action);
                input = Console.ReadLine();
                isInt = int.TryParse(input, out id);
            } while (!isInt);

            return id;
        }

        public Trainer GetDataToUpdate()
        {
            int id = GetIDToDeleteOrUpdate("update");
            TrainerRepository repo = new TrainerRepository();
            Trainer trainer = repo.GetAll().FirstOrDefault(s => s.ID == id);
            if (trainer == null)
            {
                ApplicationPrint.NotFound404("Trainer", id);
            }
            else
            {
                trainer.FirstName = HumanService.GetFirstNameToUpdate(trainer);
                trainer.LastName = HumanService.GetLastNameToUpdate(trainer);
                trainer.Subject = GetSubjectToUpdate(trainer);
            }
            return trainer;
        }

        public string GetSubjectToUpdate(Trainer trainer)
        {
            ApplicationPrint.EnterDataToUpdate("subject");
            string answer = Console.ReadLine();
            if (answer.ToUpper() == "Y")
            {
                trainer.Subject = HumanService.GetSubject();
            }
            return trainer.Subject;
        }
    }
}
