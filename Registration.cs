using System;
namespace G12UserManagement
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(UserManager.Login("nika1998", "12312300")); //false
            User user1 = new User();
            user1.Username = "nika1998";
            user1.Password = "12312300";
            Console.WriteLine(UserManager.Register(user1)); //0
            Console.WriteLine(UserManager.Register(user1)); //2
            User user2 = new User() { Username = "Nino9796", Password = "97961234" };
            Console.WriteLine(UserManager.Register(user2)); //0
            Console.WriteLine(UserManager.Login("nika1998", "12312300")); //true
            Console.WriteLine(UserManager.Login("nika1998", "12312301")); //false
            Console.WriteLine(UserManager.UnRegister("nikusha1998")); //false
            Console.WriteLine(UserManager.UnRegister("nika1998")); //true
            Console.WriteLine(UserManager.Login("nika1998", "12312300")); //false
        }
    }
    class User
    {
        private string _username;
        private string _password;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 8)
                {
                    throw new ArgumentException("Username cant be null and must be at least 8 characters");
                }
                _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 8)
                {
                    throw new ArgumentException("Password cant be null and must be at least 8 characters");
                }
                _password = value;
            }
        }
    }
    static class UserManager
    {
        private static User?[] _users = new User?[10];
        public static int Register(User user)
        {
            if (user == null)
            {
                return 1;
            }
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] != null && _users[i].Username == user.Username)
                {
                    return 2;
                }
            }
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == null)
                {
                    _users[i] = user;
                    return 0;
                }
            }
            return 3;
        }
        public static bool Login(string username, string password)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] != null && _users[i].Username == username && _users[i].Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool UnRegister(string username)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] != null && _users[i].Username == username)
                {
                    _users[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}