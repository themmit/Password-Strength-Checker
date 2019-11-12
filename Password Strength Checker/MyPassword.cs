using System.Linq;

namespace Password_Strength_Checker {
    internal class MyPassword {

        internal enum PasswordScore {
            Blank = 0,
            CantLessthan8 = 1,
            AlphabetMiss = 2,
            numericMiss = 3,
            SpecialMiss = 4,
            AllOk = 5
        }

        public bool isPasswordValid {
            get {
                return (passwordScore == PasswordScore.AllOk);
            }
        }

        private PasswordScore passwordScore = PasswordScore.Blank;

        public string YourPassword {
            get {
                return Password;
            }

            set {
                Password = value;
                CheckStrength();
            }
        }

        private string Password = "";

        public string Reason {
            get {
                string reason = "";
                switch (passwordScore) {
                    case PasswordScore.Blank:
                        reason = "Password can't be empty.";
                        break;
                    case PasswordScore.CantLessthan8:
                        reason = "Password can't be less than 8 character.";
                        break;
                    case PasswordScore.numericMiss:
                        reason = "Number is missing.";
                        break;
                    case PasswordScore.AlphabetMiss:
                        reason = "Alphabet is missing.";
                        break;
                    case PasswordScore.SpecialMiss:
                        reason = "Special character missing.";
                        break;
                    case PasswordScore.AllOk:
                        reason = "All Ok";
                        break;
                    default:
                        reason = $"Unknown Reason ({passwordScore})";
                        break;
                }
                return reason;
            }
        }

        private string specialCharcterAllowed = "!@#$%^&*()";

        public void CheckStrength() {
            Password = Password.Trim();
            passwordScore = PasswordScore.AllOk;
            if (Password.Length < 1) { 
                passwordScore = PasswordScore.Blank;
                return;
            }
            if (Password.Length < 8) { 
                passwordScore = PasswordScore.CantLessthan8;
                return;
            }
            bool hasDigit = false, hasAlphbet = false, hasSpecial = false;
            for (int i = 0; i < Password.Length; i++) {
                if (char.IsLetter(Password[i])) {
                    hasAlphbet = true;
                } else if (char.IsDigit(Password[i])) {
                    hasDigit = true;
                }
            }
            if (!hasDigit) {
                passwordScore = PasswordScore.numericMiss;
            } else if (!hasAlphbet) {
                passwordScore = PasswordScore.AlphabetMiss;
            } else {
                bool temp = false;
                foreach (char c in Password) {
                    if (specialCharcterAllowed.Contains(c))
                        temp = true;
                }
                if (!temp) {
                    passwordScore = PasswordScore.SpecialMiss;
                }
            }
        }
    }
}
