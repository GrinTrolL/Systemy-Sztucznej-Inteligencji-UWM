using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace DrawChartExtensionMethods
{
    public static class ChartExtensionMethods
    {
        public class SeriesProperties
        {
            public Color Color { get; set; }
            public MarkerStyle MarkerStyle { get; set; }
            public ChartDashStyle ChartDashStyle { get; set; }
        }

        public static readonly List<SeriesProperties> seriesStyles = new List<SeriesProperties>()
        {
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Blue,
                MarkerStyle = MarkerStyle.Circle
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Yellow,
                MarkerStyle = MarkerStyle.Circle
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.DashDotDot,
                Color = Color.Red,
                MarkerStyle = MarkerStyle.Cross
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Gold,
                MarkerStyle = MarkerStyle.Diamond
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Solid,
                Color = Color.PaleGreen,
                MarkerStyle = MarkerStyle.Square
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.DashDot,
                Color = Color.MediumOrchid,
                MarkerStyle = MarkerStyle.Star10
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Olive,
                MarkerStyle = MarkerStyle.Star4
                },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.DashDot,
                Color = Color.RosyBrown,
                MarkerStyle = MarkerStyle.Star5
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dot,
                Color = Color.OrangeRed,
                MarkerStyle = MarkerStyle.Star6
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Purple,
                MarkerStyle = MarkerStyle.Triangle
            }
        };
    }
}
