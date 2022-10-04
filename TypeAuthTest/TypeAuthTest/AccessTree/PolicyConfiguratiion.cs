namespace TypeAuthTest.AccessTree
{
    public abstract class PolicyConfiguratiion
    {
        public string ActionName { get; private set; }

        public PolicyConfiguratiion(string actionName)
        {
            ActionName = actionName;
        }

        public virtual bool ConfigurePolicy()
        {
            return false;
        }
    }
}
