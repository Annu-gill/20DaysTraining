using System;
using System.Text.RegularExpressions;

public class Lab1
{
    public static void Run()
    {
        // --------------------------------
        // ZIP code pattern
        // --------------------------------
        string zipPattern = @"^\d{5}(-\d{4})?$";

        Console.WriteLine(
            $"ZIP \"12345\": {Regex.IsMatch("12345", zipPattern)} | " +
            $"\"12345-6789\": {Regex.IsMatch("12345-6789", zipPattern)} | " +
            $"\"1234\": {Regex.IsMatch("1234", zipPattern)}"
        );

        // --------------------------------
        // Username pattern
        // --------------------------------
        string usernamePattern = @"^[A-Za-z_][A-Za-z0-9_]{2,15}$";

        Console.WriteLine(
            $"Username \"user_1\": {Regex.IsMatch("user_1", usernamePattern)} | " +
            $"\"1user\": {Regex.IsMatch("1user", usernamePattern)} | " +
            $"\"ab\": {Regex.IsMatch("ab", usernamePattern)}"
        );

        // --------------------------------
        // Hex color pattern
        // --------------------------------
        string hexPattern = @"^#[0-9A-Fa-f]{6}$";

        Console.WriteLine(
            $"Hex \"#1A2B3C\": {Regex.IsMatch("#1A2B3C", hexPattern)} | " +
            $"\"#GGGGGG\": {Regex.IsMatch("#GGGGGG", hexPattern)} | " +
            $"\"1A2B3C\": {Regex.IsMatch("1A2B3C", hexPattern)}"
        );

        // --------------------------------
        // Password strength check
        // --------------------------------
        Console.WriteLine(
            $"Password \"password\": {IsValidPassword("password")} | " +
            $"\"Password1\": {IsValidPassword("Password1")} | " +
            $"\"pass1\": {IsValidPassword("pass1")}"
        );

        // --------------------------------
        // Sentence pattern
        // --------------------------------
        string sentencePattern = @"^[^.!?]+[.!?]$";

        Console.WriteLine(
            $"Sentence \"Hello there.\": {Regex.IsMatch("Hello there.", sentencePattern)} | " +
            $"\"Wait...\": {Regex.IsMatch("Wait...", sentencePattern)} | " +
            $"\"Really?\": {Regex.IsMatch("Really?", sentencePattern)}"
        );
    }

    private static bool IsValidPassword(string password)
    {
        return password.Length >= 8 &&
               Regex.IsMatch(password, @"[A-Z]") &&
               Regex.IsMatch(password, @"\d");
    }
}
