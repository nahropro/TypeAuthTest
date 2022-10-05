using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesUpdateAction : PolicyConfiguration, IAccessAction, IComputeAction<SalesAction>
    {
        public bool Access { get; set; }
        public SalesAction? Parent { get; private set; }

        public SalesUpdateAction() : base("Base.Sales.Update")
        {
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent = parent;
        }

        public override bool ComputePolicy()
        {
            return Access && Parent.ComputePolicy();
        }
    }
}
