using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTestDrawStack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static Stack<GeoGroup> _currentGroup;
        static GeoGroup _bodies;
        int x = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            _currentGroup = new Stack<GeoGroup>();
            _bodies = new GeoGroup();


            UIntPtr uIntPtr = new UIntPtr();
            //创建堆栈
            PushLevel(uIntPtr);
            //构建点
            float[] setPts = new float[2];
            for (int i = 0; i < 10; i++)
            {
                setPts = new float[2] { i * 10, i * 10 };
                AddPoint(new UIntPtr(),setPts,Color.Black);
            }

            float[] linePts = new float[10];
            for (int i = 0; i < 10; i++)
            {
                linePts[i] = i * 2;
            }
            AddLine(new UIntPtr(), linePts, Color.Black);
            _bodies.Play(this);
            //PopLevel();
        }

        void AddPoint(UIntPtr iId, float[] v0,System.Drawing.Color color)
        {
            float[] lv0 = new float[2];
            for (int i = 0; i < 2; i++)
            {
                lv0[i] = v0[i];
            }
            Point pItem = new Point(iId, lv0);
            pItem.SetColor(color);
            //_entries.Add(pItem);
            _currentGroup.Peek().items.Add(pItem);

            
            UIntPtr uIntPtr = new UIntPtr();
            float[] pointF = new float[2];
            Point point = new Point(uIntPtr, pointF);
            _currentGroup.Peek().items.Add(point);
        }
        void AddLine(UIntPtr iId, float[] aEdgePositions, System.Drawing.Color iColor)
        {
            Line pItem = new Line(iId, aEdgePositions);
            pItem.SetColor(iColor);
            //_entries.Add(pItem);
            _currentGroup.Peek().items.Add(pItem);
        }

        public void PushLevel(UIntPtr id)
        {
            GeoGroup group = new GeoGroup();
            group.ID = id;
            //if (null == _bodies)
            //{
            //    _bodies = new ViewerDLItemGroup();
            //}

            if (_currentGroup.Count > 1)
                _currentGroup.Peek().groups.Add(group);
            else
                _bodies.groups.Add(group);
            _currentGroup.Push(group);
        }
        public void PopLevel()
        {
            _currentGroup.Pop();
        }
    }

    class Point : GeoItem
    {
        float[] _v0 = new float[2];

        public Point(UIntPtr ptr, float[] v0) : base(ptr)
        {
            for (int i = 0; i < 2; i++)
            {
                _v0[i] = v0[i];
            }
        }

        public override void Play(Form1 form)
        {
            Graphics gp = form.panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            int width = 10;
            int height = 10;
            gp.DrawEllipse(pen, _v0[0]- width / 2, _v0[1] - height / 2,width,height);
        }
    }
    class Line : GeoItem
    {
        double[] pointLine;
        PointF[] pointsLine;
        public Line(UIntPtr ptr, float[]points) : base(ptr)
        {
            pointsLine = new PointF[points.Length / 2];
            for (int i = 0; i < points.Length/2; i++)
            {
                pointsLine[i].X = (float)points[i];
                int p=i+1;
                pointsLine[i].Y = (float)points[p];
            }
        }
        public override void Play(Form1 form)
        {
            Graphics gp = form.panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            gp.DrawLines(pen, pointsLine);
        }
    }

    public abstract class GeoItem
    {
        System.Drawing.Color color1 = new Color();
        public UIntPtr ID
        {
            get;
            private set;
        }
        public GeoItem(UIntPtr iId)
        {
            ID = iId;
            color1 = System.Drawing.Color.FromArgb(0, 0, 0, 0);
        }
        public abstract void Play(Form1 form);
        public virtual void SetColor(System.Drawing.Color iColor)
        {
            color1 = iColor;
        }
    }

    class GeoGroup
    {
        public GeoGroup geoGroup;
        public List<GeoGroup> groups;
        public List<GeoItem> items;
        public UIntPtr ID;

        public GeoGroup()
        {
            groups = new List<GeoGroup>();
            items = new List<GeoItem>();
            ID = (UIntPtr)0;
        }

        public void Play(Form1 form)
        {
            foreach (GeoGroup subgroup in groups)
            {
                subgroup.Play(form);
            }
            for (int i = 0; i < items.Count; i++)
            {
                GeoItem geo = items[i];
                geo.Play(form);
            }
        }
    }

}
