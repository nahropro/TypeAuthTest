using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesWriteAction : PolicyConfiguratiion, IAccessAction, IParentAction<SalesAction>
    {
        public bool Access { get; set; }
        public SalesAction Parent { get; set; }

        public SalesWriteAction() : base("Base.Sales.Write")
        {
        }

        public override bool ConfigurePolicy()
        {
            return Access & Parent.ConfigurePolicy();
        }
    }
}
