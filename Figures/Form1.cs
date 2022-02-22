using Figures2.Logic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figures2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FigureCB.Items.AddRange(Enum.GetNames(typeof(Figures)));
            FigureCB.SelectedIndex = 0;
            renderMode.Items.AddRange(Enum.GetNames(typeof(RenderMode)));
            renderMode.SelectedIndex = 0;
            selectedFigures = new List<Figure>();
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = bitmap;
        }

        enum Figures
        {
            Circle,
            Square,
            Triangle
        }

        enum RenderMode
        {
            Fill,
            Sdf
        }

        #region vars
        List<Figure> figureList = new List<Figure>();
        List<Figure> selectedFigures;
        Figures figToCreate;
        RenderMode modeToRender;
        private int oldX;
        private int oldY;
        Bitmap bitmap;
        #endregion


        private void Form1_Resize(object sender, EventArgs e)
        {
            canvas.Width = this.Width - 10;
            canvas.Height = this.Height - 10;
            var tempBitmap = bitmap;

            bitmap = new Bitmap(canvas.Width, canvas.Height);
            bitmap = tempBitmap.Clone(new Rectangle(0,0, tempBitmap.Width, tempBitmap.Height), System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            canvas.Image = bitmap;
        }

        private void FigureCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (sender as ToolStripComboBox);

            if (item == null)
                return;

            switch(item.SelectedItem.ToString())
            {
                case "Circle":
                    figToCreate = Figures.Circle;
                    break;
                case "Square":
                    figToCreate= Figures.Square;
                    break;
                case "Triangle":
                    figToCreate = Figures.Triangle;
                    break;
            }

            canvas.Focus();
        }

        private void AddFigure_Click(object sender, EventArgs e)
        {
            var middlePoint = new PointF(canvas.Width / 2, canvas.Height / 2);
            var selectedColor = figureColor.BackColor;
            int id = 0;

            switch(figToCreate)
            {
                case Figures.Circle:
                    
                    var circle = new Circle(new Vec2(middlePoint.X, middlePoint.Y));
                    circle.SetRadius(20);
                    circle.color = new RGB(selectedColor.R, selectedColor.G, selectedColor.B);
                    id = figureList.Where(x => x.name.Contains("circle")).Count() + 1;
                    circle.localId = id;
                    circle.name = "circle" + id;
                    figureList.Add(circle);
                    FiguresLB.Items.Add(circle);
                    break;
                case Figures.Square:

                    var square = new Square(100, new Vec2(middlePoint.X, middlePoint.Y));
                    square.color = new RGB(selectedColor.R, selectedColor.G, selectedColor.B);
                    id = figureList.Where(x => x.name.Contains("square")).Count() + 1;
                    square.localId = id;
                    square.name = "square" + id;
                    figureList.Add(square);
                    FiguresLB.Items.Add(square);
                    break;
                case Figures.Triangle: 
                    var triangle = new Triangle(40, new Vec2(middlePoint.X, middlePoint.Y));
                    triangle.color = new RGB(selectedColor.R, selectedColor.G, selectedColor.B);
                    id = figureList.Where(x => x.name.Contains("triangle")).Count() + 1;
                    triangle.localId = id;
                    triangle.name = "triangle" + id;
                    figureList.Add(triangle);
                    FiguresLB.Items.Add(triangle);
                    break;
            }

            canvas.Invalidate();
        }

        //private void canvas_Paint(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

        //    foreach (var item in figureList)
        //    {
        //        item.Draw(e.Graphics);
        //    }            
        //}

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {

            if (Control.ModifierKeys != Keys.Shift)
            {
                selectedFigures = new List<Figure>();
                foreach (var figure in figureList)
                {
                    figure.isSelected = false;
                }
            }

            foreach (var figure in figureList)
            {                
                if (figure.IsInside(new Vec2(e.X, e.Y)))
                {
                    figure.isSelected = true;
                    selectedFigures.Add(figure);
                    FiguresLB.SelectedItem = figure;
                    if (Control.ModifierKeys == Keys.Shift)
                        continue;

                    break;
                }
            }
            canvas.Invalidate(true);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                foreach (var figure in selectedFigures)
                {
                    if (figure.isSelected)
                    {
                        var dx = e.X - oldX; 
                        var dy = e.Y - oldY;

                        figure.pos.x += dx;
                        figure.pos.y += dy;
                    }
                }
                canvas.Invalidate();
            }

            oldX = e.X;
            oldY = e.Y;
        }

        private void FiguresLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var sendr = sender as ListBox;

            //if (sendr.SelectedItems == null && sendr.SelectedItem == null)
            //{
            //    selectedFigures.Clear();
            ////    foreach (var fgr in figureList)
            ////    {
            ////        fgr.isSelected = false;
            ////    }
            //}

            //if (sendr.SelectedItem != null && sendr.SelectedItems == null)
            //{

            //}
            if (Control.ModifierKeys == Keys.Shift)
                return;

            selectedFigures.Clear();

            foreach (var fgr in figureList)
            {
                fgr.isSelected = false;
            }

            var item = (sender as ListBox).SelectedItem;
            var figures = figureList.Where(x => x == item).ToList();
            selectedFigures.AddRange(figures.ToArray());
            foreach (var figure in selectedFigures)
            {
                figure.isSelected = true;
            }
            canvas.Invalidate(true);
        }

        private void RemoveFigure_Click(object sender, EventArgs e)
        {
            if (selectedFigures.Count() == 0)
                return;

            DialogResult dialogResult = MessageBox.Show($"Вы уверены что хотите удалить объект?", "Подтверждение действия", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var temp = new List<Figure>();
                temp.AddRange(selectedFigures.ToArray());
                foreach (var figure in temp)
                {
                    figureList.Remove(figure);
                    FiguresLB.Items.Remove(figure);
                }
                canvas.Invalidate();
            }            
        }

        private void FiguresLB_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var figure = (sender as ListBox).SelectedItem as Figure;
            RenameFigure(figure);
        }

        private void RenameFigure(Figure figure)
        {
            var stringResult = Interaction.InputBox("Введите новое имя для фигуры", "Переименовка объекта", figure.name);

            if (String.IsNullOrWhiteSpace(stringResult))
            {
                MessageBox.Show("Новое имя фигуры не может быть пустым!", "Ошибка");
                return;
            }

            var isExist = figureList.Where(x => x.name == stringResult && x == figure).Any();

            if (isExist)
            {
                MessageBox.Show("Введённое имя уже занято, выберите другое!");
                return;
            }

            figure.name = stringResult;
            FiguresLB.Items.Clear();
            FiguresLB.Items.AddRange(figureList.ToArray());
        }

        private void canvas_DoubleClick(object sender, MouseEventArgs e)
        {
            foreach (var figure in figureList)
            {
                figure.isSelected = false;
            }

            foreach (var figure in figureList)
            {
                if (figure.IsInside(new Vec2(e.X, e.Y)))
                {
                    figure.isSelected = true;
                    RenameFigure(figure);
                                        
                    break;
                }
            }
        }

        private void figureColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                figureColor.BackColor = colorDialog.Color;
            }

        }

        private void selectedFigureColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFigureColor.BackColor = colorDialog.Color;

                foreach (var figure in selectedFigures)
                {
                    figure.color = new RGB(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                    canvas.Invalidate();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bitmap.MakeTransparent();

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    RGB c = new RGB(255,255,255);

                    Vec2 vec = new Vec2(x, y);
                    var dmin = 100.0f;

                    switch(modeToRender)
                    {
                        case RenderMode.Fill:
                            foreach (var figure in figureList)
                            {
                                if (figure.IsInside(new Vec2(x, y)))
                                {
                                    c = figure.color;
                                }
                            }                            
                            break;
                        case RenderMode.Sdf:
                            foreach (var figure in figureList)
                            {
                                var d = figure.Sdf(vec);
                                if (d < dmin) dmin = d;
                            }

                            c = new RGB(dmin / 100.0f);
                            break;
                    }

                    bitmap.SetPixel(x, y, c.GetColor());
                }
            }
            canvas.Invalidate();
        }

        private void renderMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (sender as ToolStripComboBox);

            if (item == null)
                return;

            switch (item.SelectedItem.ToString())
            {
                case "Fill":
                    modeToRender = RenderMode.Fill;
                    break;
                case "Sdf":
                    modeToRender = RenderMode.Sdf;
                    break;
                
            }

            canvas.Focus();
        }
    }
}
