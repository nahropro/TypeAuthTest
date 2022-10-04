namespace TypeAuthTest.AccessTree.Interfaces
{
    public interface IComputeAction<T>
    {
        public void ComputeAction(T parent);
    }

    public interface IComputeAction
    {
        public void ComputeAction();
    }
}
