<<<<<<< HEAD
﻿#pragma checksum "..\..\..\MainMenu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FB2F827805E2E00FF04E54D931A6EA63381B162D"
=======
<<<<<<< HEAD
﻿#pragma checksum "..\..\..\MainMenu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8F07B8A3AF5BD9D4CDB308109DE16027A1AFF6DA"
=======
﻿#pragma checksum "..\..\..\MainMenu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "058C56AB7F05C7A7F9E0158B87A47D0451C105D3"
>>>>>>> b79365dd13292ba09da63c365ced2a149e76f740
>>>>>>> 983a9cd18e5ca9b95d2a7c69d15c3ad2d1f97b16
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Samples.Kinect.DiscreteGestureBasics;
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


namespace Microsoft.Samples.Kinect.DiscreteGestureBasics {
    
    
    /// <summary>
    /// MainMenu
    /// </summary>
    public partial class MainMenu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
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
            System.Uri resourceLocater = new System.Uri("/DiscreteGestureBasics-WPF;component/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainMenu.xaml"
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
            
            #line 13 "..\..\..\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogOut);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 34 "..\..\..\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GestureMenu);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 35 "..\..\..\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ScoreBoard);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

