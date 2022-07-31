
namespace CalculatorRPN
{
    public class Operator
    {
        public int Priority { get; private set; }
        public string Symbol { get; private set; }

        public Operator(string symbol, int priority)
        {
            Symbol = symbol;
            Priority = priority;
        }
    }
}