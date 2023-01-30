using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            
            flag1:
            Console.WriteLine(@"c:\f\my55 a,b,c a.jpg,b.txt");
            string readLine=Console.ReadLine();
            string[] array=readLine.Split(' ');
            if (array.Length == 1)
            {
                if (   string.IsNullOrEmpty(readLine))
                {
                    goto flag2;
                }
                FileHelp.DeleteEmptyFloder(array[0]);
            }
            else
            {
                foreach (var floder in array[1].Split(','))
                {
                    FileHelp.DeleteFloder(array[0], floder, array[2].Split(','));
                }  
            }
            Console.WriteLine("finshed!");
            goto flag1;

            flag2:
            Console.WriteLine("finshed!");
            Console.Read();
        }
    }
}
