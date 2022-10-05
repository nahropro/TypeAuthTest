using System.Security.Authentication;
using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesDiscountAction : IDoubleAction, IComputeAction<SalesAction>
    {
        public double Value { get;set;}

        public SalesAction? Parent { get; set; }

        public void ComputeAction(SalesAction parent)
        {
            Parent = parent;
        }
    }
}
