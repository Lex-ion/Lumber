namespace Lumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool active = false;

        int last = 1;

        int skore=0;
        private void button1_Click(object sender, EventArgs e)
        {
            Prepare();

            timer1.Enabled = true;
            timer1.Start();

            active = true;
            skore =0;

            button1.Enabled = false;
            label1.Visible = false;
        }




        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                Render(1);
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                Render(2);
                return true;
            }


           
            return base.ProcessCmdKey(ref msg, keyData);
        }


        Random rnd = new Random();

        bool[] vetve = {
        true,
        true,
        true,
        true,
        true
        };

        Point drevorubec_vlevo = new Point(64,480);
        Point drevorubec_vpravo = new Point(444,480);
        public void Render(int vstup)
        {

            if (!active)
                return;

            

            progressBar1.Value = progressBar1.Maximum;

            last = vstup;

            if (vstup == 1)
            {

                if (pictureBox1.Location != drevorubec_vlevo)
                {
                    pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                pictureBox1.Location = drevorubec_vlevo;
            }else if (vstup == 2)
            {

                if (pictureBox1.Location != drevorubec_vpravo)
                {
                    pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                pictureBox1.Location=drevorubec_vpravo;
                
            }
           pictureBox1.Refresh();
            

            for (int i = 4; i > 0; i--)
            {
                vetve[i] = vetve[i-1];
            }

            if (rnd.Next() % 2 == 1)
            {
                vetve[0] = true;
            }else
            {
                vetve[0]=false;
            }
            


            if (vetve[4] && vstup == 2 || !vetve[4] && vstup == 1)
            {
                timer1.Stop();
                active = false;
                label1.Visible = true;
                button1.Enabled = true;
                return;
            }



            int j = 3;

            var pbVetve = new List<PictureBox> { Vetev3, Vetev2, Vetev1, Vetev0 };
            foreach (PictureBox element in pbVetve)
            {
                if (vetve[j])
                {

                    if (element.Location != new Point(414, element.Location.Y))
                        element.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    element.Location=new Point(414,element.Location.Y);
                    
                }
                else
                {
                    if (element.Location != new Point(164, element.Location.Y))
                        element.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);


                    element.Location = new Point(164, element.Location.Y);
                    
                }
                element.Refresh();
                j--;
            }

            skore++;
            label2.Text = $"Skore: {skore.ToString()}";

            

        }

        public void Prepare()
        {




            for (int i = 0; i < 3; i++)
            {
                if (rnd.Next() % 2 == 1)
                {
                    vetve[i] = true;
                }
                else
                {
                    vetve[i] = false;
                }
            }

            int j = 3;

            var pbVetve = new List<PictureBox> { Vetev3, Vetev2, Vetev1, Vetev0 };
            foreach (PictureBox element in pbVetve)
            {

                element.Visible = true;

                if (vetve[j])
                {

                    if (element.Location != new Point(414, element.Location.Y))
                        element.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    element.Location = new Point(414, element.Location.Y);

                }
                else
                {
                    if (element.Location != new Point(164, element.Location.Y))
                        element.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);


                    element.Location = new Point(164, element.Location.Y);

                }
                element.Refresh();
                j--;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            


            if (progressBar1.Value == 0)
            {
                progressBar1.Value = progressBar1.Maximum;
                Render(last);
            }

            progressBar1.Value--;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }



}