namespace TypeRefTypeVal;

public class Foo
{
    public int Bar { get; set; } = 0;
}

internal class Program
{
    static void Main(string[] args)
    {
        Foo foo = new Foo();
        Console.WriteLine($"Valeur de foo.Bar : {foo.Bar}"); // 0
        MaMethodRef(foo); // Type référence : accès à l'instance unique.
        Console.WriteLine($"Valeur de foo.Bar : {foo.Bar}"); // 1

        int fooValue = 0;
        Console.WriteLine($"Valeur de foo : {fooValue}"); // 0
        MaMethodValue(fooValue); // Type valeur : copie de l'instance, pas d'accès.
        Console.WriteLine($"Valeur de foo : {fooValue}"); // 0

        fooValue = 0;
        Console.WriteLine($"Valeur de foo : {fooValue}"); // 0
        MaMethodValueRef(ref fooValue); //Type valeur passé en référence : accès.
        Console.WriteLine($"Valeur de foo : {fooValue}"); // 1

        string fooStr = "foo";
        Console.WriteLine($"Valeur de foo : {fooStr}"); // foo
        MaMethodString(fooStr); //Type référence immuable (cas particulier) : pas accès.
        Console.WriteLine($"Valeur de foo : {fooStr}"); // foo

        fooStr = "foo";
        Console.WriteLine($"Valeur de foo : {fooStr}"); // foo
        MaMethodStringRef(ref fooStr); // permet l'accès à l'instance d'une string avec ref.
        Console.WriteLine($"Valeur de foo : {fooStr}"); // foobar
    }

    static void MaMethodStringRef(ref string fooStr)
    {
        fooStr = fooStr + "bar";
    }

    static void MaMethodString(string fooStr)
    {
        fooStr = fooStr + "bar";
    }

    static void MaMethodValue(int foo)
    {
        foo++;
    }

    static void MaMethodValueRef(ref int foo)
    {
        foo++;
    }

    static void MaMethodRef(Foo foo)
    {
        foo.Bar++;
    }
    

}
