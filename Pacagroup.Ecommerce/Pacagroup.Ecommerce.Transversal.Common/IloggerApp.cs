
namespace Pacagroup.Ecommerce.Transversal.Common
{
    public interface IloggerApp<T>
    {
        void LogError(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogInformation(string message, params object[] args);
    }
}
