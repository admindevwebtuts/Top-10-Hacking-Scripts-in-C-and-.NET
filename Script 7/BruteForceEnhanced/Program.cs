using System;
using System.Linq;

class Program
{
    static string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    static void Main(string[] args)
    {
        string passwordToCrack = "AB12";
        int maxPasswordLength = 4;

        foreach (var attempt in GeneratePasswords(maxPasswordLength))
        {
            if (attempt == passwordToCrack)
            {
                Console.WriteLine($"Password cracked! It is {attempt}.");
                break;
            }
        }
    }

    static IEnumerable<string> GeneratePasswords(int maxLength)
    {
        for (int length = 1; length <= maxLength; length++)
        {
            foreach (string password in GeneratePasswordsOfLength("", length))
            {
                yield return password;
            }
        }
    }

    static IEnumerable<string> GeneratePasswordsOfLength(string prefix, int length)
    {
        if (length == 0)
        {
            yield return prefix;
        }
        else
        {
            foreach (char c in alphabet)
            {
                foreach (string password in GeneratePasswordsOfLength(prefix + c, length - 1))
                {
                    yield return password;
                }
            }
        }
    }
}
