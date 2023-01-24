using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows;

namespace FSteamID
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam\\ActiveProcess"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("ActiveUser");
                        if (o != null)
                        {
                            long sv = Convert.ToInt64(o) / 2;
                            long convertedTo64Bit = sv * 2;
                            convertedTo64Bit += 76561197960265728;
                            convertedTo64Bit += 1;
                            if (convertedTo64Bit == 76561197960265728 || convertedTo64Bit == 76561197960265729)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Steam не запущен.");
                                Thread.Sleep(5000);
                                return;
                            }
                            Clipboard.SetText(convertedTo64Bit.ToString());
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("SteamID успешно скопирован!");
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
            catch 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("НЕВОЗМОЖНО ПРОЧИТАТЬ СТИМАЙДИ!!!");
                Thread.Sleep(5000);
            }
        }
    }
}
