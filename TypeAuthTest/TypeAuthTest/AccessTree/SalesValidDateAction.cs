using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesValidDateAction : PolicyConfiguration, IDateRangeAction, IComputeAction<SalesAction>
    {
        public DateTime Min { get; set; }
        public DateTime Max { get; set; }
        public SalesAction? Parent { get; set; }

        public SalesValidDateAction() : base("Base.Sales.ValidDate")
        {
        }

        public override bool ConfigurePolicy()
        {
            return (DateTime.Now.Date>= Min && DateTime.Now.Date<=Max) 
                && Parent.ConfigurePolicy();
        }

        public void ComputeAction(SalesAction parent)
        {
            Parent = parent;
        }
    }
}
