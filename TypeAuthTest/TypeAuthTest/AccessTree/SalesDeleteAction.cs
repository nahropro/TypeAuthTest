using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesDeleteAction : PolicyConfiguratiion, IAccessAction
    {
        public bool Access { get; set; }
        public SalesAction? Parent { get; private set; }

        public SalesDeleteAction(SalesAction parent) : base("Base.Sales.Delete")
        {
            Parent = parent;
        }

        public override bool ConfigurePolicy()
        {
            return Access & Parent.ConfigurePolicy();
        }
    }
}
