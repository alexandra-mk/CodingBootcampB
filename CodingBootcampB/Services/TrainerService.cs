using CodingBootcampB.RepositoryServices.TrainerRepository;
using CodingBootcampB.Views.TrainerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Services
{
    class TrainerService : IService
    {
        public void ReadingService()
        {
            try
            {
                TrainerRepository repo = new TrainerRepository();
                PrintTrainer print = new PrintTrainer();
                var trainers = repo.GetAll();
                print.PrintList(trainers);
            }
            catch
            {
                throw new Exception("ERROR READING TRAINER SERVICE");
            }

        }

        public void CreatingService()
        {
            try
            {
                TrainerRepository repo = new TrainerRepository();
                InputTrainer input = new InputTrainer();
                var trainer = input.GetData();
                repo.Add(trainer);
            }
            catch
            {

                throw new Exception("ERROR CREATING TRAINER SERVICE");
            }
        }

        public void UpdatingService()
        {
            try
            {
                TrainerRepository rep = new TrainerRepository();
                InputTrainer input = new InputTrainer();
                Trainer trainer = input.GetDataToUpdate();
                if (trainer != null)
                {
                    rep.Update(trainer);
                }
            }
            catch
            {

                throw new Exception("ERROR UPDATING TRAINER SERVICE");
            }
        }

        public void DeletingService()
        {
            try
            {
                TrainerRepository rep = new TrainerRepository();
                InputTrainer input = new InputTrainer();
                int id = input.GetIDToDeleteOrUpdate("delete");
                rep.Delete(id);
            }
            catch
            {
                throw new Exception("ERROR DELETING TRAINER SERVICE");
            }

        }
    }
}
