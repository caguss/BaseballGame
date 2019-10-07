using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickTheSameFruit
{
    public partial class CuteControl : Button
    {

        private Color m_color1 = Color.LightBlue;
        private Color m_color2 = Color.LightGreen;
        private int m_color1Trans = 100;
        private int m_color2Trans = 100;
        public Color CuteColor1
        {
            get { return m_color1; }
            set { m_color1 = value; Invalidate(); }
        }
        public Color CuteColor2
        {
            get { return m_color2; }
            set { m_color2 = value; Invalidate(); }
        }
        public CuteControl()
        {
            InitializeComponent();
        }

        public int Color1Trans { get => m_color1Trans; set {m_color1Trans = value;Invalidate(); } }
        public int Color2Trans { get => m_color2Trans; set { m_color2Trans = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Color c1 = Color.FromArgb(m_color1Trans,m_color1);
            Color c2 = Color.FromArgb(m_color2Trans,m_color2);
            Brush brush = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, m_color1, m_color2,10);
            pe.Graphics.FillRectangle(brush, ClientRectangle);
        }

    }
}
