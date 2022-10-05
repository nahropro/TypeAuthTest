namespace TypeAuthTest.AccessTree
{
    public abstract class PolicyConfiguration
    {
        public string ActionName { get; private set; }

        public PolicyConfiguration(string actionName)
        {
            ActionName = actionName;
        }

        public virtual bool ComputePolicy()
        {
            return false;
        }
    }
}
