namespace TypeAuthTest.AccessTree
{
    public abstract class PolicyConfiguratiion
    {
        public string PolicyName { get; set; }

        public virtual bool ConfigurePolicy()
        {
            return false;
        }
    }
}
