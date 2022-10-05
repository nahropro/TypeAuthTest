using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesDeleteAction : PolicyConfiguration, IAccessAction, IComputeAction<SalesAction>
    {

        private bool _access;
        public bool Access {
            get
            {
                return _access || ((Parent?.Write.ComputePolicy() ?? false) && (Parent?.Update.ComputePolicy() ?? false));
            }
            set
            {
                _access = value;
            }
        }

        public SalesAction? Parent { get; private set; }

        public SalesDeleteAction() : base("Base.Sales.Delete")
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
