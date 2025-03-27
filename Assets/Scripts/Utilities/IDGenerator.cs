using System;
using System.Collections.Generic;
using System.Linq;


namespace Utilities
{
    public static class IDGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly System.Random _random = new System.Random();

        public static string GenerateUniqueID(ISet<string> existingIDs = null, int length = 8)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be positive", nameof(length));

            string newID;
            int attempts = 0;
            const int MaxAttempts = 100;

            do
            {
                newID = GenerateRandomID(length);
                attempts++;

                if (attempts >= MaxAttempts)
                    throw new Exception($"Failed to generate unique ID after {MaxAttempts} attempts");

            } while (existingIDs != null && existingIDs.Contains(newID));

            return newID;
        }

        public static string GenerateRandomID(int length = 8)
        {
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}


