using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelperClasses
{
    public class File
    {
        public File(string fileName)
        {
            this.FileName = fileName;
        }
        public string FileName { get; private set; }

        public StringBuilder ReadFile()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(this.FileName))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            catch (FileLoadException)
            {
                Console.WriteLine("File {0} cannot be loaded.", this.FileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File {0} is not found.", this.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return sb;
        }
        public void WriteFile(string text)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.FileName))
                {
                    file.Write(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
