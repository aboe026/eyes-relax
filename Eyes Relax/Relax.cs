using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Eyes_Relax
{
    [DataContract]
    public class Relax
    {
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public TimeSpan waitDuration { get; set; }
        [DataMember]
        public TimeSpan relaxDuration { get; set; }
        public DateTime timeWaitEnds { get; set; }
        public DateTime timeRelaxEnds { get; set; }

        public Relax(String name, TimeSpan waitDuration, TimeSpan relaxDuration)
        {
            this.name = name;
            this.waitDuration = waitDuration;
            this.relaxDuration = relaxDuration;
        }
        
        public void startWait()
        {
            this.timeWaitEnds = DateTime.Now + waitDuration;
        }

        public void startRelax()
        {
            this.timeRelaxEnds = DateTime.Now + relaxDuration;
        }

        public Double percentBreak()
        {
            TimeSpan timeLeft = timeWaitEnds.Subtract(DateTime.Now);
            TimeSpan timeElapsed = waitDuration.Subtract(timeLeft);
            return timeElapsed.Ticks / (double)waitDuration.Ticks;
        }
    }
}
