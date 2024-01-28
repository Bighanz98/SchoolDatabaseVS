using SchoolDatabaseVS.Models;

namespace SchoolDatabaseVS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using SchoolDatabaseDbContext context = new SchoolDatabaseDbContext();
            {
                //Hämta Studenter.
                /*
                Console.WriteLine("Vill du sortera studenternas namn i alfabetisk ordning?");
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nej");

                int userVal = Convert.ToInt32(Console.ReadLine());

                switch (userVal)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Vill du ha en stigande eller fallande ordning?");
                        Console.WriteLine("1. Stigande");
                        Console.WriteLine("2. Fallande");

                        int userValOrdning = Convert.ToInt32(Console.ReadLine());

                        switch (userValOrdning)
                        {
                            case 1:

                                var allaStudenterStigande = context.Studenters.OrderBy(student => student.Snamn).ToList();

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Lista över Studenter i stigande ordning:");
                                Console.ResetColor();

                                foreach (var student in allaStudenterStigande)
                                {
                                    Console.WriteLine($"\nNamn: {student.Snamn}");
                                }
                                break;

                            case 2:

                                var allaStudenterFallande = context.Studenters.OrderByDescending(student => student.Snamn).ToList();

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Lista över Studenter i fallande ordning");
                                Console.ResetColor();

                                foreach (var student in allaStudenterFallande)
                                {
                                    Console.WriteLine($"\nNamn: {student.Snamn}");
                                }
                                break;

                            default:
                                Console.WriteLine("Ogiltigt val för ordning.");
                                break;

                        }
                        break;

                    case 2:

                        var allaStudenter = context.Studenters.ToList();

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Lista över Studenter");
                        Console.ResetColor();

                        foreach (var student in allaStudenter)
                        {
                            Console.WriteLine($"\nNamn: {student.Snamn}");

                        }
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;

                }*/

                //Hämta Studenter i en viss klass.
                /*
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lista över Klasser:");
                Console.ResetColor();

                var allaklasser = context.Studenters.ToList();
                foreach (var student in allaklasser)
                {
                    Console.WriteLine($"\n{student.Klass}");
                }


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nVälj mellan A, B eller C för att se vem som går i vilken klass. ");
                Console.Write(":");
                Console.ResetColor();

                string userVal = Console.ReadLine().ToUpper();             

                    switch (userVal)
                    {
                        case "A":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Lista över studenter i klass A:");
                            Console.ResetColor();
                            var studenterKlassA = context.Studenters
                                .Where(student => student.Klass == "Klass A")
                                .ToList();

                            foreach (var klass in studenterKlassA)
                            {
                                Console.WriteLine($"\nNamn: {klass.Snamn}");
                            }
                            break;

                        case "B":

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Lista över studenter i klass B:");
                            Console.ResetColor();
                            var studenterKlassB = context.Studenters
                                .Where(student => student.Klass == "Klass B")
                                .ToList();

                            foreach (var klass in studenterKlassB)
                            {
                                Console.WriteLine($"\nNamn: {klass.Snamn}");
                            }
                            break;

                        case "C":

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Lista över studenter i klass C:");
                            Console.ResetColor();

                            var studenterKlassC = context.Studenters
                                .Where(student => student.Klass == "Klass C")
                                .ToList();
                            foreach (var klass in studenterKlassC)
                            {
                                Console.WriteLine($"\nNamn: {klass.Snamn}");
                            }
                            break;

                        default:
                            Console.WriteLine("Ogiltig klass.");
                            break;
                    }*/

                //Lägga till ny personal

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Lägg till ny personal");
                Console.ResetColor();

                Console.Write("Ange förnamn och efternamn för den nya personalen: ");
                string nyPersonalNamn = Console.ReadLine();

                Console.Write("Ange yrkesroll för den nya personalen: ");
                string nyPersonalYrke = Console.ReadLine();

                Personal p1 = new Personal()
                {
                    Namn = nyPersonalNamn,
                    YrkesRoll = nyPersonalYrke
                };

                context.Personals.Add(p1);
                context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ny personal har lagts till i databasen");
                Console.ResetColor();

                Console.ReadKey();

               
            }
        }
    }
}