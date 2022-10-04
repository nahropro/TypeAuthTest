using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesAction : PolicyConfiguration, IAccessAction, IComputeAction<BaseAction>
    {
        public bool Access { get; set; }

        public BaseAction? Parent { get; private set; }

        public SalesWriteAction Write { get; set; }

        public SalesUpdateAction Update { get; set; }

        public SalesDeleteAction? Delete { get; set; }

        public SalesViewArchiveAction? ViewArchive { get; set; }

        public SalesDiscountAction Discount { get; set; }

        public SalesValidDateAction ValidDate { get; set; }

        public SalesAction() : base("Base.Sales")
        {
        }

        public override bool ConfigurePolicy()
        {
            return Access && Parent.ConfigurePolicy();
        }

        public void ComputeAction(BaseAction parent)
        {
            Parent = parent;

            Write.ComputeAction(this);
            Discount.ComputeAction(this);
            ValidDate.ComputeAction(this);
            Update.ComputeAction(this);

            Delete = Delete ?? new();
            Delete.ComputeAction(this);

            ViewArchive = ViewArchive ?? new();
            ViewArchive.ComputeAction(this);
        }
    }
}
