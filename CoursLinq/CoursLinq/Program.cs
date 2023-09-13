using CoursLinq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CoursLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Génération des personnes

            List<string> firstNames = new List<string>()
            {
                "Gilles",
                "Maurice",
                "Raymond",
                "Anaïs",
                "Henri",
                "Hugues",
                "Eugène",
                "Danielle",
                "Stéphanie",
                "Charlotte",
                "Robert",
                "Audrey",
                "Patrick",
                "François",
                "Alexandre",
                "Thomas",
                "Margaud",
                "Dominique",
                "Philippine",
                "Simone",
                "Timothée",
                "Jean",
                "Noémi",
                "Xavier",
                "Michèle",
                "Christine",
                "Georges",
                "Bernadette",
                "Colette",
                "David",
                "Marie",
                "Josette",
                "Catherine",
                "Michelle",
                "Luc",
                "Geneviève",
                "Matthieu",
                "Julie",
                "Luce",
                "Grégoire",
                "René",
                "Gabrielle",
                "Marguerite",
                "Léon",
                "Olivier",
                "Patricia",
                "Philippe",
                "Agathe",
                "Isabelle",
                "Alexandria",
                "Stéphane",
                "Guillaume",
                "Christophe",
                "Christelle",
                "Laurent",
                "Anne",
                "Julien",
                "Arthur",
                "Astrid"
            };
            List<string> lastNames = new List<string>()
            {
                "Renault",
                "Duhamel",
                "Renaud",
                "Renard-Valette",
                "Michaud",
                "Perrier-Renard",
                "Devaux-Charpentier",
                "Briand",
                "Laporte",
                "Masse",
                "Camus",
                "Pires",
                "Clement",
                "Roger",
                "Delattre",
                "Moreau",
                "Lebon",
                "Morin",
                "Guillon",
                "Launay",
                "Begue",
                "Diallo-Blot",
                "Allard",
                "Martinez",
                "Colas",
                "Hernandez",
                "Descamps",
                "Loiseau",
                "Robin",
                "Lacombe",
                "Blanchet",
                "Jacquot",
                "Schneider-Maurice",
                "Sousa",
                "Rodrigues",
                "Meyer-Bonneau",
                "Laroche",
                "Chartier",
                "Gosselin",
                "Delaunay",
                "Peron",
                "Grondin-Gros",
                "Hoarau",
                "Bigot",
                "Santos",
                "Coulon",
                "Techer",
                "Pages-Leroy",
                "Delahaye",
                "Valette",
                "Roux-Dias",
                "Berger",
                "Leblanc",
                "Pelletier",
                "Ferreira",
                "Leduc",
                "Boyer",
                "Gilbert",
                "Leroy",
                "Ferrand",
                "Boulanger",
                "Leclerc",
                "Ledoux",
                "Carlier",
                "Francois",
                "Tanguy",
                "Fontaine",
                "Torres",
                "Rossi",
                "Dupuis",
                "Dubois",
                "Martel",
                "Denis",
            };
            List<string> emailExts = new List<string>()
            {
                "@gmail.com",
                "@orange.fr",
                "@live.fr",
                "@hotmail.fr",
                "@hotmail.com",
                "@outlook.com",
                "@laposte.net",
            };

            Random random = new Random();

            int count = 1000;
            //List<Person> persons = new List<Person>();

            //for (int i = 0; i < count; i++)
            //{
            //    string firstName = firstNames.ElementAt(random.Next(0, firstNames.Count - 1));
            //    string lastName = lastNames.ElementAt(random.Next(0, lastNames.Count - 1));

            //    Person p = new Person()
            //    {
            //        FirstName = firstName,
            //        LastName = lastName,
            //        EMailAddress = $"{firstName}.{lastName}{emailExts.ElementAt(random.Next(0, emailExts.Count))}",
            //        Birthdate = new DateTime(1950,1,1).AddDays(random.Next(0, 21915))
            //    };

            //    persons.Add(p);
            //}

            List<Person> people = Enumerable.Range(0, count)
                .Select(i =>
                {
                    string firstName = firstNames.ElementAt(random.Next(0, firstNames.Count - 1));
                    string lastName = lastNames.ElementAt(random.Next(0, lastNames.Count - 1));

                    Person p = new Person()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        EMailAddress = $"{firstName}.{lastName}{emailExts.ElementAt(random.Next(0, emailExts.Count))}",
                        Birthdate = new DateTime(random.Next(1950, 2010), random.Next(1, 12), random.Next(1, 28)),
                    };

                    return p;
                })
                .ToList();

            people.ForEach(p => Console.WriteLine(p.FullName));
            Console.ReadLine();

            #endregion

            #region 1 - Afficher les personnes nées avant l'an 2000

            Console.WriteLine("1 - Afficher les personnes nées avant l'an 2000");

            #endregion

            #region 2 - Afficher les personnes nées en janvier et en février

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2 - Afficher les personnes nées en janvier et en février");

            #endregion

            #region 3 - Afficher les personnes nées un samedi ou un dimanche

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3 - Afficher les personnes nées un samedi ou un dimanche");

            #endregion

            #region 4 - Afficher les personnes pour lesquelles le prénom a plus de 7 caractères

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("4 - Afficher les personnes pour lesquelles le prénom a plus de 7 caractères");

            #endregion

            #region 5 - Afficher les personnes nées en janvier et en février et pour lesquelles le prénom a plus de 7 caractères

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("5 - Afficher les personnes nées en janvier et en février et pour lesquelles le prénom a plus de 7 caractères");

            #endregion

            #region 6 - Calculer la moyenne d'age des personnes

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("6 - Calculer la moyenne d'age des personnes");
            double averageAge = 0;
            Console.WriteLine("L'âge moyen est : " + averageAge);

            #endregion

            #region 7 - Afficher les personnes de la plus ancienne à la plus jeune

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("7 - Afficher les personnes de la plus ancienne à la plus jeune");

            #endregion

            #region 8 - Afficher les personnes dont l'age est supérieur à la moyenne d'âge

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("8 - Afficher les personnes dont l'age est supérieur à la moyenne d'âge");

            #endregion

            #region 9 - Saisisez une chaîne et afficher les personnes dont le nom contient la recherche

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("9 - Saisisez une chaîne et afficher les personnes dont le nom contient la recherche");
            Console.Write("Votre recherche : ");
            string search = Console.ReadLine();

            #endregion

            Console.ReadLine();
        }
    }
}
