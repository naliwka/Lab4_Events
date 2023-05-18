using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_4
{
    public class SecondAction : IAction
    {
        public event EventHandler<NextActionEvent> NextActionRequested;

        public void Execute()
        {
            Console.WriteLine("Виконано другу дію");

            // Запускаємо наступну дію
            OnNextActionRequested(new NextActionEvent(this));
        }

        protected virtual void OnNextActionRequested(NextActionEvent e)
        {
            NextActionRequested?.Invoke(this, e);
        }
    }
}
