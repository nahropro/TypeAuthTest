using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesDiscountAction : PolicyConfiguratiion, IDoubleAction, IParentAction<SalesAction>
    {
        public SalesAction Parent { get; set; }
        public double Value { get; set; }

        public SalesDiscountAction(): base("Base.Sales.Discount")
        {
        }
    }
}
