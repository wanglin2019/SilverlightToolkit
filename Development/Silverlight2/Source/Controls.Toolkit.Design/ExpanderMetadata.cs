﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.ComponentModel;
using System.Windows.Controls.Design.Common;
using Microsoft.Windows.Design.Metadata;

namespace System.Windows.Controls.Design
{
    /// <summary>
    /// To register design time metadata for Expander.
    /// </summary>
    internal class ExpanderMetadata : AttributeTableBuilder
    {
        /// <summary>
        /// To register design time metadata for Expander.
        /// </summary>
        public ExpanderMetadata()
            : base()
        {
            AddCallback(
                typeof(Expander),
                b =>
                {
                    b.AddCustomAttributes(Extensions.GetMemberName<Expander>(x => x.Header), new CategoryAttribute(Properties.Resources.CommonProperties));
                    b.AddCustomAttributes(Extensions.GetMemberName<Expander>(x => x.ExpandDirection), new CategoryAttribute(Properties.Resources.CommonProperties));
                    b.AddCustomAttributes(Extensions.GetMemberName<Expander>(x => x.IsExpanded), new CategoryAttribute(Properties.Resources.CommonProperties));
                });
        }
    }
}
