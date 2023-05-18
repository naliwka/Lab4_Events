using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_4
{
    public class FinalAction : IAction
    {
        public event EventHandler<NextActionEvent> NextActionRequested;
        public void Execute()
        {
            Console.WriteLine("Виконано фінальну дію");

            // Кінець робочого процесу
        }

        protected virtual void OnNextActionRequested(NextActionEvent e)
        {
            NextActionRequested?.Invoke(this, e);
        }
    }
}
