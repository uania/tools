using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Uania.Tools.T4.Common
{
    public class SaveFile
    {
        public void Save(string path, string fileContent)
        {
            var folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, fileContent);
        }

        public void Save(string baseFolder, string destinationFolder, string outputFileName, string fileContent)
        {
            var tmpPath = Path.Combine(baseFolder, destinationFolder, outputFileName + ".cs");
            this.Save(tmpPath, fileContent);
        }
    }
}