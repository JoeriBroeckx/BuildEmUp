namespace BuildEmUp
{
    /// <summary>
    /// Every person entity will inherit from this interface
    /// </summary>
    public interface IPerson
    {
        void Pays(decimal amount);
        void Receives(decimal amount);
    }
}