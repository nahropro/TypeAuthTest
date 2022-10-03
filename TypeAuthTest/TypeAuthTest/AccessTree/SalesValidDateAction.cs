using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesValidDateAction : PolicyConfiguratiion, IDateRangeAction, IParentAction<SalesAction>
    {
        public DateOnly Min { get; set; }
        public DateOnly Max { get; set; }
        public SalesAction Parent { get; set; }

        public SalesValidDateAction(): base("Base.Sales.ValidDate")
        {
        }

        public override bool ConfigurePolicy()
        {
            return (DateTime.Now.Date>= Min.ToDateTime(new TimeOnly(0)) && DateTime.Now.Date<=Max.ToDateTime(new TimeOnly(0))) 
                && Parent.ConfigurePolicy();
        }
    }
}
