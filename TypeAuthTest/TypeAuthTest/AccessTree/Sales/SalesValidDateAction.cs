using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree.Sales
{
    public class SalesValidDateAction : PolicyConfiguration, IDateRangeAction, IComputeAction<SalesAction>
    {
        public DateTime Min { get; set; }
        public DateTime Max { get; set; }
        public SalesAction? Parent { get; set; }

        public SalesValidDateAction() : base("Base.Sales.ValidDate")
        {
        }

        public override bool ComputePolicy()
        {
            return DateTime.Now.Date >= Min && DateTime.Now.Date <= Max
                && Parent.ComputePolicy();
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent = parent;
        }
    }
}
