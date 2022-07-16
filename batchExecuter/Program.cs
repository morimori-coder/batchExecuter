using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace batchExecuter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // コマンドライン引数で検索したい単語リスト用のファイルパスを渡している
            List<string> allLineText = File.ReadAllLines(args[0]).ToList();
            ProcessStartInfo processInfo;

            foreach (var line in allLineText)
            {
                processInfo = new ProcessStartInfo("cmd.exe", $@"/c .\sample.bat { line }");
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;

                using (Process process = Process.Start(processInfo))
                {
                    process.WaitForExit();
                }
            }
        }
    }
}
