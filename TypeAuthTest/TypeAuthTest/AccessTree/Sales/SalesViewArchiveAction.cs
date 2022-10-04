using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesViewArchiveAction : PolicyConfiguration, IAccessReadOnlyAction, IComputeAction<SalesAction>
    {
        private bool p => (Parent?.ConfigurePolicy() ?? false);
        private bool w => (Parent?.Write.ConfigurePolicy() ?? false);
        private bool u => (Parent?.Update.ConfigurePolicy() ?? false);
        private bool d => (Parent?.Delete?.ConfigurePolicy() ?? false);

        public bool Access => (Parent?.ConfigurePolicy() ?? false) && (Parent?.Write.ConfigurePolicy() ?? false) &&
            (Parent?.Update.ConfigurePolicy() ?? false) && (Parent?.Delete?.ConfigurePolicy() ?? false);

        public SalesAction? Parent { get; private set; }

        public SalesViewArchiveAction(): base("Base.Sales.ViewArchive")
        {
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent=parent;
        }

        public override bool ConfigurePolicy()
        {
            return Access && Parent.ConfigurePolicy();
        }
    }
}
