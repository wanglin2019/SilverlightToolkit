﻿//-----------------------------------------------------------------------
// <copyright company="Microsoft">
//      (c) Copyright Microsoft Corporation.
//      This source is subject to the Microsoft Public License (Ms-PL).
//      Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//      All other rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace System.Windows.Navigation
{
    ///<summary>
    ///     FragmentNavigationEventArgs exposes the fragment being navigated to
    ///     in an event fired from NavigationService to notify a listening client
    ///     that a navigation to fragment is about to occur.
    ///</summary> 
    ///<QualityBand>Stable</QualityBand>
    public sealed class FragmentNavigationEventArgs : EventArgs
    {
        #region Fields

        private string _fragment;

        #endregion
                
        #region Constructors

        internal FragmentNavigationEventArgs(string fragment)
        {
            this._fragment = fragment;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        ///  The fragment part of the URI that was passed to the Navigate() API which initiated this navigation.
        ///  The fragment may be String.Empty to indicate a scroll to the top of the page.
        /// </summary>
        public string Fragment
        {
            get
            {
                return this._fragment;
            }
        }
        
        #endregion Public Properties
    }
}
