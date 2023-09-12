//using permet de rendre accessible les classes et structures définies dans d'autres namespace.
//En .NET, le fichier projet par défaut indique <ImplicitUsings>enable</ImplicitUsings>
//Ce qui signifie que certains usings sont ajoutés implicitement dans chaque fichier.
//using System;
//using System.Text;

//namespace permet d'organiser les classes dans des espaces de nom.
//Ils sont essentiels pour permettre d'avoir deux classes qui portent le même nom.
//Il est possible d'appliquer un namespace par block (namespace CoursReference { (...) })
//Ou d'appliquer le namespace pour l'ensemble du fichier (namespace CoursReference;)
namespace CoursReference;

//Par défaut, une classe utilise le niveau d'accès internal.
//internal : la classe est visible dans le projet uniquement.
//public : la classe est visible dans le projet et accessible depuis les autres projets
public class Contact
{
    //Dans une classe, on peut trouver :
    //- Des attributs
    //- Des propriétés (ou accesseurs)
    //- Des évènements
    //- Des constructeurs
    //- Des méthodes

    //#region est un mot clef de pré-processeur (#) qui est interprété au début de la compilation.
    //#region permet simplement de permettre de réduire une portion de code dans visual studio.
    #region Fields

    //Le principe de l'encapsulation doit être respecté :
    //Les attributs doivent être privé (interne à la classe)
    //private est d'ailleur le niveau d'accès par défaut des attributs.

    //.NET prend en charge la gestion des nullable, ce qui permet d'indiquer au compilateur
    //si la variable autorise ou non la valeur null.
    //si la variable n'autorise pas la valeur null, elle doit alors avoir une valeur lors de l'initialisation d'une instance.
    //C'est à dire que la valeur est définit soit comme valeur par défaut comme ci-dessous, ou dans le constructeur.
    //Il est également possible d'utiliser required (cf. la propriété LastName)
    //Ce comportement n'a de sens que pour les classes puisque les structures par défaut n'autorisent pas les valeurs null.
    private string _FirstName = string.Empty;

    //L'exemple suivant permet d'indiquer que FirstName accepte les valeurs null (string?).
    //private string? _FirstName;

    #endregion

    #region Properties

    //Ceci est un exemple d'une propriété qui expose un attribut.
    //Une propriété définie une méthode get (obtenir) et une méthode set (définir)
    //Dans cette exemple, la propriété permet de rendre accessible l'attribut FirstName.
    public string FirstName
    {
        //cette syntax est un get avec body (corps).
        //Il est possible de définir plusieurs instructions dans un corps.
        //get { return _FirstName; }
        //Ici on utilise la syntaxe bodied (sans corps) avec "=>".
        //Dans ce cas,une seule instruction est possible et return devient implicite.
        get => _FirstName;
        //set { _FirstName = value; }
        set => _FirstName = value;
    }

    //Il est aussi possible de déclarer des propriétés avec des attributs invisibles en programmation (auto property).
    //required permet d'indiquer que la classe ne va pas fournir une valeur initiale à une propriété.
    //Cette propriété devra alors être définie lors de l'initialisation d'une instance.
    public required string LastName { get; set; }

    public DateTime Birthdate { get; set; }

    //Ceci est un exemple d'attribut en lecture seule bodied
    public int Age => DateTime.Now.Year - Birthdate.Year; //TODO : A revoir

    #endregion

    #region Events

    #endregion

    #region Constructors
    //Si aucun constructeur est défini, il existe toujours un constructeur par défaut qui ne prend rien en paramètre.
    
    //Il est possible de définir des constructeurs avec des arguments facultatifs.
    //Ici, lastName a par défaut la valeur "".
    //Les valeurs par défaut sont obligatoirement des constantes (la valeur doit être connue à la compilation).
    //public Contact(string lastName = "")
    //{
    //    LastName = lastName;
    //}

    #endregion

    #region Methods

    #endregion

}