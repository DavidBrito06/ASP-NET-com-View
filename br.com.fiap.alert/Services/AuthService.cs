using br.com.fiap.alert.Models;

namespace br.com.fiap.alert.Services
{
    public class AuthService: IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { Email = "teste@mail.com", Name = "Teste", PasswordHash = "123456" }
                };


        public UserModel Authenticate(string email, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }
    }
}
}
