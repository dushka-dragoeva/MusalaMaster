using MusalaMaster.Core.Models;

namespace MusalaMaster.Core.Factories
{
    public class SignInFactory
    {
        public static SignInModel CreateModel(string username, string password)
        {
            return new SignInModel
            {
                Username = username,
                Password = password,
            };
        }
    }
}
