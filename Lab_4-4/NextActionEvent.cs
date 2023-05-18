using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_4
{
    public class NextActionEvent
    {
        public IAction CurrentAction { get; }

        public NextActionEvent(IAction currentAction)
        {
            CurrentAction = currentAction;
        }
    }
}
