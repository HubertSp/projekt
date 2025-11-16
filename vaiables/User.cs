using System;

namespace WpfApp4.Vaiables
{
    public class User
    {
        private static int _counterId = 0;
        private int _id;
        private string _login;
        private string _password;
        private string _email;

        public User()
        {
            _id = ++_counterId;
        }

        public string Login
        {
            get => _login;
            set => _login = ValidateNotEmpty(value, nameof(Login));
        }

        public string Password
        {
            get => _password;
            set => _password = ValidateNotEmpty(value, nameof(Password));
        }

        public string Email
        {
            get => _email;
            set => _email = ValidateNotEmpty(value, nameof(Email));
        }

        // 👇 Wspólna metoda walidująca
        private string ValidateNotEmpty(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} must not be empty");
            return value;
        }
    }
}
