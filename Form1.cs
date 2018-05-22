using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace Project_1._0
{

    public partial class Form1 : Form
    {
        string screenWidth , screenHeight;
        int status;
        Point trackBarfirstpoint;
        Point SBarfirstpoint;
        StreamWriter sw;
        string path;
        string WichQue;
        string XTrackBar, YTrackBar, WTrackBar, HTrackBar;
        string XSBar, YSBar, WSBar, HSBar;
        string from, to;
        string obj1x, obj1y, obj1rt , obj1rto;
        string opx, opy, oprt , oprto;
        string obj2x, obj2y, obj2rt , obj2rto;
        ArrayList blocks;
        int currentQuestion;
        double timerStart = 0;
        double timerEnd = 0;
        

        public Form1()
        {
            this.screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            this.screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
            status = 0;
            path = "";
            this.WichQue = "";
            this.XTrackBar = this.YTrackBar = this.WTrackBar = this.HTrackBar = "";
            this.XSBar = this.YSBar = this.WSBar = this.HSBar = "";
            this.from = this.to = "";
            this.obj1x = this.obj1y = this.obj1rt = this.obj1rto = "0";
            this.opx = this.opy = this.oprt= this.oprto = "0";
            this.obj2x = this.obj2y = this.obj2rt = this.obj2rto = "0";
            this.currentQuestion = 0;
            this.blocks = new ArrayList();
            InitializeComponent();
            panel1.BringToFront();
            startButton.Enabled = false;
           
            
            timer1.Start();
            readFile(Application.StartupPath+"/input.txt");
            NextQ.SetBounds((int.Parse(this.screenWidth) / 2)-50, panel6.Height-100 , 100, 75);
            idInput.SetBounds(40, 23, 100, 100);
            ID.SetBounds(5, 20, 50, 20);
            startButton.SetBounds(int.Parse(screenWidth) - 150, panel7.Height-35, 100, 30);
            
        }
        
        public void readFile(string path)
        {
            StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8);
            string line = sr.ReadLine();
            int i = 0;
            while (line != null)
            {
                blocks.Add(line);
                line = sr.ReadLine();
            }
        }

        private void Form1_KeyDown_RL(object sender, KeyEventArgs e)
        {
           
            if (int.Parse(WichQue) == 1)
            {
                int x = SBar.Location.X;
                int y = SBar.Location.Y;

                if (e.KeyCode == Keys.Right) x += 1;
                else if (e.KeyCode == Keys.Left) x -= 1;

                if (x >= int.Parse(from) && x <= int.Parse(to)-SBar.Width)
                {
                    SBar.Location = new Point(x, y);
                }
              
           
            }
            else if (int.Parse(WichQue) == 2)
            {
                int x = trackBar1.Location.X;
                int y = trackBar1.Location.Y;
                trackBar1.Select();
                if (e.KeyCode == Keys.Right) x += 1;
                else if (e.KeyCode == Keys.Left) x -= 1;

                if (x >= int.Parse(from) && x <= int.Parse(to))
                {
                    trackBar1.Location = new Point(x, y);
                }
                else if (x < int.Parse(from))
                {
                    x = int.Parse(from);
                }
                else if (x > int.Parse(to))
                {
                    x = int.Parse(to);

                }
                
            }
        }

        private void Form1_KeyDown_UD(object sender, KeyEventArgs e)
        {

            if (int.Parse(WichQue) == 1)
            {
                int x = SBar.Location.X;
                int y = SBar.Location.Y;

                if (e.KeyCode == Keys.Up) x += 1;
                else if (e.KeyCode == Keys.Down) x -= 1;

                if (x >= int.Parse(from) && x <= int.Parse(to) - SBar.Width)
                {
                    SBar.Location = new Point(x, y);
                }


            }
            else if (int.Parse(WichQue) == 2)
            {
                int x = trackBar1.Location.X;
                int y = trackBar1.Location.Y;
                trackBar1.Select();
                if (e.KeyCode == Keys.Up) x += 1;
                else if (e.KeyCode == Keys.Down) x -= 1;

                if (x >= int.Parse(from) && x <= int.Parse(to))
                {
                    trackBar1.Location = new Point(x, y);
                }
                else if (x < int.Parse(from))
                {
                    x = int.Parse(from);
                }
                else if (x > int.Parse(to))
                {
                    x = int.Parse(to);

                }

            }
        }

        public void trackBarINIT()
        {

            trackBar1.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left) { trackBarfirstpoint = Control.MousePosition; }
            };

            trackBar1.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(trackBarfirstpoint.X - temp.X, trackBarfirstpoint.Y - temp.Y);

                    if (trackBar1.Location.X >= int.Parse(from) && trackBar1.Location.X <= int.Parse(to))
                    {
                        trackBar1.Location = new Point(trackBar1.Location.X - res.X, trackBar1.Location.Y);
                 
                        trackBarfirstpoint = temp;
                    }
                    else if (trackBar1.Location.X < int.Parse(from))
                    {
                        trackBar1.Location = new Point(int.Parse(from), trackBar1.Location.Y);
                    }
                    else if (trackBar1.Location.X > int.Parse(to))
                    {
                        trackBar1.Location = new Point(int.Parse(to), trackBar1.Location.Y);
                    }

                }
            };
        }

        public void SBarINIT()
        {
            SBar.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left) { SBarfirstpoint = Control.MousePosition; }
            };

            SBar.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(SBarfirstpoint.X - temp.X, SBarfirstpoint.Y - temp.Y);

                    if (SBar.Location.X >= int.Parse(from) && SBar.Location.X <= int.Parse(to) - SBar.Width)
                    {
                        SBar.Location = new Point(SBar.Location.X - res.X, SBar.Location.Y);
                  
                        SBarfirstpoint = temp;
                    }
                    else if (SBar.Location.X < int.Parse(from))
                    {
                        SBar.Location = new Point(int.Parse(from), SBar.Location.Y);
                    }
                    else if (SBar.Location.X > int.Parse(to) - SBar.Width )
                    {
                        SBar.Location = new Point(int.Parse(to) - SBar.Width, SBar.Location.Y);
                    }

                }
            };
        }

        public void ReadString(string s)
        {
            obj1.Text = "";
            op.Text = "";
            obj2.Text = "";
            WichQue = "";
            this.XTrackBar = "";//where is ticker
            this.YTrackBar = "";//where to start
            this.WTrackBar = "";//how long is the line
            this.HTrackBar = "";
            this.XSBar = "";
            this.YSBar = "";
            this.WSBar = "";
            this.HSBar = "";
            this.from = "";
            this.to = "";
            this.obj1x = this.obj1y = this.obj1rt = this.obj1rto = "0";
            this.opx = this.opy = this.oprt = this.oprt= this.oprto = "0";
            this.obj2x = this.obj2y = this.obj2rt = this.obj2rto = "0";

            int parenthesis = 0;
            int where = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') parenthesis++;
            }

            if (parenthesis == 4)
            {

                obj1.Text = "";
                for (int i = 0; i < s.Length; i++)
                {

                    if (s[i] == '(' || s[i] == ',' || s[i] == ')')
                    {
                        where++;
                        continue;
                    }
                    if (where == 0)
                    {
                        obj1.Text = obj1.Text + s[i];
                    }
                    else if (where == 1)
                    {
                        obj1x = obj1x + s[i];
                    }
                    else if (where == 2)
                    {
                        obj1y = obj1y + s[i];
                    }
                    else if (where == 3)
                    {
                        obj1rt = obj1rt + s[i];
                    }
                    else if (where == 4)
                    {
                        obj1rto += s[i];
                    }
                    else if (where == 5)
                    {
                        WichQue += s[i];
                    }
                    else if(where == 6)
                    {
                        this.XTrackBar += s[i];
                    }
                    else if(where == 7)
                    {
                        this.YTrackBar += s[i];
                    }
                    else if(where == 8)
                    {
                        this.WTrackBar += s[i];
                    }
                    else if(where == 9)
                    {
                        this.HTrackBar += s[i];
                    }
                    else if (where == 11)
                    {
                        this.XSBar += s[i];
                    }
                    else if (where == 12)
                    {
                        this.YSBar += s[i];
                    }
                    else if(where == 13)
                    {
                        this.WSBar += s[i];
                    }
                    else if(where == 14)
                    {
                        this.HSBar += s[i];
                    }
                    else if(where == 16)
                    {
                        this.from += s[i];
                    }
                    else if(where == 17)
                    {
                        this.to += s[i];
                    }
                }
                obj1.SetBounds(int.Parse(obj1x), int.Parse(obj1y), 100, 100);
                obj2.Text = "";
                op.Text = "";
            }
            else if (parenthesis == 6)
            {

                obj1.Text = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(' || s[i] == ',' || s[i] == ')')
                    {
                        where++;
                        continue;
                    }
                    if (where == 0)
                    {
                        obj1.Text = obj1.Text + s[i];
                    }
                    else if (where == 1)
                    {
                        obj1x = obj1x + s[i];
                    }
                    else if (where == 2)
                    {
                        obj1y = obj1y + s[i];
                    }
                    else if (where == 3)
                    {
                        obj1rt = obj1rt + s[i];
                    }
                    else if (where == 4)
                    {
                        obj1rto = obj1rto + s[i];
                    }
                    else if (where == 5)
                    {
                        op.Text = op.Text + s[i];
                    }
                    else if (where == 6)
                    {
                        opx = opx + s[i];
                    }
                    else if (where == 7)
                    {
                        opy = opy + s[i];
                    }
                    else if (where == 8)
                    {
                        oprt = oprt + s[i];
                    }
                    else if (where == 9)
                    {
                        oprto = oprto + s[i];
                    }
                    else if (where == 10)
                    {
                        obj2.Text = obj2.Text + s[i];
                    }
                    else if (where == 11)
                    {
                        obj2x = obj2x + s[i];
                    }
                    else if (where == 12)
                    {
                        obj2y = obj2y + s[i];
                    }
                    else if (where == 13)
                    {
                        obj2rt = obj2rt + s[i];
                    }
                    else if (where == 14)
                    {
                        obj2rto = obj2rto + s[i];
                    }
                    else if(where == 15)
                    {
                        WichQue += s[i];
                    }
                    else if (where == 16)
                    {
                        XTrackBar += s[i];
                    }
                    else if(where == 17)
                    {
                        YTrackBar += s[i];
                    }
                    else if(where == 18)
                    {
                        WTrackBar += s[i];
                    }
                    else if(where == 19)
                    {
                        HTrackBar += s[i];
                    }
                    else if(where == 21)
                    {
                        XSBar += s[i];
                    }
                    else if(where == 22)
                    {
                        YSBar += s[i];
                    }
                    else if(where == 23)
                    {
                        WSBar += s[i];
                    }
                    else if(where == 24)
                    {
                        HSBar += s[i];
                    }
                    else if(where == 26)
                    {
                        from += s[i];
                    }
                    else if (where == 27)
                    {
                        to += s[i];
                    }
                }
                
                obj1.SetBounds(int.Parse(obj1x), int.Parse(obj1y), 100, 100);
                op.SetBounds(int.Parse(opx), int.Parse(opy), 100, 100);
                obj2.SetBounds(int.Parse(obj2x), int.Parse(obj2y), 100, 100);
            }
            
          

            if (int.Parse(WichQue) == 1)
            {
                this.trackBar1.SetBounds(int.Parse(XTrackBar), int.Parse(YTrackBar), int.Parse(WTrackBar), int.Parse(HTrackBar));
                this.trackBar1.Enabled = false;
                this.SBar.SetBounds(int.Parse(XSBar), int.Parse(YSBar), int.Parse(WSBar), int.Parse(HSBar));
                this.SBar.Enabled = true;
            }
            if (int.Parse(WichQue) == 2)
            {
                this.trackBar1.SetBounds(int.Parse(XTrackBar), int.Parse(YTrackBar), int.Parse(WTrackBar), int.Parse(HTrackBar));
                this.trackBar1.Enabled = true;
                this.SBar.SetBounds(int.Parse(XSBar), int.Parse(YSBar), int.Parse(WSBar), int.Parse(HSBar));
                this.SBar.Enabled = false;
            }
        
            timerStart = (new TimeSpan(DateTime.Now.Ticks)).TotalMilliseconds;

            obj1.Visible = false;
            obj2.Visible = false;
            op.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            panel1.BringToFront();
            Bitmap bmp = new Bitmap(Application.StartupPath + "/Instructions.jpg");
            Instructions.Image = bmp;



        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            SBarINIT();
            trackBarINIT();
            
        }

        private void keysRightLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true; 
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown_RL;
        }

        private void keysUPDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown_UD;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void obj2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void op_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timerEnd = (new TimeSpan(DateTime.Now.Ticks)).TotalMilliseconds;
            //Console.WriteLine(timerEnd);
            if ((timerEnd - timerStart) < int.Parse(obj1rt) || (timerEnd - timerStart) < int.Parse(oprt) || (timerEnd - timerStart) < int.Parse(obj2rt) || currentQuestion == this.blocks.Count)
            {
                NextQ.Enabled = false;
            }
            else NextQ.Enabled = true;


            if ((timerEnd - timerStart) > int.Parse(obj1rt))
            {
                obj1.Visible = true;
                obj1.BringToFront();
            }
            if ((timerEnd - timerStart) > int.Parse(obj1rto))
            {
                obj1.Visible = false;
                obj1.BringToFront();
            }
            if ((timerEnd - timerStart) > int.Parse(oprt))
            {
                op.Visible = true;
                op.BringToFront();
            }
            if ((timerEnd - timerStart) > int.Parse(oprto))
            {
                op.Visible = false;
                op.BringToFront();
            }
            if ((timerEnd - timerStart) > int.Parse(obj2rt))
            {
                obj2.Visible = true;
                obj2.BringToFront();
            }
            if ((timerEnd - timerStart) > int.Parse(obj2rto))
            {
                obj2.Visible = false;
                obj2.BringToFront();
            }
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "|*.txt";
            fd.ShowDialog();

            Console.WriteLine(fd.FileName);
            if (fd.FileName != "")
            {
                path = fd.FileName;
                readFile(path);
                startButton.Enabled = true;
                outputpath();
            }

        }
        */
        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void NextQ_Click(object sender, EventArgs e)
        {
            trackBar1.Select();
            if (currentQuestion == 0)
            {
                sw.WriteLine("Q --> " + (string)blocks[currentQuestion] + " A --> ");// + trackBar1.Value);
                currentQuestion++;
                ReadString((string)blocks[currentQuestion]);
            }
            else
            {
                sw.WriteLine("Q --> " + (string)blocks[currentQuestion] + " A --> ");// + trackBar1.Value);
                currentQuestion++;
                if (currentQuestion == this.blocks.Count)
                {
                    sw.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~  End File  ~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    sw.Close();
                    NextQ.Enabled = false;
                }
                else
                    ReadString((string)blocks[currentQuestion]);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            sw = new StreamWriter(Application.StartupPath + "/output.txt");
            sw.WriteLine("Tested ID : " + idInput.Text + "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            panel2.BringToFront();
            ReadString((string)blocks[currentQuestion]);
            menuStrip1.Enabled = false;
            menuStrip1.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void obj1_Click(object sender, EventArgs e)
        {

        }
    }
}
