﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Windows.Controls {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PagerResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PagerResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("System.Windows.Controls.DataPager.PagerResources", typeof(PagerResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ....
        /// </summary>
        public static string AutoEllipsisString {
            get {
                return ResourceManager.GetString("AutoEllipsisString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The NumericButtonPanel contains invalid children..
        /// </summary>
        public static string InvalidButtonPanelContent {
            get {
                return ResourceManager.GetString("InvalidButtonPanelContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} time span must be strictly positive..
        /// </summary>
        public static string InvalidTimeSpan {
            get {
                return ResourceManager.GetString("InvalidTimeSpan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The PageIndex property can only be set to -1 when the Source property is null or the PageSize property is 0..
        /// </summary>
        public static string PageIndexMustBeNegativeOne {
            get {
                return ResourceManager.GetString("PageIndexMustBeNegativeOne", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} cannot be set because the underlying property is read only..
        /// </summary>
        public static string UnderlyingPropertyIsReadOnly {
            get {
                return ResourceManager.GetString("UnderlyingPropertyIsReadOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} must be greater than or equal to {1}..
        /// </summary>
        public static string ValueMustBeGreaterThanOrEqualTo {
            get {
                return ResourceManager.GetString("ValueMustBeGreaterThanOrEqualTo", resourceCulture);
            }
        }
    }
}
