using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActionLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Name testName = new Name("Koani");
            testName.ShowName = () => testName.DisplayToWindow();

            testName.Show();
        }
    }
    public class Name
    {
        private string instanceName;
        public Action ShowName;
        public void Show()
        {
            if(ShowName != null)
         ShowName();
        }
        public Name(string name)
        {
            this.instanceName = name;
        }
        public void DisplayToConsole()
        {
            Console.WriteLine(this.instanceName);
        }
        public void DisplayToWindow()
        {
            MessageBox.Show(this.instanceName);
        }
    }
}
