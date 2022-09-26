using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingBootcampB.Views
{
    class ViewMenu
    {
        public static void PrintMenu()
        {
            
            const int space = -28;
            const int space2 = -28;
            const int space3 = -32;
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{"  ---VIEW ALL DATA---",space}{"---ADD NEW DATA---",space}{"---UPDATE DATA---",space3}{"---DELETE DATA---",space2}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{ "1. View all students",space}{"10. Add students",space}{"16. Update students",space3}{"22. Delete students",space2}");
            Console.WriteLine($"{"2. View all trainers",space}{"11. Add trainers", space}{"17. Update trainers",space3}{"23. Delete trainers",space2}");
            Console.WriteLine($"{"3. View all courses",space}{"12. Add courses",space}{"18. Update courses",space3}{"24. Delete courses", space2}");
            Console.WriteLine($"{"4. View all assignments", space}{"13. Add assignments",space}{"19. Update assignments",space3}{"25. Delete assignments", space2}");
            Console.WriteLine($"{"5. View students per course", space}{"14. Add students to courses",space}{"20. Update students per course",space3}{"26. Delete students per course",space2}");
            Console.WriteLine($"{"6. View trainers per course", space}{"15. Add trainers to courses", space}{"21. Update trainers per course", space3}{"27. Delete trainers per course",space2}");
            Console.WriteLine($"{"7. View assignments per\n   course", space}");
            Console.WriteLine($"{"8. View assignments per\n   student per course",space}");
            Console.WriteLine($"{"9. View students that\n   belong to more than\n   one courses", space}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("PRESS 0 TO EXIT THE PROGRAM");
            Console.ResetColor();
          
        }


       
    }
}
