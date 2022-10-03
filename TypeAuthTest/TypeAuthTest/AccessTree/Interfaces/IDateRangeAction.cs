namespace TypeAuthTest.AccessTree.Interfaces
{
    public interface IDateRangeAction
    {
        public DateOnly Min { get; set; }

        public DateOnly Max { get; set; }
    }
}
