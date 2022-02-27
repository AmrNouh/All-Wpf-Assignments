using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Drawer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorChecked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content)
            {
                case "Red":
                    ink.DefaultDrawingAttributes.Color = Colors.Red; 
                    break;
                case "Green":
                    ink.DefaultDrawingAttributes.Color = Colors.Green;
                    break;
                case "Blue":
                    ink.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;
                case "Magenta":
                    ink.DefaultDrawingAttributes.Color = Colors.Magenta;
                    break;
            }
        }

        private void ModesChecked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content)
            {
                case "Ink":
                    ink.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Select":
                    ink.EditingMode = InkCanvasEditingMode.Select;
                    break;
                case "EraseByPoint":
                    ink.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case "EraseByStroke":
                    ink.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
            }
        }

        private void ShapeChecked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content)
            {
                case "Ellipse":
                    ink.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Ellipse;
                    break;
                case "Rectangle":
                    ink.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
                    break;
            }
        }

        private void SizeChange(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content)
            {
                case "Small":
                    ink.DefaultDrawingAttributes.Width = 5;
                    ink.DefaultDrawingAttributes.Height = 5;
                    break;
                case "Normal":
                    ink.DefaultDrawingAttributes.Width = 10;
                    ink.DefaultDrawingAttributes.Height = 10;
                    break;
                case "Large":
                    ink.DefaultDrawingAttributes.Width = 20;
                    ink.DefaultDrawingAttributes.Height = 20;
                    break;
            }
        }

        private void ClearInk(object sender, RoutedEventArgs e)
        {
            if(ink.Strokes.Count > 0)
            {
                SaveInkContent(null, null);
            }
            ink.Strokes.Clear();
            path = null;
            
        }

        private void SaveInkContent(object sender, RoutedEventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "isf files (*.isf)|*.isf";

            if(path == null)
            {
                if (dlg.ShowDialog() == true)
                {
                    path = dlg.FileName;
                    FileStream fs = new FileStream(dlg.FileName, FileMode.Create);
                    ink.Strokes.Save(fs);
                    fs.Close();
                }
                MessageBox.Show("Saved successfully", "Save");
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                ink.Strokes.Save(fs);
                fs.Close();
                MessageBox.Show("Saved successfully", "Save");

            }


        }

        private void LoadContentToInk(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (openFileDialog1.ShowDialog() == true)
            {
                    path = openFileDialog1.FileName;
                    FileStream fs = new FileStream(openFileDialog1.FileName,
                                               FileMode.Open);
                    ink.Strokes = new StrokeCollection(fs);
                    fs.Close();
                
            }
        }

        private void CopyInkContent(object sender, RoutedEventArgs e)
        {
            if (ink.GetSelectedStrokes().Count > 0)
                this.ink.CopySelection();
        }

        private void CutInkContent(object sender, RoutedEventArgs e)
        {
            if (ink.GetSelectedStrokes().Count > 0)
                ink.CutSelection();
        }

        private void PastContentToInk(object sender, RoutedEventArgs e)
        {
            if (this.ink.CanPaste())
                this.ink.Paste();
        }

    }
}
