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
    /// Created by: Dylan Mahala, Andrew Tark
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

        
        public Form1()
        {
            InitializeComponent();
        }

        //Generates the final file
        private void generateButton_Click(object sender, EventArgs e)
        {
            if (NameBox.Text == "")
            {
                NameBox.Text = "PLEASE SUPPLY A FILE NAME";
            }

            else
            {
                StreamWriter sw = File.CreateText("../../../Levels/" + NameBox.Text + ".txt");
                sw.WriteLine(previewBox.Text);
                sw.Close();
                previewLabel.Text = "File Complete!";
            }


        }

        //Adding the shapes using the checked and unchecked boxes
        private void shapeCheckBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.Index)
            {
                //Large Square
                case 0:
                    if (!shapeCheckBox.GetItemChecked(0))
                    {
                        previewBox.Text += " LS ";
                    }
                    break;
                //Small Square
                case 1:
                    if (!shapeCheckBox.GetItemChecked(1))
                    {
                        previewBox.Text += " SS ";
                    }
                    break;
                //Large Triangle
                case 2:
                    if (!shapeCheckBox.GetItemChecked(2))
                    {
                        previewBox.Text += " TL ";
                    }
                    break;
                //Medium Triangle
                case 3:
                    if (!shapeCheckBox.GetItemChecked(3))
                    {
                        previewBox.Text += " TM ";
                    }
                    break;
                //Small Triangle
                case 4:
                    if (!shapeCheckBox.GetItemChecked(4))
                    {
                        previewBox.Text += " TS ";
                    }
                    break;
                //Parallelogram
                case 5:
                    if (!shapeCheckBox.GetItemChecked(5))
                    {
                        previewBox.Text += " P ";
                    }
                    break;
                //Short Rectangle
                case 6:
                    if (!shapeCheckBox.GetItemChecked(6))
                    {
                        previewBox.Text += " RS ";
                    }
                    break;
                //Medium Rectangle
                case 7:
                    if (!shapeCheckBox.GetItemChecked(7))
                    {
                        previewBox.Text += " RM ";
                    }
                    break;
                //Long Rectangle
                case 8:
                    if (!shapeCheckBox.GetItemChecked(8))
                    {
                        previewBox.Text += " RL ";
                    }
                    break;
                //L-Block
                case 9:
                    if (!shapeCheckBox.GetItemChecked(9))
                    {
                        previewBox.Text += " L ";
                    }
                    break;
                //J-Block
                case 10:
                    if (!shapeCheckBox.GetItemChecked(10))
                    {
                        previewBox.Text += " J ";
                    }
                    break;
                //T-Block
                case 11:
                    if (!shapeCheckBox.GetItemChecked(11))
                    {
                        previewBox.Text += " T ";
                    }
                    break;
                //S-Block
                case 12:
                    if (!shapeCheckBox.GetItemChecked(12))
                    {
                        previewBox.Text += " S ";
                    }
                    break;
                //Z-Block
                case 13:
                    if (!shapeCheckBox.GetItemChecked(13))
                    {
                        previewBox.Text += " Z ";
                    }
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
        //when the menu tooltip is clicked
        //a message box is displayed with the instructions of the level designer
        private void instructionsMenu_Click(object sender, EventArgs e)
        {
            string message = "Welcome to the Level Maker for Tanagram Trouble!" +
                "\nChoose the shapes you want to have present. " +
                "\nTo select one shape twice you must deselect and reselect it." +
                "\nMake sure to choose all shapes you want before inputting height and width" + 
                "\nDesignate a height and width in their respective boxes." +
                "\nWhatever you have chosen will be displayed in the preview window." +
                "\nPress the generate button when satisified.";
            string title = "Instructions";
            MessageBox.Show(message, title);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            heightBox.Text = "";
            widthBox.Text = "";
            previewBox.Text = "";
            for (int i = 0; i < shapeCheckBox.Items.Count; i++)
            {
                shapeCheckBox.SetItemChecked(i, false);
            }
        }
    }
}
