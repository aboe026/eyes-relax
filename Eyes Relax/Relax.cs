using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eyes_Relax
{
    public class Relax
    {
        public TimeSpan waitDuration { get; private set; }
        public TimeSpan relaxDuration { get; private set; }
        public DateTime timeWaitEnds { get; private set; }
        public DateTime timeRelaxEnds { get; private set; }

        public Relax(TimeSpan waitDuration, TimeSpan relaxDuration)
        {
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
