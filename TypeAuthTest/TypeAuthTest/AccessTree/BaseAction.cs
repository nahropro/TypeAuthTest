using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class BaseAction : PolicyConfiguratiion, IAccessAction
    {

        public bool Access { get ; set ; }

        public SalesAction Sales { get; set; }

        public BaseAction() : base("Base")
        {
            Sales.Parent = this;
        }

        public override bool ConfigurePolicy()
        {
            return Access;
        }
    }
}
