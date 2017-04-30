using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JMap
{
    public class JTask : JObject
    {
        internal JTask(JObject source)
            : this(source, new Task[0])
        {
        }

        JTask(JObject source, IEnumerable<Task> tasks)
            : base(source)
        {
            Tasks = tasks;
        }

        IEnumerable<Task> Tasks { get; }

        public static implicit operator Task(JTask jTask) => Task.WhenAll(jTask.Tasks);
        public static JTask operator+(JTask jTask, Task task) =>
            new JTask(jTask, new List<Task>(jTask.Tasks) { task });

        public TaskAwaiter GetAwaiter() =>
            Task.WhenAll(Tasks).GetAwaiter();
    }
}
