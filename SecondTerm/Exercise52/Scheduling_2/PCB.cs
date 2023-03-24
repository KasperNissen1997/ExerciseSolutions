using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_2
{
    public class PCB
    {
        public enum ProcessStateType
        {
            New,
            Ready,
            Run,
            Exit,
            Wait
        };

        private string _processName;
        public string ProcessName
        {
            get { return _processName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                    _processName = "Name not specified";
                else 
                    _processName = value;
            }
        }

        private int _processPriority;
        public int ProcessPriority
        {
            get { return _processPriority; }

            set
            {
                if (value <= 0)
                    _processPriority = 1;
                else 
                    _processPriority = value;
            }
        }

        public ProcessStateType ProcessState { get; set; }

        public PCB() : this(null, 1) { }

        public PCB(string name, int priority)
        {
            ProcessName = name;
            ProcessPriority = priority;

            ProcessState = ProcessStateType.New;
        }

        public override string ToString()
        {
            return $"{ProcessName}({ProcessPriority})";
        }
    }
}
