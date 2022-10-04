using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesAction : PolicyConfiguratiion, IAccessAction, IComputeAction<BaseAction>
    {
        public bool Access { get; set; }

        public BaseAction? Parent { get; private set; }

        public SalesWriteAction Write { get; set; }

        public SalesDeleteAction Delete { get; set; }

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
            this.Parent = parent;

            Write.ComputeAction(this);
            Delete.ComputeAction(this);
            Discount.ComputeAction(this);
            ValidDate.ComputeAction(this);
        }
    }
}
