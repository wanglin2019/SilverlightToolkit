﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.ComponentModel;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.Design.Common;
using Microsoft.Windows.Design.Metadata;

namespace System.Windows.Controls.DataVisualization.Design
{
    /// <summary>
    /// To register design time metadata for Legend.
    /// </summary>
    internal class LegendMetadata : AttributeTableBuilder
    {
        /// <summary>
        /// To register design time metadata for Legend.
        /// </summary>
        public LegendMetadata()
            : base()
        {
            AddCallback(
                typeof(Legend),
                b =>
                {
                    b.AddCustomAttributes(Extensions.GetMemberName<Legend>(x => x.Title), new CategoryAttribute(Properties.Resources.DataVisualization));
                    b.AddCustomAttributes(Extensions.GetMemberName<Legend>(x => x.Items), new CategoryAttribute(Properties.Resources.DataVisualization));
                    b.AddCustomAttributes(Extensions.GetMemberName<Legend>(x => x.TitleStyle), new CategoryAttribute(Properties.Resources.DataVisualizationStyling));
                });
        }
    }
}
