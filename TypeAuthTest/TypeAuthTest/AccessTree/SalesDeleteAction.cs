using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesDeleteAction : PolicyConfiguration, IAccessAction, IComputeAction<SalesAction>
    {
        public bool Access { get; set; }
        public SalesAction? Parent { get; private set; }

        public SalesDeleteAction() : base("Base.Sales.Delete")
        {
        }

        public override bool ConfigurePolicy()
        {
            return Access & Parent.ConfigurePolicy();
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent=parent;
        }
    }
}
