using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _000_NOTEPAD
{
    class Caesar
    {
        public static string Encrypt(string text, int key)
        {
            string newtext = "";

            foreach (char c in text)
            {
                int n = c;

                if (c >= 'A' && c <= 'Z')
                {
                    n = n + key;
                    if (n > 'Z')
                        n = n - 26;
                }

                if (c >= 'a' && c <= 'z')
                {
                    n = n + key;
                    if (n > 'z')
                        n = n - 26;
                }

                newtext += (char)n;
            }

            return newtext;
        }

        public static string Decrypt(string text, int key)
        {
            string newtext = "";

            foreach (char c in text)
            {
                int n = c;

                if (c >= 'A' && c <= 'Z')
                {
                    n = n - key;
                    if (n < 'A')
                        n = n + 26;
                }

                if (c >= 'a' && c <= 'z')
                {
                    n = n - key;
                    if (n < 'a')
                        n = n + 26;
                }

                newtext += (char)n;
            }

            return newtext;
        }
    }
}
