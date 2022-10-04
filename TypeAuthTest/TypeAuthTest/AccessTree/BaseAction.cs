using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class BaseAction : PolicyConfiguratiion, IAccessAction, IComputeAction
    {

        public bool Access { get ; set ; }

        public SalesAction Sales { get; set; }

        public BaseAction() : base("Base")
        {
        }

        public override bool ConfigurePolicy()
        {
            return Access;
        }

        public void ComputeAction()
        {
            Sales.ComputeAction(this);
        }
    }
}
