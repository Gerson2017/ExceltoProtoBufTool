using System.IO;
using System.Linq;

namespace ExcelToProtobuf
{
    public class Common
    {
        public static string dllName = "clientData.dll"; 
        public static string Excelpath;
        public static string ProtosPath;
        public static string buildProtoBatPath;
        public static string CsharpPtah;
        public static string ProtoDataPath;
        //明文文件夹
        public static string LawsDataPath;


        public static void InitFloder()
        {
            string exePath = Directory.GetCurrentDirectory();
            string parentPath = Directory.GetParent(exePath).FullName;
            string topPath = Directory.GetParent(parentPath).FullName;

            CsharpPtah = Path.Combine(topPath, "Csharp");
            //配置输出文件夹
            ProtoDataPath = Path.Combine(topPath, "Data");
            Excelpath = Path.Combine(topPath, "Excel");
             ProtosPath = Path.Combine(topPath, "Protos");
             buildProtoBatPath = Path.Combine(topPath, "BuildProtos.bat");
            //明文文件夹
             LawsDataPath = Path.Combine(topPath, "LawsData");
        }


        // 首字母小写为了获取字段名字
        public static string GetPbFieldName(string str)
        {
            return str.First().ToString().ToLower() + str.Substring(1)+"_";  // 加个下划线是因为pb生成的字段就是首字母小写并加上下划线
        }




      
    }
}
