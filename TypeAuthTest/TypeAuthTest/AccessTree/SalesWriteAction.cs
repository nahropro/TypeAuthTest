using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesWriteAction : PolicyConfiguratiion, IAccessAction
    {
        public bool Access { get; set; }
        public SalesAction? Parent { get; private set; }

        public SalesWriteAction(SalesAction parent) : base("Base.Sales.Write")
        {
            Parent = parent;
        }

        public override bool ConfigurePolicy()
        {
            return Access & Parent.ConfigurePolicy();
        }
    }
}
