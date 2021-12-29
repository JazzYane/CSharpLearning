using System;
namespace SimpleEvent
{
    using System;
    /***********发布器类***********/
    public class EventTest
    {
        private int value;

        public delegate void NumManipulationHandler();

        //public event EventHandler<CarInfoEventArgs> NewCarInfo;


        public event NumManipulationHandler ChangeNum;
        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum(); /* 事件被触发 */
            }
            else
            {
                Console.WriteLine("event not fire");
                Console.ReadKey(); /* 回车继续 */
            }
        }

        public void change()
        {
            ChangeNum();
        }

        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }

        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }


    /***********订阅器类***********/

    public class subscribEvent
    {
        public void printf()
        {
            Console.WriteLine("event fire");
            Console.ReadKey(); /* 回车继续 */
        }
    }

    /***********触发***********/
    public class MainClass
    {
        public static void Main()
        {
            EventTest e = new EventTest(); /* 实例化对象,第一次没有触发事件 */
            subscribEvent v = new subscribEvent(); /* 实例化对象 */
            e.ChangeNum += new EventTest.NumManipulationHandler(v.printf); /* 注册 */
            //发布方:定义一个委托，定义一个委托类型的事件

            //订阅者:提供一个被调用的方法

            //绑定方:将方法通过委托和事件进行绑定

            //触发方:触发事件，执行绑定的函数,必须卸载Event事件中。
            e.SetValue(7);//里面有执行委托，执行函数
            e.SetValue(11);
            //整体流程：
            //form.control.dll：为发布者，定义各种事件和委托（1）
            //制作窗体：建立绑定，生成订阅事件的绑定（1）
            //窗体逻辑代码：订阅方，一些事件（3）
            //form.control.dll：触发方，在form里有与底层通讯的接口message，
            //检测到就进行触发，触发后就执行窗体逻辑代码（2）
            //没有检测到就ui线程等待windows队列什么的

        }
    }
}