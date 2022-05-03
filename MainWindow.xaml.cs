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
    /// Author: Chris Edwards
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Model0 = new PlotModel();
        }
        public PlotModel Model0 { get; private set; }
        private Regex _regex = new Regex("[^0-9]+");

        private void CreatePlotModel(double max, double numPoints )
        {
            var model = new PlotModel();
            var scatter = new ScatterSeries { MarkerType = MarkerType.Circle, MarkerSize = 1 };
            var radius = (max / numPoints);
            var count = 0.0;
            var degree45 = 0.0;

            while (count <= max)
            {
                //Plot 8 points on a circle given the current radius
                degree45 = (count * Math.Sqrt(2)) / 2;
                scatter.Points.Add(new ScatterPoint(count, 0, 5, count));
                scatter.Points.Add(new ScatterPoint(-count, 0, 5, count));
                scatter.Points.Add(new ScatterPoint(0, count, 5, count));
                scatter.Points.Add(new ScatterPoint(0, -count, 5, count));
                scatter.Points.Add(new ScatterPoint(degree45, degree45, 5, count));
                scatter.Points.Add(new ScatterPoint(degree45, -degree45, 5, count));
                scatter.Points.Add(new ScatterPoint(-degree45, -degree45, 5, count));
                scatter.Points.Add(new ScatterPoint(-degree45, degree45, 5, count));
                
                //Draw a Circle given the current radius 
                model.Series.Add(new FunctionSeries((x) => Math.Sqrt(Math.Pow(count,2) - Math.Pow(x, 2)), -count, count, 0.1) { Color = OxyColors.Black });
                model.Series.Add(new FunctionSeries((x) => -Math.Sqrt(Math.Pow(count, 2) - Math.Pow(x, 2)), -count, count, 0.1) { Color = OxyColors.Black });
                count += radius;
            }

            model.Series.Add(scatter);
            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Bottom, IsZoomEnabled = false, IsPanEnabled = false, IsAxisVisible = false });
            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Left, IsZoomEnabled = false, IsPanEnabled = false, IsAxisVisible = false });
            this.Model0 = model;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            //Check if user input is a number. If not, do nothing.
            if (userInput.Text == "" || _regex.IsMatch(userInput.Text)) return;

            int input = Int32.Parse(userInput.Text);

            CreatePlotModel( 150, input);
            this.DataContext = this;

            okButton.Visibility = Visibility.Hidden;
        }
        private void NumberCheck(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }
    }
}
