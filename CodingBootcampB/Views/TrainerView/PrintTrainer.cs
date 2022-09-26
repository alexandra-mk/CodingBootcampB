using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views.TrainerView
{
    class PrintTrainer : IPrint<Trainer>
    {
        public void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"ID",-5}{"Firstname",-15}{"Lastname",-15}{"Subject",-15}");
            Console.ResetColor();
        }
        public void Print(Trainer trainer)
        {
            Console.WriteLine($"{trainer.ID,-5}{trainer.FirstName,-15}{trainer.LastName,-15}{trainer.Subject,-15}");
        }

        public void PrintList(List<Trainer> trainers)
        {
            PrintHeader();
            foreach (var trainer in trainers)
            {
                Print(trainer);
            }
        }
    }
}
