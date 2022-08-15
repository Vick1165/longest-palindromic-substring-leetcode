using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_palindromic_substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "cbbd";
            var output = LongestPalindrome(s);
            Console.WriteLine(output);
        }

        public static string LongestPalindrome(string s)
        {
            int startIndex = 0, maxLength = 0;

            if (string.IsNullOrEmpty(s) || s.Length < 2)
            {
                return s;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                // assume odd length, try to extend Palindrome as possible
                ExtendPalindrome(i, i);

                // assume even length.
                ExtendPalindrome(i, i + 1);
            }

            string result = s.Substring(startIndex, maxLength);
            return result;

            void ExtendPalindrome(int start, int end)
            {
                while (start >= 0 && end < s.Length && s[start] == s[end])
                {
                    start--;
                    end++;
                }

                if (maxLength < end - start - 1)
                {
                    startIndex = start + 1;
                    maxLength = end - start - 1;
                }
            }
        }

        
    }
}
