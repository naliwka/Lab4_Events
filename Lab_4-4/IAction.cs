using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_4
{
    public interface IAction
    {
        event EventHandler<NextActionEvent> NextActionRequested; // Подія для запуску наступної дії

        void Execute();
    }
}
