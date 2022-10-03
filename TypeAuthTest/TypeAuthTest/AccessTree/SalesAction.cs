using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesAction : PolicyConfiguratiion, IAccessAction
    {
        public bool Access { get; set; }

        public BaseAction? Parent { get; private set; }

        public SalesWriteAction Write { get; set; }

        public SalesDeleteAction Delete { get; set; }

        public SalesDiscountAction Discount { get; set; }

        public SalesValidDateAction ValidDate { get; set; }

        public SalesAction(BaseAction parent) : base("Base.Sales")
        {
            Parent=parent;

            Write = new(this);
            Delete = new(this);
            Discount = new(this);
            ValidDate = new(this);
        }

        public override bool ConfigurePolicy()
        {
            return Access && Parent.ConfigurePolicy();
        }
    }
}
