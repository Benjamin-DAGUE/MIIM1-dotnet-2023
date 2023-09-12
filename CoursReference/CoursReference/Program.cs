namespace CoursReference;

internal class Program
{
    static void Main(string[] args)
    {
        //Ne fonctionne pas car LastName est marqué comme required
        //Contact contact = new Contact();

        Contact contact = new Contact()
        //Contact contact = new() //Cette syntaxe peut être simplifiée car new prend par défaut le type de la référence.
        {
            LastName = "test"
        };

        //Il est possible de ne pas indiquer explicitement le type d'une référence.
        //Dans ce cas, le compilateur va résoudre le type de référence à la compilation.
        //Ici, il utilisera le type de référence Contact.
        //Pour rappel, le C# fortement typé!
        //var contact = new Contact(); 

        //Il existe néanmoins un type dynamic (ExpandoObject) qui fonctionne en arrière plan comme un dictionnaire clef / valeur, la clef étant le nom de la propriété.

        Console.WriteLine(contact.LastName);
    }
}
