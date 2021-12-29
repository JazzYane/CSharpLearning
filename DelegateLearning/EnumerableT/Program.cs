using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableT
{
    class Program
    {
        static void Main(string[] args)
        {

            float[] vs = new float[10];
            ////contractors contractors = new contractors();
            //contractors.Cos();
        }
    }
    public class contractors : co
    {
        public string coo()
        {
            return "xx";
        }
        public override void Cos()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class co
    {
        public co()
        { 
        }
        public abstract void Cos();
    }

}
