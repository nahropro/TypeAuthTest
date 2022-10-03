using TypeAuthTest.AccessTree.Interfaces;

namespace TypeAuthTest.AccessTree
{
    public class SalesAction : PolicyConfiguratiion, IAccessAction, IParentAction<BaseAction>
    {
        public bool Access { get; set; }

        public BaseAction Parent { get; set; }

        public SalesWriteAction Write { get; set; }

        public SalesDeleteAction Delete { get; set; }

        public SalesDiscountAction Discount { get; set; }

        public SalesValidDateAction ValidDate { get; set; }

        public SalesAction() : base("Base.Sales")
        {
            Write.Parent = this;
            Delete.Parent = this;
            Discount.Parent = this;
            ValidDate.Parent=this;
        }

        public override bool ConfigurePolicy()
        {
            return Access && Parent.ConfigurePolicy();
        }
    }
}
