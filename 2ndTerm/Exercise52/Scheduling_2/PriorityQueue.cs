using System.Text;

namespace Scheduling_2
{
    public class PriorityQueue
    {
        private List<PCB> pcbs = new();

        public void Enqueue(PCB pcb)
        {
            pcbs.Add(pcb);

            pcbs = pcbs.OrderBy(pcb => pcb.ProcessPriority).ToList();
        }

        public void Dequeue()
        {
            pcbs.RemoveAt(0);
        }

        public void Reprioritize(string processName, int newPriority)
        {
            foreach (PCB pcb in pcbs.Where(pcb => pcb.ProcessName == processName))
                pcb.ProcessPriority = newPriority;

            pcbs = pcbs.OrderBy(pcb => pcb.ProcessPriority).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append("{");

            for (int i = 0; i < pcbs.Count; i++) 
            {
                sb.Append(pcbs[i].ToString());

                if (i != pcbs.Count - 1)
                    sb.Append(",");
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}
