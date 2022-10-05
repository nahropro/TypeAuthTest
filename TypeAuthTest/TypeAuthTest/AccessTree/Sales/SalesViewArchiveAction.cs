using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesViewArchiveAction : PolicyConfiguration, IAccessReadOnlyAction, IComputeAction<SalesAction>
    {
        private bool p => (Parent?.ComputePolicy() ?? false);
        private bool w => (Parent?.Write.ComputePolicy() ?? false);
        private bool u => (Parent?.Update.ComputePolicy() ?? false);
        private bool d => (Parent?.Delete?.ComputePolicy() ?? false);

        public bool Access => (Parent?.ComputePolicy() ?? false) && (Parent?.Write.ComputePolicy() ?? false) &&
            (Parent?.Update.ComputePolicy() ?? false) && (Parent?.Delete?.ComputePolicy() ?? false);

        public SalesAction? Parent { get; private set; }

        public SalesViewArchiveAction(): base("Base.Sales.ViewArchive")
        {
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent=parent;
        }

        public override bool ComputePolicy()
        {
            return Access && Parent.ComputePolicy();
        }
    }
}
