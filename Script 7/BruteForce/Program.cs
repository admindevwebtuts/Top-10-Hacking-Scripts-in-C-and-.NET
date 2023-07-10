using System;

class Program
{
static void Main(string[] args)
{
string passwordToCrack = "1234";

for (int i = 0; i < 10000; i++)
{
string attempt = i.ToString("D4");

if (attempt == passwordToCrack)
{
Console.WriteLine($"Password cracked! It is {attempt}.");
break;
}
}
}
}