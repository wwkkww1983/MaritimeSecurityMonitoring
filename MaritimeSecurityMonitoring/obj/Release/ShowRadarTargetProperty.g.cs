﻿#pragma checksum "..\..\ShowRadarTargetProperty.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E0595AB52694244C772D2416A2BE2F32"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using System.Windows.Forms.Integration;
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


namespace MaritimeSecurityMonitoring {
    
    
    /// <summary>
    /// ShowRadarTargetProperty
    /// </summary>
    public partial class ShowRadarTargetProperty : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox radarNumber;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox radarNumber2;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox trackAngle;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox distance;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox north;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox longitude;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox speed;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lagitude;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\ShowRadarTargetProperty.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox findeTime;
        
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
            System.Uri resourceLocater = new System.Uri("/MaritimeSecurityMonitoring;component/showradartargetproperty.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ShowRadarTargetProperty.xaml"
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
            
            #line 5 "..\..\ShowRadarTargetProperty.xaml"
            ((MaritimeSecurityMonitoring.ShowRadarTargetProperty)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dragMoveWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\ShowRadarTargetProperty.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CommandBinding_CanExecute);
            
            #line default
            #line hidden
            
            #line 18 "..\..\ShowRadarTargetProperty.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 27 "..\..\ShowRadarTargetProperty.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeWindowClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.radarNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.radarNumber2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.trackAngle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.distance = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.north = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.longitude = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.speed = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.lagitude = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.findeTime = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

