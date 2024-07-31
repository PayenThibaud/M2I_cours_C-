
namespace Demo01.Bibliotheque
{
    public class Calcul
    {
        public double Addition(double x, double y)
        {
            Division(1, 2);
            return x + y;
        }

        public double Division(double x, double y)
        {
            if (y != 0)
                return x / y;

            throw new DivideByZeroException("Division par 0 impossible");
        }
    }
}
