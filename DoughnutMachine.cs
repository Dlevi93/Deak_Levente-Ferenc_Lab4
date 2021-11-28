using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Deak_Levente_Ferenc_Lab3
{
    public class DoughnutMachine : Component
    {
        private DoughnutType mFlavor;
        public DoughnutType Flavor { get => mFlavor; set => mFlavor = value; }

        private System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList();
        public Doughnut this[int Index] { get => (Doughnut)mDoughnuts[Index]; set => mDoughnuts[Index] = value; }

        public bool Enabled { set => doughnutTimer.IsEnabled = value; }
        public int Interval { set => doughnutTimer.Interval = new TimeSpan(0, 0, value); }

        public delegate void DoughnutCompleteDelegate();
        public event DoughnutCompleteDelegate DoughnutComplete;

        DispatcherTimer doughnutTimer;

        public DoughnutMachine()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            doughnutTimer = new DispatcherTimer();
            doughnutTimer.Tick += doughnutTimer_Tick;
        }

        private void doughnutTimer_Tick(object sender, EventArgs e)
        {
            Doughnut aDoughnut = new Doughnut(this.Flavor);
            mDoughnuts.Add(aDoughnut);
            DoughnutComplete();
        }

        public void MakeDoughnuts(DoughnutType dFlavor)
        {

            Flavor = dFlavor;
            switch (Flavor)
            {
                case DoughnutType.Glazed: Interval = 3; break;
                case DoughnutType.Sugar: Interval = 2; break;
                case DoughnutType.Lemon: Interval = 5; break;
                case DoughnutType.Chocolate: Interval = 7; break;
                case DoughnutType.Vanilla: Interval = 4; break;
            }
            doughnutTimer.Start();
        }
    }

    public class Doughnut
    {
        private DoughnutType mFlavor;

        public DoughnutType Flavor { get => mFlavor; set => mFlavor = value; }
        private float mPrice = .50F;
        public float Price { get => mPrice; set => mPrice = value; }
        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation => mTimeOfCreation;

        public Doughnut(DoughnutType aFlavor) // constructor
        {
            mTimeOfCreation = DateTime.Now;
            mFlavor = aFlavor;
        }
    }

    public enum DoughnutType
    {
        Glazed,
        Sugar,
        Lemon,
        Chocolate,
        Vanilla
    }
}
