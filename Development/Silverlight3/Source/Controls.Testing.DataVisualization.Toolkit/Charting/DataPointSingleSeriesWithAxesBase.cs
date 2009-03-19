﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#if SILVERLIGHT
using Microsoft.Silverlight.Testing;
#endif

namespace System.Windows.Controls.Testing
{
    /// <summary>
    /// Unit tests for children of the DataPointSingleSeriesWithAxesBase class.
    /// </summary>
    public abstract partial class DataPointSingleSeriesWithAxesBase : DataPointSeriesWithAxesBase
    {
        /// <summary>
        /// Gets a default instance of DataPointSingleSeriesWithAxes (or a derived type) to test.
        /// </summary>
        public DataPointSingleSeriesWithAxes DataPointSingleSeriesWithAxesToTest
        {
            get
            {
                return DefaultSeriesToTest as DataPointSingleSeriesWithAxes;
            }
        }

        /// <summary>
        /// Initializes a new instance of the DataPointSingleSeriesWithAxesBase class.
        /// </summary>
        protected DataPointSingleSeriesWithAxesBase()
        {
        }

        /// <summary>
        /// Creates a ISeriesHost with two Series and verifies their Titles.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Creates a Chart with two Series and verifies their Titles.")]
        public void AutomaticSeriesTitle()
        {
            Series series1 = DefaultSeriesToTest;
            Series series2 = DefaultSeriesToTest;
            Chart chart = new Chart();
            TestAsync(
                chart,
                () => chart.Series.Add(series1),
                () => chart.Series.Add(series2),
                () => Assert.AreEqual("Series 1", series1.Title),
                () => Assert.AreEqual("Series 2", series2.Title));
        }

        /// <summary>
        /// Creates a ISeriesHost with a Series that has its Title set.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Creates a Chart with a Series that has its Title set.")]
        public void AutomaticSeriesTitleNotApplied()
        {
            DataPointSeries series = DefaultSeriesToTest;
            string title = "Custom Series Title";
            series.Title = title;
            Chart chart = new Chart();
            TestAsync(
                chart,
                () => chart.Series.Add(series),
                () => Assert.AreSame(title, series.Title));
        }

        /// <summary>
        /// Creates a ISeriesHost with a Series that has its Title unset, then set.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Creates a Chart with a Series that has its Title unset, then set.")]
        public void AutomaticSeriesTitleBecomesApplied()
        {
            DataPointSeries series = DefaultSeriesToTest;
            string title = "Custom Series Title";
            Chart chart = new Chart();
            TestAsync(
                chart,
                () => chart.Series.Add(series),
                () => Assert.AreEqual("Series 1", series.Title),
                () => series.Title = title,
                () => Assert.AreSame(title, series.Title));
        }

        /// <summary>
        /// Creates a ISeriesHost with two Series and verifies their automatic Titles after changing the order.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Creates a Chart with two Series and verifies their automatic Titles after changing the order.")]
        public void AutomaticSeriesTitleAfterOrderChange()
        {
            Series series1 = DefaultSeriesToTest;
            Series series2 = DefaultSeriesToTest;
            Chart chart = new Chart();
            TestAsync(
                chart,
                () => chart.Series.Add(series1),
                () => chart.Series.Add(series2),
                () => Assert.AreEqual("Series 1", series1.Title),
                () => Assert.AreEqual("Series 2", series2.Title),
                () => chart.Series.Remove(series1),
                () => chart.Series.Add(series1),
                () => Assert.AreEqual("Series 1", series2.Title),
                () => Assert.AreEqual("Series 2", series1.Title));
        }
        
        /// <summary>
        /// Creates a ISeriesHost with a Series that has its Title set, then unset.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Creates a Chart with a Series that has its Title set, then unset.")]
        public void AutomaticSeriesTitleRemoved()
        {
            DataPointSeries series = DefaultSeriesToTest;
            Chart chart = new Chart();
            TestAsync(
                chart,
                () => chart.Series.Add(series),
                () => Assert.AreEqual("Series 1", series.Title),
                () => chart.Series.Remove(series),
                () => Assert.IsNull(series.Title));
        }

