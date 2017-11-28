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

namespace lab1
{
    public partial class Form1 : Form
    {
        private int startLevel = 5;
        private int startX = 8;
        private int startY = 4;
        private String startPath = "D:\\geoscan_labs\\map\\z";

        private List<PictureBox> pBoxes;
        private int currentLevel;
        private int currentX;
        private int currentY;

        public String ConstructPath(int level, int x, int y)
        {
            String path = startPath + level.ToString() + "\\0\\x" + x.ToString() + "\\0\\y" + y.ToString() + ".png";
            return path;
        }

        public void LoadTiles(int level, int startX, int startY)
        {
            for (int i = 0; i < 4; i++)
            {
                pBoxes[i].Image = null;
            }

            LoadFile(ConstructPath(level, startX, startY), 0);
            LoadFile(ConstructPath(level, startX + 1, startY), 1);
            LoadFile(ConstructPath(level, startX, startY + 1), 2);
            LoadFile(ConstructPath(level, startX + 1, startY + 1), 3);
        }

        public void LoadFile(String path, int index)
        {
            Bitmap tile;
            if (File.Exists(path))
            {
                tile = new Bitmap(path);
                pBoxes[index].Image = (Image)tile;
            }

        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pBoxes = new List<PictureBox>();
            pBoxes.Add(pictureBox1);
            pBoxes.Add(pictureBox2);
            pBoxes.Add(pictureBox3);
            pBoxes.Add(pictureBox4);

            LoadTiles(startLevel, startX, startY);

            currentX = startX;
            currentY = startY;
            currentLevel = startLevel;
            button2.Enabled = false;

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            currentY++;
            LoadTiles(currentLevel, currentX, currentY);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            currentY--;
            LoadTiles(currentLevel, currentX, currentY);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            currentX++;
            LoadTiles(currentLevel, currentX, currentY);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            currentX--;
            LoadTiles(currentLevel, currentX, currentY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentLevel++;
            currentX = (currentX + 1) * 2 - 1;
            currentY = (currentY + 1) * 2 - 1;

            LoadTiles(currentLevel, currentX, currentY);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentLevel--;
            currentX /= 2;
            currentY /= 2;

            LoadTiles(currentLevel, currentX, currentY);

            if (currentLevel == startLevel)
            {
                button2.Enabled = false;
            }
        }
    }
}
