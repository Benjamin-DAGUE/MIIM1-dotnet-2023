using System.Reflection;

namespace CoursReflexion;

public class Bar
{
    public int Id { get; set; }
}

public class Foo
{
    public int Id { get; set; }
    public string Bar { get; set; } = string.Empty;

    public Bar BarReference { get; set; } = new Bar();
    public Bar? BarReference2 { get; set; }


    public void BarToBAR()
    {
        BarReference2 = BarReference;
        Bar = Bar.ToUpper() + "valeur";
    }
}

internal class Program
{
    //Il est possible de faire une copie d'une instance en utilisant la réflection.
    static TSource ReflectionCopy<TSource>(TSource toCopy)
        where TSource : new()
    {
        //On récupère le type de l'objet à copier.
        Type type = toCopy?.GetType() ?? throw new Exception();

        //On récupère le constructeur vide.
        ConstructorInfo constructor = type.GetConstructor(new Type[] { }) ?? throw new Exception();

        //On appel le constructeur et on obtient une nouvelle instance.
        TSource copied = (TSource)constructor.Invoke(null);

        //Pour chaque propriété du type.
        foreach (PropertyInfo property in type.GetProperties())
        {
            //On obtient la valeur de la propriété
            object? value = property.GetValue(toCopy);

            //Si on est sur un type référence (sauf string...)
            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                //On appel la méthode de copie en récursif pour copier l'instance et non pas la référence.
                object? copy = ReflectionCopy(value);
                property.SetValue(copied, copy);
            }
            else
            {
                //Sinon on applique la valeur à la copie.
                property.SetValue(copied, value);
            }
        }

        return copied;
    }

    static void Main(string[] args)
    {
        /*Dans le cadre de la plateforme .NET de Microsoft, une "assembly" est une unité de déploiement et de versionnement pour les applications .NET.
         * Elle contient du code compilé en langage intermédiaire Microsoft (MSIL) ainsi que des métadonnées qui décrivent les types, les membres,
         * les références et toutes les ressources nécessaires pour exécuter le code. Une assembly peut prendre la forme d'une seule DLL 
         * (bibliothèque de liens dynamiques) ou d'un fichier EXE (exécutable), et elle peut également contenir des ressources telles que des images ou 
         * des fichiers de configuration. Les assemblies sont le moyen par lequel les composants et les applications .NET sont déployés, référencés et gérés, 
         * et elles jouent un rôle central dans la sécurité, le typage fort, et la version de composants dans l'écosystème .NET.
         * 
         * 
         * Dans le cadre de la plateforme .NET, System.Reflection est une bibliothèque qui permet d'inspecter les métadonnées des types à l'exécution,
         * de créer et manipuler des instances d'objets, et d'appeler des méthodes et des propriétés dynamiquement. Cette fonctionnalité est particulièrement
         * utile pour les scénarios comme le chargement dynamique d'assemblies, la sérialisation d'objets, le mapping d'objets vers des bases de données ou la
         * création d'outils de type éditeur de code. En utilisant System.Reflection, les développeurs peuvent obtenir des informations sur les types présents
         * dans les assemblies, explorer les relations entre les types, ainsi que manipuler ces types et leurs membres. Toutefois, il convient de noter que l'utilisation
         * de la réflexion peut introduire certaines complexités et des coûts en termes de performances.
         */

        // Retourne les informations sur l'Assembly qui a été appelée en première (là où est le Main).
        Assembly assembly = Assembly.GetEntryAssembly() ?? throw new Exception();
        Console.WriteLine(assembly.FullName);

        //Il est possible de lister les types existants dans une Assembly
        foreach (Type type in assembly.GetTypes())
        {
            Console.WriteLine(type.FullName);

            if (type.Name == "Foo")
            {
                //Il est possible d'utiliser Activator.CreateInstance pour instancer un objet d'un type donné.
                object fooInstance = Activator.CreateInstance(type) ?? throw new Exception();

                //Il est possible de liste des membres d'un type ou d'en récupérer un en particulier.
                PropertyInfo property = type.GetProperty(nameof(Foo.Bar)) ?? throw new Exception();

                //Exemple d'un Set de property.
                property.SetValue(fooInstance, "BarValue");
                object? barValue = property.GetValue(fooInstance);

                //Exemple d'un appel de méthode.
                MethodInfo method = type.GetMethod(nameof(Foo.BarToBAR)) ?? throw new Exception();
                method.Invoke(fooInstance, null);

                Console.WriteLine(barValue);
                Console.WriteLine("Coucou la modif");
            }
        }



        Foo foo = new Foo();
        foo.Bar = "barValue";
        foo.BarReference.Id = 6;
        foo.BarToBAR();

        Foo copy = ReflectionCopy(foo);

        copy.BarReference.Id = 7;

        Console.WriteLine($"{foo.Bar} = {copy.Bar}");

    }
}
