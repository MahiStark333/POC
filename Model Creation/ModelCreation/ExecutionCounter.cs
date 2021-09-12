using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelCreation
{
    class ExecutionCounter
    {
        public string path { get; set; }
        public string Counter()
        {
            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ExecuteCount.txt");
            int number;
            string newCount = "0001";
            if (!File.Exists(path))
            {
                using (var txtFile = File.AppendText(path))
                {
                    txtFile.WriteLine("0001");
                }
            }
            else if (File.Exists(path))
            {
                string text = File.ReadLines(path).Last();
                number = Convert.ToInt32(text);
                int countincrease = number + 1;
                newCount = String.Format("{0:D4}", countincrease);
                using (var txtFile = File.AppendText(path))
                {
                    txtFile.WriteLine("" + newCount);
                }
            }
            return path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), newCount);
        }
    }
}
