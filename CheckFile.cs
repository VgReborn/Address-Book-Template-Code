#pragma warning disable CS8605

namespace FileType
{
    using System;
    using System.Diagnostics.Contracts;
    using Newtonsoft.Json;
    public static class Check
    {

        public static bool IsJson(string contents)
        {
            Contract.Requires(contents != null);
            if(string.IsNullOrWhiteSpace(contents)) return false;
            contents.Trim();
            if(!(contents.StartsWith("{") && contents.EndsWith("}")))
            {
                Console.WriteLine("The file contents is unreadable");
                return false;    
            }

            return true;
            
        }

    }
}