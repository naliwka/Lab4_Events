using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAction firstAction = new FirstAction();
            IAction secondAction = new SecondAction();
            IAction thirdAction = new ThirdAction();
            IAction finalAction = new FinalAction();

            firstAction.NextActionRequested += (sender, e) => secondAction.Execute();
            secondAction.NextActionRequested += (sender, e) => thirdAction.Execute();
            thirdAction.NextActionRequested += (sender, e) => finalAction.Execute();

            firstAction.Execute();

            Console.ReadLine();
        }
    }
}
