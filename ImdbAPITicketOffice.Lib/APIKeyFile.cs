using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbAPITicketOffice.Lib
{
    public class APIKeyFile
    {
        public string path;
        public string Key { get; private set; }

        public APIKeyFile(string filePath)
        {
            path = filePath;
            if (File.Exists(path))
            {
                Key = File.ReadAllText(path);
            }
            else
            {
                File.Create(path);
            }
        }
    }
}
