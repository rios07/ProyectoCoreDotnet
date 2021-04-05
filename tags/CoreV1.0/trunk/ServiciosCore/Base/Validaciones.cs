namespace ServiciosCore
{
    public interface IValidaciones
    {
        void AddError(string pKey, string pErrorMessage);
        bool IsValid { get; }
    }
}
