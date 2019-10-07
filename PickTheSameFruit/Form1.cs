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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rand = new Random();
        int count = 0;
        Button firstbtn = null;
        Button secondbtn = null;
        int time;
        int point;
        int answerCount = 0;
        private void 시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] randompic = new int[16];
            bool isSame;
            for (int i = 0; i < randompic.Length; i++)
            {
                while (true)
                {
                    randompic[i] = rand.Next(1, 17);
                    isSame = false;
                    for (int k = 0; k < i; k++)
                    {
                        if (randompic[k] == randompic[i])
                        {
                            isSame = true;
                        }
                    }
                    if (!isSame) break;
                }
                
            }
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                Button temp1 = (Button)panel1.Controls[i];
                temp1.ImageIndex = (randompic[i]%8) + 1;
                temp1.Tag = (randompic[i] % 8) + 1;
            }
        timer1.Start();
        }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (Button item in panel1.Controls)
            {
                item.ImageIndex = 0;
                item.Enabled = true;
            }
            timer3.Start();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ImageIndex = Convert.ToInt32(btn.Tag);
            count++;

            if (firstbtn == null)
            {
                firstbtn = btn;
            }
            else
            {
                if (secondbtn != null)
                    return;

                secondbtn = btn;
                //foreach (Button item in panel1.Controls)
                //{
                //    item.Enabled = false;
                //}
                timer2.Start();
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32( firstbtn.Tag) != Convert.ToInt32( secondbtn.Tag))
            {
                
                foreach (Button item in panel1.Controls)
                {
                    if (Convert.ToInt32(item.Tag) == Convert.ToInt32(firstbtn.Tag))
                        item.ImageIndex = 0;

                    if (Convert.ToInt32(item.Tag) == Convert.ToInt32(secondbtn.Tag))
                        item.ImageIndex = 0;
                }
            }
            else
            {
                
                firstbtn.Enabled = false;
                secondbtn.Enabled = false;
                answerCount++;

                if(answerCount == 8)
                {
                    MessageBox.Show("축하합니다! 성공하셨습니다!", "축하합니다!", MessageBoxButtons.OK);
                }


            }
            firstbtn = null;
            secondbtn = null;
            timer2.Stop();

        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
        }
    }
}
