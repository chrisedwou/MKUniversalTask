using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace SiliconWafer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public PlotModel Model0 { get; private set; }
        private static PlotModel CreatePlotModel(double max, double numPoints )
        {
            var model = new PlotModel();
            var scatter = new ScatterSeries { MarkerType = MarkerType.Circle, MarkerSize = 1,  };
            var radius = (max / numPoints);
            double count = 0;
            double degree45 = 0;
            while(count <= max)
            {
                degree45 = (Math.PI * count) / 4;
                scatter.Points.Add(new ScatterPoint(count, 0, 5, count));
                scatter.Points.Add(new ScatterPoint(-count, 0, 5, count));
                scatter.Points.Add(new ScatterPoint(0, count, 5, count));
                scatter.Points.Add(new ScatterPoint(0, -count, 5, count));
                scatter.Points.Add(new ScatterPoint(degree45, degree45, 5, count));
                scatter.Points.Add(new ScatterPoint(degree45, -degree45, 5, count));
                scatter.Points.Add(new ScatterPoint(-degree45, -degree45, 5, count));
                scatter.Points.Add(new ScatterPoint(-degree45, degree45, 5, count));
                count += radius;
            }
            model.Series.Add(scatter);
            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Bottom, IsZoomEnabled = false, IsPanEnabled = false, IsAxisVisible=false });
            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Left, IsZoomEnabled = false, IsPanEnabled = false, IsAxisVisible = false });
            return model;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (userInput.Text == "")
            {
                return;
            }
            int input = Int32.Parse(userInput.Text);
            this.Model0 = CreatePlotModel( 150, input);
            this.DataContext = this;
        }
        private void NumberCheck(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
