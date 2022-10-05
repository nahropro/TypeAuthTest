using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesWriteAction : PolicyConfiguration, IAccessAction, IComputeAction<SalesAction>
    {
        public bool Access { get; set; }
        public SalesAction? Parent { get; private set; }

        public SalesWriteAction() : base("Base.Sales.Write")
        {
        }

        public override bool ComputePolicy()
        {
            return Access && Parent.ComputePolicy();
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent = parent;
        }
    }
}
