using System;
using System.IO;

namespace ExcelToProtobuf
{
    class Program
    {
        static void Main(string[] args)
        {

            string exePath = Directory.GetCurrentDirectory();
            Common.InitFloder();

            if (Directory.Exists(Common.Excelpath) && Directory.Exists(Common.ProtosPath))
            {
                string[] paths = ReadExcel.GetAllExcelPaths(Common.Excelpath);
                ReadExcel.CreateClientFile(Common.ProtosPath);
                for (int i = 0; i < paths.Length; i++)
                {
                    ReadExcel.OpenExcel(paths[i]);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Excel表全部转换完成！！！");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("开始转换C#类…………");
                bool isGenerat = GeneratClass.CallProtoc(Common.buildProtoBatPath);
                Console.WriteLine("转换C#类完成…………");

                if (isGenerat)
                {
                    Console.WriteLine("开始编译C#类…………");
                    string dllPath = exePath + "\\Google.Protobuf.dll";
                    bool isCompiler = Compiler2Dll.Compiler(Common.CsharpPtah, Common.CsharpPtah, dllPath);
                    Console.WriteLine("编译C#类完成…………");

                    if (isCompiler)
                    {
                        Console.WriteLine("开始序列化数据……");
                        Excel2Bytes.Data(Common.CsharpPtah, Common.Excelpath);
                        Console.WriteLine("序列化数据完成…………");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("编表全部结束！！！");
            }

            Console.ReadKey();
        }
    }
}
