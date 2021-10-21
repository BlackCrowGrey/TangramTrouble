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

namespace LevelMaker
{
    /// <summary>
    /// Created by: Dylan Mahala
    /// Created on: 10/20/21
    /// Purpose: Level Designer for Tangram Trouble
    /// </summary>
    public partial class Form1 : Form
    {
        //Notes:
        //Square(Large) : SL
        //Square(Small) : SS
        //Triangle(Large) : TL
        //Triangle(Medium) : TM
        //Triangle(Small) : TS
        //Parallelogram : P
        //Rectangle(Short) : RS
        //Rectangle(Medium) : RM
        //Rectangle(Long) : RL
        //L-Block : L
        //J-Block : J
        //T-Block : T
        //S-Block : S
        //Z-Block : Z

        StreamWriter sw = File.CreateText("../../../Level.txt");

        public Form1()
        {
            InitializeComponent();
        }

        //Generates the final file
        private void generateButton_Click(object sender, EventArgs e)
        {
            sw.WriteLine(previewBox.Text);
            sw.Close();
        }

        //Adding the shapes using the checked and unchecked boxes
        private void shapeCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                //Large Square
                case 0:
                    previewBox.Text += " LS ";
                    break;
                //Small Square
                case 1:
                    previewBox.Text += " SS ";
                    break;
                //Large Triangle
                case 2:
                    previewBox.Text += " TL ";
                    break;
                //Medium Triangle
                case 3:
                    previewBox.Text += " TM ";
                    break;
                //Small Triangle
                case 4:
                    previewBox.Text += " TS ";
                    break;
                //Parallelogram
                case 5:
                    previewBox.Text += " P ";
                    break;
                //Short Rectangle
                case 6:
                    previewBox.Text += " RS ";
                    break;
                //Medium Rectangle
                case 7:
                    previewBox.Text += " RM ";
                    break;
                //Long Rectangle
                case 8:
                    previewBox.Text += " RL ";
                    break;
                //L-Block
                case 9:
                    previewBox.Text += " L ";
                    break;
                //J-Block
                case 10:
                    previewBox.Text += " J ";
                    break;
                //T-Block
                case 11:
                    previewBox.Text += " T ";
                    break;
                //S-Block
                case 12:
                    previewBox.Text += " S ";
                    break;
                //Z-Block
                case 13:
                    previewBox.Text += " Z ";
                    break;
                default:
                    break;
            }
        }

        private void heightBox_TextChanged(object sender, EventArgs e)
        {
            HeightWidth();
        }

        private void widthBox_TextChanged(object sender, EventArgs e)
        {
            HeightWidth();
        }

        void HeightWidth()
        {
            if (heightBox.Text != "" && widthBox.Text != "")
            {
                try
                {
                    int height = Int32.Parse(heightBox.Text);
                    int width = Int32.Parse(widthBox.Text);

                    previewBox.AppendText(Environment.NewLine + height + " " + width);
                }
                catch (Exception)
                {
                    previewBox.AppendText(Environment.NewLine + "Error in Parse");
                }
            }
            
        }
    }
}
