﻿#pragma checksum "..\..\..\Provider.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3E4B419DC98F5C06AF8B5751F0AB5BB2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AdministrationCenter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AdministrationCenter {
    
    
    /// <summary>
    /// Provider
    /// </summary>
    public partial class Provider : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNombre;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbApellido;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMovil;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFijo;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEmail;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btBuscar;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbAddress;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSave;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Provider.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AdministrationCenter.UCProductList ProductByProviderList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/provider.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Provider.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbApellido = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbMovil = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\..\Provider.xaml"
            this.tbMovil.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.OnPreviewTextBox);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbFijo = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\..\Provider.xaml"
            this.tbFijo.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.OnPreviewTextBox);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\..\Provider.xaml"
            this.tbEmail.PreviewLostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.txtEmail_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btBuscar = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\Provider.xaml"
            this.btBuscar.Click += new System.Windows.RoutedEventHandler(this.Search_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btSave = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\Provider.xaml"
            this.btSave.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ProductByProviderList = ((AdministrationCenter.UCProductList)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

