﻿//-----------------------------------------------------------------------
// <copyright company="Microsoft" file="DataFormTests_Editing.cs">
//      (c) Copyright Microsoft Corporation.
//      This source is subject to the Microsoft Public License (Ms-PL).
//      Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//      All other rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Controls.Primitives;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Windows.Controls.UnitTests
{
    /// <summary>
    /// Tests the events on the <see cref="DataForm"/>.
    /// </summary>
    [TestClass]
    public class DataFormTests_Events : DataFormTests_Base
    {
        #region Helper Properties And Fields

        /// <summary>
        /// Gets the <see cref="DataForm"/> app.
        /// </summary>
        private DataFormApp_Fields DataFormApp
        {
            get
            {
                return this.DataFormAppBase as DataFormApp_Fields;
            }
        }

        /// <summary>
        /// Gets the <see cref="DataForm"/>.
        /// </summary>
        private DataForm DataForm
        {
            get
            {
                return this.DataFormApp.dataForm;
            }
        }

        #endregion Helper Properties

        #region Initialization

        /// <summary>
        /// Initializes the test framework.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            this.DataFormAppBase = new DataFormApp_Fields();
            this.DataForm.ItemsSource = DataClassList.GetDataClassList(2, ListOperations.All);
        }

        #endregion Initialization

        /// <summary>
        /// Ensure that AddingItem functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that AddingItem functions properly.")]
        public void AddingItem()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<System.ComponentModel.CancelEventArgs>("AddingItem");
                this.DataForm.AddItem();
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that AutoGeneratedFields functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that AutoGeneratedFields functions properly.")]
        public void AutoGeneratedFields()
        {
            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<EventArgs>("AutoGeneratedFields");
                this.DataForm.AutoGenerateFields = true;
            });
            
            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that AutoGeneratingField functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that AutoGeneratingField functions properly.")]
        public void AutoGeneratingField()
        {
            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormAutoGeneratingFieldEventArgs>("AutoGeneratingField");
                this.DataForm.AutoGenerateFields = true;
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that BeginningEdit functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that BeginningEdit functions properly.")]
        public void BeginningEdit()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<System.ComponentModel.CancelEventArgs>("BeginningEdit");
                this.DataForm.BeginEdit();
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that ContentLoaded functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that ContentLoaded functions properly.")]
        public void ContentLoaded()
        {
            this.ExpectEvent<DataFormContentLoadedEventArgs>("ContentLoaded");
            this.AddToPanelAndWaitForLoad();
            this.WaitForAllEvents();
            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that CurrentItemChanged functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that CurrentItemChanged functions properly.")]
        public void CurrentItemChanged()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<EventArgs>("CurrentItemChanged");
                this.DataForm.MoveToNextItem();
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that DeletingItemItem functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that DeletingItemItem functions properly.")]
        public void DeletingItem()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<System.ComponentModel.CancelEventArgs>("DeletingItem");
                this.DataForm.DeleteItem();
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that FieldEditEnded functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that FieldEditEnded functions properly.")]
        public void FieldEditEnded()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                this.DataForm.BeginEdit();
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormFieldEditEndedEventArgs>("FieldEditEnded");
                this.ExpectItemEditEnded();
                this.DataForm.CommitItemEdit(true /* exitEditingMode */);
            });

            this.WaitForAllEvents();
            this.WaitForItemEditEnded();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                this.DataForm.BeginEdit();
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormFieldEditEndedEventArgs>("FieldEditEnded");
                this.DataForm.CommitFieldEdit(this.DataForm.Fields[0]);
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that FieldEditEnding functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that FieldEditEnding functions properly.")]
        public void FieldEditEnding()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                this.DataForm.BeginEdit();
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormFieldEditEndingEventArgs>("FieldEditEnding");
                this.ExpectItemEditEnded();
                this.DataForm.CommitItemEdit(true /* exitEditingMode */);
            });

            this.WaitForAllEvents();
            this.WaitForItemEditEnded();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                this.DataForm.BeginEdit();
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormFieldEditEndingEventArgs>("FieldEditEnding");
                this.DataForm.CommitFieldEdit(this.DataForm.Fields[0]);
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that ItemEditEnded functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that ItemEditEnded functions properly.")]
        public void ItemEditEnded()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                this.DataForm.BeginEdit();
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormItemEditEndedEventArgs>("ItemEditEnded");
                this.ExpectItemEditEnded();
                this.DataForm.CommitItemEdit(true /* exitEditingMode */);
            });

            this.WaitForAllEvents();
            this.WaitForItemEditEnded();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                this.DataForm.BeginEdit();
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormItemEditEndedEventArgs>("ItemEditEnded");
                this.DataForm.CancelItemEdit();
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that ItemEditEnding functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that ItemEditEnding functions properly.")]
        public void ItemEditEnding()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                this.DataForm.BeginEdit();
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormItemEditEndingEventArgs>("ItemEditEnding");
                this.ExpectItemEditEnded();
                this.DataForm.CommitItemEdit(true /* exitEditingMode */);
            });

            this.WaitForAllEvents();
            this.WaitForItemEditEnded();

            this.EnqueueCallback(() =>
            {
                this.ExpectContentLoaded();
                this.DataForm.BeginEdit();
            });

            this.WaitForContentLoaded();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<DataFormItemEditEndingEventArgs>("ItemEditEnding");
                this.DataForm.CancelItemEdit();
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }

        /// <summary>
        /// Ensure that ValidatingItem functions properly.
        /// </summary>
        [TestMethod]
        [Asynchronous]
        [Description("Ensure that ValidatingItem functions properly.")]
        public void ValidatingItem()
        {
            this.AddToPanelAndWaitForLoad();

            this.EnqueueCallback(() =>
            {
                this.ExpectEvent<System.ComponentModel.CancelEventArgs>("ValidatingItem");
                this.DataForm.ValidateItem();
            });

            this.WaitForAllEvents();

            this.EnqueueTestComplete();
        }
    }
}
