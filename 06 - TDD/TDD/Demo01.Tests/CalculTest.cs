using Demo01.Bibliotheque;

namespace Demo01.Tests;

[TestClass]
public class CalculTest
{
    private Calcul? _calcul;

    // fonctionne aussi mais pas recommandé pour NUnit et MSTest
    //public CalculTest()
    //{
    //    _calcul = new();
    //}

    //[ClassInitialize]// s'exécutera UNE FOIS AVANT TOUT LES TEST
    //public void OneTimeSetUp()
    //{
    //    _calcul = new Calcul();
    //}

    //[ClassCleanup]  // s'exécutera UNE FOIS APRES TOUT LES TEST
    //public void OneTimeTearDown()
    //{
    //    _calcul = null;
    //}

    [TestInitialize] // s'exécutera AVANT CHAQUE TEST
    public void SetUp()
    {
        _calcul = new Calcul();
    }

    [TestCleanup]  // s'exécutera APRES CHAQUE TEST
    public void TearDown()
    {
        _calcul = null;
    }

    [TestMethod]
    public void WhenAddition_10_30_Then_40()
    {
        // Arrange 
        //var calcul = new Calcul();

        // Act
        var result = _calcul.Addition(10, 30);

        // Assert
        Assert.AreEqual(40, result);
    }

    [TestMethod]
    public void WhenDivision_30_10_Then_3()
    {
        // Arrange 
        var calcul = new Calcul();

        // Act
        double result = calcul.Division(30, 10);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void WhenDivision_1_0_Then_DivideByZeroException()
    {
        // Arrange
        var calcul = new Calcul();

        // Act et Assert
        Assert.ThrowsException<DivideByZeroException>(() => calcul.Division(1, 0));

        // Variantes avec delegates (syntaxe longue pour "=>")
        Assert.ThrowsException<DivideByZeroException>(delegate () { 
            return calcul.Division(1, 0); 
        });

        Func<object> fonc = delegate ()
        {
            return calcul.Division(1, 0);
        };

        Assert.ThrowsException<DivideByZeroException>(fonc);

        // Sans l'utilisation de ThrowsException
        try
        {
            calcul.Division(1, 0);
        }
        catch (Exception e)
        {
            Assert.AreEqual(e.GetType(), typeof(DivideByZeroException));
        }
    }
}
