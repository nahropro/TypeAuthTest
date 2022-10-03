namespace TypeAuthTest.AccessTree
{
    public abstract class PolicyConfiguratiion
    {
        public string PolicyName { get; private set; }

        public PolicyConfiguratiion(string policyName)
        {
            PolicyName = policyName;
        }

        public virtual bool ConfigurePolicy()
        {
            return false;
        }
    }
}
