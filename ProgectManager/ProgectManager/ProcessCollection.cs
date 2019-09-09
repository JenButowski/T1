using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ProgectManager.Exceptions;

namespace ProgectManager
{
    internal class ProcessCollection
    {
        public List<Process> ListofProcess { get; } = new List<Process>();

        public ProcessCollection()
        {
            CreateProcessCollection();
        }

        public void KillProcessById(int idProcess)
        {
            try
            {
                foreach (var process in ListofProcess)
                {
                    if (process.Id == idProcess)
                    {
                        process.Kill();
                        Console.WriteLine("Sucsess");
                    }
                    else
                        throw new Exception("No process with this Id");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void KillProcessByName(string processname)
        {
            var IsKilled = false;
            try
            {
                foreach (var process in ListofProcess)
                {
                    if (process.ProcessName == processname)
                    {
                        process.Kill();
                        IsKilled = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sucsess {process.ProcessName} is killed");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (process == ListofProcess.Last() && IsKilled == false)
                        throw new ProcessNameException("No process with this name");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ListInfo()
        {
            foreach (var process in ListofProcess)
            {
                Console.WriteLine($"{process.Id} {process.ProcessName}");
            }
        }

        private void CreateProcessCollection()
        {
            var listofprocess = Process.GetProcesses(".").ToList();
            if (listofprocess.Capacity != 0)
            {
                foreach (var process in listofprocess)
                {
                    ListofProcess.Add(process);
                }
            }
        }
    }
}