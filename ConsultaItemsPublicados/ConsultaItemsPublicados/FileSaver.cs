using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsultaItemsPublicados
{
    public class FileSaver
    {

        public void SaveFile(string content, string sellerId, string siteId) 
        {
            var guid = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            Directory.CreateDirectory(directory);
            var exFileName = Path.Combine(directory, $"ConsultaItems-{siteId}-{sellerId}-{guid}.log");

            File.AppendAllText(exFileName, content);
        }
    }
}
