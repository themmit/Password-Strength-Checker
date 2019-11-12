using System;

namespace Password_Strength_Checker {
    class Program {

        static MyPassword myPassword;
        public static void Main(string[] args) {
            myPassword = new MyPassword();
            passwordFunc();
        }

        public static void passwordFunc() {
            Console.Clear();
            Console.WriteLine("Welcome to password strength checker");
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Password should be minimum 8 character long and contains 1 alphabet, 1 numberic and 1 speacial character.");
            Console.Write("Enter your password: ");
            myPassword.YourPassword = Console.ReadLine();
            if(myPassword.isPasswordValid == false) {
                Console.WriteLine("\n" + myPassword.Reason);
                Console.Write("\n\nDo you want to retry? (y/n)");
                string y_n = Console.ReadLine();
                if (y_n.ToLower().Equals("y")) {
                    passwordFunc();
                }
            } else {
                Console.WriteLine($"Congratulations! Your password ({myPassword.YourPassword}) is strong enough.");
            }
        }
    }
}