        /// <summary>
        /// Calls GetNumericRange with a null axis parameter.
        /// </summary>
        [TestMethod]
        [Description("Calls GetNumericRange with a null axis parameter.")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNumericRangeWithNullAxis()
        {
            IRangeProvider series = (IRangeProvider)DataPointSingleSeriesWithAxesToTest;
            series.GetRange(null);
        }

        /// <summary>
        /// Verifies that the LegendItem's DataPoint has had the StylePalette Style applied.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Verifies that the LegendItem's DataPoint has had the StylePalette Style applied.")]
        [Bug("520693: Legend DataPoint representations are missing their black border for non-Pie series", Fixed = true)]
        public void VerifyLegendItemDataPointStyleApplied()
        {
            Chart chart = new Chart();
            DataPointSeries series = DefaultSeriesToTest;
            chart.Series.Add(series);
            TestAsync(
                chart,
                () => Assert.IsNotNull(ChartTestUtilities.GetLegend(chart)),
                () =>
                {
                    foreach (var legendItem in ChartTestUtilities.GetLegend(chart).Items.OfType<LegendItem>())
                    {
                        var dataPoint = legendItem.DataContext as DataPoint;
                        if (null != dataPoint)
                        {
                            Assert.AreNotEqual(typeof(SolidColorBrush), dataPoint.Background.GetType());
                        }
                    }
                });
        }

        /// <summary>
        /// Contains a simple DataPointStyle without VSM states or a complex element tree.
        /// </summary>
        private const string SimpleDataPointStyle =
            @"<Style
                xmlns=""http://schemas.microsoft.com/client/2007""
                xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
                xmlns:charting=""clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit""
                TargetType=""charting:DataPoint"">
                <Setter Property=""Template"">
                    <Setter.Value>
                        <ControlTemplate TargetType=""charting:DataPoint"">
                            <Grid Background=""{TemplateBinding Background}""/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>";

        /// <summary>
        /// Changes the state of DataPoint objects that do not define any VSM states.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Changes the state of DataPoint objects that do not define any VSM states.")]
        [Bug("535616: DataPoint should skip animations if none are found and set state directly", Fixed = true)]
        [Bug("557085: Exception from UpdatePointsCollection when removing all points on LineSeries (axis refactoring consequence)", Fixed = true)]
        [Bug("532925: Datapoints are not removed after a refresh", Fixed = true)]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Vsm", Justification = "Standard abbreviation of Visual State Manager")]
        [Priority(0)]
        public void ChangeStateOfDataPointsWithoutVsmStates()
        {
            Chart chart = new Chart();
            DataPointSingleSeriesWithAxes series = DataPointSingleSeriesWithAxesToTest;
            series.IndependentValueBinding = new Binding();
            ObservableCollection<int> itemsSource = new ObservableCollection<int> { 1, 2, 3 };
            series.ItemsSource = itemsSource;
            series.DataPointStyle = (Style)XamlReader.Load(SimpleDataPointStyle);
            chart.Series.Add(series);
            TestAsync(
                chart,
                () => Assert.AreEqual(3, ChartTestUtilities.GetDataPointsForSeries(series).Count),
                () => itemsSource.Clear(),
                () => Assert.AreEqual(0, ChartTestUtilities.GetDataPointsForSeries(series).Count));
        }

        /// <summary>
        /// Verifies that removing and updating values in the items source results in correct behavior.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Verifies that removing and updating values in the items source results in correct behavior.")]
        public void RemoveAndUpdateCollectionValues()
        {
            Chart chart = new Chart();
            DataPointSingleSeriesWithAxes series = DataPointSingleSeriesWithAxesToTest;
            series.IndependentValueBinding = new Binding();
            ObservableCollection<int> itemsSource = new ObservableCollection<int> { 1, 2, 3, 4 };
            series.ItemsSource = itemsSource;
            series.DataPointStyle = (Style)XamlReader.Load(SimpleDataPointStyle);
            chart.Series.Add(series);
            TestAsync(
                chart,
                () => Assert.AreEqual(4, ChartTestUtilities.GetDataPointsForSeries(series).Count),
                () => itemsSource.RemoveAt(3),
                () => Assert.AreEqual(3, ChartTestUtilities.GetDataPointsForSeries(series).Count),
                () => itemsSource[2] = 4,
                () => itemsSource.RemoveAt(2),
                () => Assert.AreEqual(2, ChartTestUtilities.GetDataPointsForSeries(series).Count));
        }
    }
}