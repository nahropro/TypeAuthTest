using System.Security.Authentication;
using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesDiscountAction : IDoubleAction, IComputeAction<SalesAction>
    {
        private double _value;
        public double Value { get
            {
                if (!Parent.ComputePolicy())
                    throw new AuthenticationException("You don't have this permistion!");

                return _value;
            } 
            set
            {
                _value = value;
            }
        }

        public SalesAction? Parent { get; set; }

        public void ComputeAction(SalesAction parent)
        {
            Parent = parent;
        }
    }
}
