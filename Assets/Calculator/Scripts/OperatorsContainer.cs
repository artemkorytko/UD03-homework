using System.Collections.Generic;

namespace CalculatorRPN
{
    public class OperatorsContainer
    {
        private  List<Operator> operators = new List<Operator>();

        public OperatorsContainer()
        {
            AddOperator(new Operator("*",3));
            AddOperator(new Operator("/",3));
            AddOperator(new Operator("+",2));
            AddOperator(new Operator("-",2));
            AddOperator(new Operator("(",1));
        }
        
        public void AddOperator(Operator op)
        {
            operators.Add(op);
        }

        public Operator FindOperator(string s)
        {
            foreach (var op in operators)
            {
                if (op.Symbol == s)
                {
                    return op;
                }
            }

            return null;
        }

    }
}