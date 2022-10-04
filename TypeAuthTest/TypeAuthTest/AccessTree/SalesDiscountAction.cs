using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesDiscountAction : PolicyConfiguratiion, IDoubleAction, IComputeAction<SalesAction>
    {
        public double Value { get; set; }
        public SalesAction? Parent { get; set; }

        public SalesDiscountAction() : base("Base.Sales.Discount")
        {
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent = parent;
        }
    }
}
