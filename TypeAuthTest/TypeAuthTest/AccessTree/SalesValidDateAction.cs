using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesValidDateAction : PolicyConfiguratiion, IDateRangeAction
    {
        public DateTime Min { get; set; }
        public DateTime Max { get; set; }
        public SalesAction? Parent { get; set; }

        public SalesValidDateAction(SalesAction parent) : base("Base.Sales.ValidDate")
        {
            Parent = parent;
        }

        public override bool ConfigurePolicy()
        {
            return (DateTime.Now.Date>= Min && DateTime.Now.Date<=Max) 
                && Parent.ConfigurePolicy();
        }
    }
}
