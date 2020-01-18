using System;
using System.IO;
using System.Timers;
using System.Threading;
using System.Diagnostics;
using System.ServiceProcess;


namespace MyFirstService
{
    public partial class LogService : ServiceBase
    {
        System.Timers.Timer timer =
            new System.Timers.Timer(); // name space(using System.Timers;)

        public LogService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed +=
                new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 60000; //ms Periods
            timer.Enabled = true;
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            GetValues();
        }
        public static void GetValues()
        {
            PerformanceCounter cpuCounter =
                new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter ramCounter =
                new PerformanceCounter("Memory", "% Committed Bytes In Use");
            cpuCounter.NextValue();

            Thread.Sleep(100);

            string outPut =
                $"{DateTime.Now.Date.Year}-{DateTime.Now.Date.Month}-{DateTime.Now.Date.Day} {DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss\\.fff")} ** CPU:{(Int32)cpuCounter.NextValue()}% ** RAM:{(Int32)ramCounter.NextValue()}%";
            WriteToFile(outPut);
        }

        public static void WriteToFile(string Message)
        {
            string path =
                AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath =
                AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Log" + ".txt";

            if (!File.Exists(filepath))
            {
                // Create a file for write.
                using (StreamWriter sw =
                    File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw =
                    File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
