using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime.ATCommon
{
    public static class ATCommon
    {
        public static void CopyExcelFile(string fileName, string targetPath)
        {
            try
            {
                // Check if the source file exists
                if (File.Exists(fileName))
                {
                    // Copy the file to the destination path
                    File.Copy(fileName, targetPath, true); // Set overwrite to true if you want to overwrite existing files
                }
            }
            catch (IOException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
