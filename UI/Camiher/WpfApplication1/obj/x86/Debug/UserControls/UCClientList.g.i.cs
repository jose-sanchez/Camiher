﻿#pragma checksum "..\..\..\..\UserControls\UCClientList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D3DA90DE133E52AD69830AC850D37F98"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Camiher.UI.AdministrationCenter.UserControls {
    
    
    /// <summary>
    /// UCClientList
    /// </summary>
    public partial class UCClientList : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\UserControls\UCClientList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Camiher.UI.AdministrationCenter.UserControls.UCClientList UserControl;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\UserControls\UCClientList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView clientSet1ViewSource;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\UserControls\UCClientList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu clientmenu;
        
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
            System.Uri resourceLocater = new System.Uri("/AdministrationCenter;component/usercontrols/ucclientlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControls\UCClientList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.UserControl = ((Camiher.UI.AdministrationCenter.UserControls.UCClientList)(target));
            return;
            case 2:
            this.clientSet1ViewSource = ((System.Windows.Controls.ListView)(target));
            
            #line 15 "..\..\..\..\UserControls\UCClientList.xaml"
            this.clientSet1ViewSource.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.clientSet1ListView_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\UserControls\UCClientList.xaml"
            this.clientSet1ViewSource.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.clientSetListView_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.clientmenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 4:
            
            #line 18 "..\..\..\..\UserControls\UCClientList.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 20 "..\..\..\..\UserControls\UCClientList.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Editar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 22 "..\..\..\..\UserControls\UCClientList.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.BorrarMouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

