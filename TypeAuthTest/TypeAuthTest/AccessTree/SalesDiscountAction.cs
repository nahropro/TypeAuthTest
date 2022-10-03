using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesDiscountAction : PolicyConfiguratiion, IDoubleAction
    {
        public double Value { get; set; }
        public SalesAction? Parent { get; set; }

        public SalesDiscountAction(SalesAction parent) : base("Base.Sales.Discount")
        {
            Parent = parent;
        }
    }
}
