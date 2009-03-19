﻿// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.ComponentModel;
using System.Windows.Controls.Design.Common;
using System.Windows.Controls.Primitives;
using Microsoft.Windows.Design.Metadata;

namespace System.Windows.Controls.Data.Design
{
    /// <summary>
    /// To register design time metadata for DataGridDetailsPresenter.
    /// </summary>
    public class DataGridDetailsPresenterMetadata : AttributeTableBuilder
    {
        /// <summary>
        /// To register design time metadata for DataGridDetailsPresenter.
        /// </summary>
        public DataGridDetailsPresenterMetadata()
            : base()
        {
            AddCallback(
                typeof(DataGridDetailsPresenter),
                b =>
                {
                    b.AddCustomAttributes(Extensions.GetMemberName<DataGridDetailsPresenter>(x => x.ContentHeight), new CategoryAttribute(Properties.Resources.CommonProperties));
                });
        }
    }
}
