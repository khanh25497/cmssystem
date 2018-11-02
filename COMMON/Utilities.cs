using System;
using System.Collections.Generic;
using System.Text;

namespace COMMON
{
    class Utilities
    {
        /// <summary>
        /// Create Ngram token in a string, sereprated by space
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="n">Length of token, default 2</param>
        /// <returns></returns>
        public static string CreateNgramString(string source, int n = 2)
        {
            var tokens = new StringBuilder();
            for (int i = 0; i < source.Length - n + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tokens.Append($"{source[i + j]}");
                }
                tokens.Append(" ");
            }
            return tokens.ToString();
        }
    }
}
