using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesWriteAction : PolicyConfiguratiion, IAccessAction, IComputeAction<SalesAction>
    {
        public bool Access { get; set; }
        public SalesAction? Parent { get; private set; }

        public SalesWriteAction() : base("Base.Sales.Write")
        {
        }

        public override bool ConfigurePolicy()
        {
            return Access & Parent.ConfigurePolicy();
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent = parent;
        }
    }
}
