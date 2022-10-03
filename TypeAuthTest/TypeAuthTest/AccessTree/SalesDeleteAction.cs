using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesDeleteAction : PolicyConfiguratiion, IAccessAction, IParentAction<SalesAction>
    {
        public bool Access { get; set; }
        public SalesAction Parent { get; set; }

        public SalesDeleteAction() : base("Base.Sales.Delete")
        {
        }

        public override bool ConfigurePolicy()
        {
            return Access & Parent.ConfigurePolicy();
        }
    }
}
