using System;
using System.Collections.Generic;
using System.Text;

namespace Lexov.Models.Headers
{
    public static class Spotify
    {
        public static readonly Dictionary<string, string> Headers;

        static Spotify()
        {
            Headers = new Dictionary<string, string>()
            {
                {"Authorization", "BQDb8BUmsoo5DCpNCAWSzXNvbqBhoCNixuPpEhN__gX54c_T6pbz6KA0cvLMkTOtVL5s9_pThf46L59zEsVKx_KeiaoDfK-RNVtZDVMzi7XdC_CSBefEChgteYQjETgSUZ4LknKa3Qh83Yqxcg" },
            };
        }
    }
}
