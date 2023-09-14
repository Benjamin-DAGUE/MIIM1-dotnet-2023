using System.Reflection;

namespace CoursReflexion;

public class Foo
{
    public int Id { get; set; }
    public string Bar { get; set; } = string.Empty;


    public void BarToBAR()
    {
        Bar = Bar.ToUpper() + "valeur";
    }
}

internal class Program
{
    static TSource ReflectionCopy<TSource>(TSource toCopy)
        where TSource : new()
    {
        TSource copied = new TSource();

        //TODO : Implmenter une copie par réflexion

        return copied; 
    }

    static void Main(string[] args)
    {
        Foo foo = new Foo("test");
        foo.Bar = "barValue";
        foo.BarToBAR();

        Foo copy = ReflectionCopy(foo);

        Console.WriteLine($"{foo.Bar} = {copy.Bar}");


        //Assembly assembly = Assembly.GetEntryAssembly() ?? throw new Exception();

        //Console.WriteLine(assembly.FullName);

        //foreach (Type type in assembly.GetTypes())
        //{
        //    Console.WriteLine(type.FullName);

        //    if (type.Name == "Foo")
        //    {
        //        object foo = Activator.CreateInstance(type) ?? throw new Exception();

        //        PropertyInfo property = type.GetProperty(nameof(Foo.Bar)) ?? throw new Exception();

        //        property.SetValue(foo, "BarValue");
        //        object? barValue = property.GetValue(foo);

        //        MethodInfo method = type.GetMethod(nameof(Foo.BarToBAR)) ?? throw new Exception();
        //        method.Invoke(foo, null);

        //        Console.WriteLine(barValue);
        //        Console.WriteLine("Coucou la modif");
        //    }

        //}

        //Console.ReadLine();

        //Type typeFoo = typeof(Foo);
        //Console.WriteLine(typeFoo.FullName);



    }
}
