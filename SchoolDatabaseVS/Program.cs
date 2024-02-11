using Microsoft.EntityFrameworkCore;
using SchoolDatabaseVS.Models;

namespace SchoolDatabaseVS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Anton Hansson SUT 23
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("School Database Anton");
                Console.ResetColor();

                Console.WriteLine("    1. Visa översikt över all personal.");
                Console.WriteLine("    2. Spara ner ny personal.");
                Console.WriteLine("    3. Visa översikt över studenter.");
                Console.WriteLine("    4. Spara ner ny student.");
                Console.WriteLine("    5. Spara ner betyg.");
                Console.WriteLine("    6. Visa översikt över hur många lärare som jobbar de olika avdelningarna. ");
                Console.WriteLine("    7. Visa en lista på alla aktiva kurser.");
                Console.WriteLine("    8. Visa löneinformation för personal");
                Console.WriteLine("    9. Visa medellön för avdelningar.");
                Console.WriteLine("    10. Avsluta.");

                int cursorPos = 1;

                Console.SetCursorPosition(0, cursorPos);
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("-->");
                Console.ResetColor();
                ConsoleKeyInfo navigator;

                do
                {
                    navigator = Console.ReadKey();
                    Console.SetCursorPosition(0, cursorPos);
                    Console.Write("   ");

                    if (navigator.Key == ConsoleKey.UpArrow && cursorPos > 1)
                    {
                        cursorPos--;
                    }

                    else if (navigator.Key == ConsoleKey.DownArrow && cursorPos < 10)
                    {
                        cursorPos++;
                    }

                    Console.SetCursorPosition(0, cursorPos);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-->");
                    Console.ResetColor();
                } while (navigator.Key != ConsoleKey.Enter);

                

                switch (cursorPos)
                {
                    case 1:
                        ShowPersonalOverview();
                        break;
                    case 2:
                        SaveNewPersonal();
                        break;
                    case 3:
                        ShowStudentOverview();
                        break; 
                    case 4:
                        SaveNewStudent();
                        break;
                    case 5:
                        SaveGrade();
                        break;
                    case 6:
                        ShowHowManyTeachers();
                        break;
                    case 7:
                        ShowActiveCourses();
                        break;
                    case 8:
                        ShowSalaryInformation();
                        break;
                    case 9:
                        ShowAverageSalary();
                        break;                        
                    case 10:
                        Console.WriteLine("Avslutar Programmet.");
                            return;
                    default:
                        Console.Clear();
                        throw new ArgumentException($"Menu option {cursorPos} not available");

                       
                }

            }
            

        }
        static void ShowPersonalOverview()
        {
            
            using SchoolDatabaseDbContext context = new SchoolDatabaseDbContext();
            {
                Console.Clear(); 

                // Hämta all personal från databasen och lagra i en lista
                var anställda = context.Personals.ToList();

               
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Översikt över all personal:");
                Console.ResetColor();
                

                // Loopa igenom varje anställd i listan och skriv ut deras namn, roll, lön och anställningsdatum
                foreach (var person in anställda)
                {
                    Console.WriteLine($"Namn: {person.Namn}, Roll: {person.YrkesRoll}, Lön {person.Löner}, Anställningsdatum {person.AnställningsDatum}");
                }

           
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTryck på Enter för gå tillbaka till menyn.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        static void SaveNewPersonal()
        {
            using (SchoolDatabaseDbContext context = new SchoolDatabaseDbContext())
            {
                try
                {
                    Console.Clear();

                    int nyPersonalId = context.Personals.Max(p => p.PersonalId) + 1;

                    Console.Write("Ange förnamn och efternamn för den nya personalen: ");
                    string nyPersonalNamn = Console.ReadLine();

                    Console.Write("Ange yrkesroll för den nya personalen: ");
                    string nyPersonalYrke = Console.ReadLine();

                    Console.Write("Ange lönen för den nya personalen: ");
                    int nyPersonalLön = int.Parse(Console.ReadLine()); 

                    
                    DateTime anställningsDatum = DateTime.Now;

                    Personal p1 = new Personal()
                    {
                        PersonalId = nyPersonalId,
                        Namn = nyPersonalNamn,
                        YrkesRoll = nyPersonalYrke,
                        AnställningsDatum = anställningsDatum, 
                        Löner = nyPersonalLön,
                        
                    };

                    context.Personals.Add(p1);
                    context.SaveChanges();//Sparar ändringarna som har gjorts

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ny personal har lagts till i databasen");

                    Console.WriteLine("\nTryck på Enter för att gå tillbaka till menyn.");
                    Console.ResetColor();

                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ett fel uppstod: {ex.Message}");

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inre undantag: {ex.InnerException.Message}");
                    }

                    Console.ResetColor();

                    Console.WriteLine("\nTryck på Enter för att gå tillbaka till menyn.");
                    Console.ReadKey();
                }
            }
        }
        static void ShowStudentOverview()
        {
            using SchoolDatabaseDbContext context = new SchoolDatabaseDbContext();
            {
                Console.Clear();

                var studenter = context.Studenters.ToList();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Översikt över alla studenter:");
                Console.ResetColor();
                foreach (var student in studenter)
                {
                    Console.WriteLine($"Namn: {student.Snamn}, Klass: {student.Klass},Personnummer: {student.PersonNummer}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTryck på Enter för gå tillbaka till menyn.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        static void SaveNewStudent()
        {
            using (SchoolDatabaseDbContext context = new SchoolDatabaseDbContext())
            {
                try
                {
                    Console.Clear();

                    int nyStudentId = context.Studenters.Max(s => s.StudentId) + 1;

                    Console.Write("Ange namn för den nya studenten: ");
                    string nyStudentNamn = Console.ReadLine();

                    Console.Write("Ange personnummer för den nya studenten: ");
                    string nyStudentPersonnummer = Console.ReadLine();

                    Console.Write("Ange klass för den nya studenten: ");
                    string nyStudentKlass = Console.ReadLine();

                    Studenter s1 = new Studenter()
                    {
                        StudentId = nyStudentId,
                        Snamn = nyStudentNamn,
                        PersonNummer = nyStudentPersonnummer,
                        Klass = nyStudentKlass
                    };

                    context.Studenters.Add(s1);
                    context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ny student har lagts till i databasen");

                    Console.WriteLine("\nTryck på Enter för gå tillbaka till menyn.");
                    Console.ResetColor();

                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ett fel uppstod: {ex.Message}");

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inre undantag: {ex.InnerException.Message}");
                    }

                    Console.ResetColor();

                    Console.WriteLine("\nTryck på Enter för gå tillbaka till menyn.");
                    Console.ReadKey();
                }
            }
        }

        static void ShowActiveCourses()
        {
            using SchoolDatabaseDbContext context = new SchoolDatabaseDbContext();
            {
                Console.Clear();

                var aktivaKurser = context.Kursers.ToList();

                Console.WriteLine("Aktiva kurser:");
                foreach (var course in aktivaKurser)
                {
                    Console.WriteLine($"Kursnamn: {course.KursNamn}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTryck på Enter för gå tillbaka till menyn.");
                Console.ResetColor();
                Console.ReadKey();
            }   

        }
        static void ShowSalaryInformation()
        {
            using (SchoolDatabaseDbContext context = new SchoolDatabaseDbContext())
            {
                Console.Clear();

                var lönerPerAvdelning = context.Personals
                    .GroupBy(p => p.YrkesRoll)
                    .Select(g => new
                    {
                        Avdelning = g.Key,
                        TotalaLöner = g.Sum(p => p.Löner)
                    })
                    .ToList();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Löner per avdelning per månad:");
                Console.ResetColor();
                foreach (var avdelning in lönerPerAvdelning)
                {
                    Console.WriteLine($"{avdelning.Avdelning}: {avdelning.TotalaLöner} kr");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTryck på Enter för gå tillbaka till menyn.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        static void ShowAverageSalary()
        {
            using (SchoolDatabaseDbContext context = new SchoolDatabaseDbContext())
            {
                Console.Clear();

                var averageLönerPerAvdelning = context.Personals
                    .GroupBy(p => p.YrkesRoll)
                    .Select(g => new
                    {
                        Avdelning = g.Key,
                        AverageLöner = g.Average(p => p.Löner)//Average för att få medellönen
                    })
                    .ToList();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Medellön per avdelning:");
                Console.ResetColor();
                foreach (var avdelning in averageLönerPerAvdelning)
                {
                    Console.WriteLine($"{avdelning.Avdelning}: {avdelning.AverageLöner} kr");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTryck på Enter för gå tillbaka till menyn.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        static void ShowHowManyTeachers()
        {
            using (SchoolDatabaseDbContext context = new SchoolDatabaseDbContext())
            {
                Console.Clear();
                var LärarePerAvdelning = context.Personals
                    .Where(p => p.YrkesRoll == "Lärare") // Filtrera lärare
                    .GroupBy(p => p.YrkesRoll) // Gruppera personal efter yrkesroll
                    .Select(g => new
                    {
                        Avdelning = g.Key,
                        LärareCount = g.Count()
                    })
                    .ToList();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Antal Lärare");
                Console.ResetColor();
                foreach (var avdelning in LärarePerAvdelning)
                {
                    Console.WriteLine($"{avdelning.Avdelning}: {avdelning.LärareCount}");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTryck på Enter för gå tillbaka till menyn.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void SaveGrade()
        {
            using (SchoolDatabaseDbContext context = new SchoolDatabaseDbContext())
            {
                try
                {
                    Console.Clear();

                    
                    Console.WriteLine("Tillgängliga kurser:");
                    var tillgängligaKurser = context.Kursers.ToList();
                    foreach (var kurser in tillgängligaKurser)
                    {
                        Console.WriteLine($"{kurser.KursId}: {kurser.KursNamn}");
                    }

                    
                    Console.Write("Ange kursens ID för att sätta betyg: ");
                    int kursId = int.Parse(Console.ReadLine());
                    var valdaKurser = context.Kursers.Find(kursId);

                    
                    Console.WriteLine("\nTillgängliga studenter:");
                    var tillgängligaStudenter = context.Studenters.ToList();
                    foreach (var student in tillgängligaStudenter)
                    {
                        Console.WriteLine($"{student.StudentId}: {student.Snamn}");
                    }

                    
                    Console.Write("Ange studentens ID för att sätta betyg: ");
                    int studentId = int.Parse(Console.ReadLine());
                    var valdStudent = context.Studenters.Find(studentId);

                    
                    Console.Write("Ange betyg för studenten: ");
                    string betyg = Console.ReadLine();

                    
                    Console.WriteLine("\nTillgängliga lärare:");
                    var tillgängligaLärare = context.Personals.Where(p => p.YrkesRoll == "Lärare").ToList();
                    foreach (var lärare in tillgängligaLärare)
                    {
                        Console.WriteLine($"{lärare.PersonalId}: {lärare.Namn}");
                    }

                    
                    Console.Write("Ange lärarens ID som sätter betyget: ");
                    int lärarId = int.Parse(Console.ReadLine());
                    var valdLärare = context.Personals.Find(lärarId);

                    
                    Console.Write("Ange datum för betyget (åååå-mm-dd): ");
                    DateTime date;
                    while (!DateTime.TryParse(Console.ReadLine(), out date)) // Loopa tills ett giltigt datum anges
                    {
                        Console.WriteLine("Ogiltigt datumformat. Ange datumet på formatet åååå-mm-dd:");
                    }

                    // Skapa ett nytt betyg och lägg till det i databasen
                    Betyg nyttBetyg = new Betyg
                    {
                        Betyg1 = betyg,                         
                        StudentId = valdStudent.StudentId,   
                        PersonalId = valdLärare.PersonalId, 
                        KursId = valdaKurser.KursId,         
                        Datum = date                           
                    };

                    context.Betygs.Add(nyttBetyg);
                    context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Betyg har sparats i databasen");

                    Console.WriteLine("\nTryck på Enter för att gå tillbaka till menyn.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ett fel uppstod: {ex.Message}");

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inre undantag: {ex.InnerException.Message}");
                    }

                    Console.ResetColor();

                    Console.WriteLine("\nTryck på Enter för att gå tillbaka till menyn.");
                    Console.ReadKey();
                }
            }
        }

        
    
    }
}