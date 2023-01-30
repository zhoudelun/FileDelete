using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDelete
{
    public class FileHelp
    {
        /// <summary>
        /// 删除文件夹以及文件
        /// </summary>
        /// <param name="directoryPath"> 文件夹路径 </param>
        /// <param name="fileName"> 文件名称 </param>
        public static void DeleteDirectory(string directoryPath, string fileName)
        {

            //删除文件
            for (int i = 0; i < Directory.GetFiles(directoryPath).ToList().Count; i++)
            {
                if (Directory.GetFiles(directoryPath)[i] == fileName)
                {
                    File.Delete(fileName);
                }
            }

            //删除文件夹
            for (int i = 0; i < Directory.GetDirectories(directoryPath).ToList().Count; i++)
            {
                if (Directory.GetDirectories(directoryPath)[i] == fileName)
                {
                    Directory.Delete(fileName, true);
                }
            }
        }
        /// <summary>
        /// 删除文件夹 循环嵌套
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="floderName"></param>
        public static void DeleteFloder(string directoryPath, string floderName,string[] fileName) {
            DirectoryInfo currentFolder = new DirectoryInfo(directoryPath);
            if (!currentFolder.Exists)
            {
                return;
            }
            if (currentFolder.GetFiles().Count() == 0 && currentFolder.GetDirectories().Count() == 0)
            {
                currentFolder.Delete(true);
                return;
            }
            //file delete
            foreach (var f in currentFolder.GetFiles().Where(w => fileName.Contains(w.Name)))
            {
                f.Delete();
            }  

            //floder delete            
            foreach (var f in currentFolder.GetDirectories())
            {
                if (f.Name == floderName)
                {
                    try
                    { 
                        f.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                }
                else
                {
                    DeleteFloder(f.FullName, floderName,fileName); 
                }
            }
             
            ////删除文件夹
            //for (int i = 0; i < Directory.GetDirectories(directoryPath).ToList().Count; i++)
            //{
            //    if (Directory.GetDirectories(directoryPath)[i] == name)
            //    {
            //        Directory.Delete(name, true);
            //        break;
            //    }
            //    else
            //    {
            //        DeletFloder(Directory.GetDirectories(directoryPath)[i], name);
            //    }
            //}
        }

        public static void DeleteEmptyFloder(string directoryPath )
        {
            DirectoryInfo currentFolder = new DirectoryInfo(directoryPath);
            if (currentFolder.GetFiles().Count() == 0 && currentFolder.GetDirectories().Count() == 0)
            {
                currentFolder.Delete(true);

            }
            else
            { 
                foreach (var f in currentFolder.GetDirectories())
                {
                    DeleteEmptyFloder(f.FullName);
                }
            }

        }
    }
}
