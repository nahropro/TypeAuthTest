namespace TypeAuthTest.AccessTree.Interfaces
{
    public interface IParentAction<T> where T : class
    {
        public T Parent { get; set; }
    }
}
