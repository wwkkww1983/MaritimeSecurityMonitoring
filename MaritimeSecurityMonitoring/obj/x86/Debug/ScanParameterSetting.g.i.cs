﻿#pragma checksum "..\..\..\ScanParameterSetting.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "66E247D9A07A1008D148076798A2B934"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MaritimeSecurityMonitoring;
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
    /// ScanParameterSetting
    /// </summary>
    public partial class ScanParameterSetting : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 119 "..\..\..\ScanParameterSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Angle1;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\ScanParameterSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Angle2;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\ScanParameterSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Percent;
        
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
            System.Uri resourceLocater = new System.Uri("/MaritimeSecurityMonitoring;component/scanparametersetting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ScanParameterSetting.xaml"
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
            
            #line 6 "..\..\..\ScanParameterSetting.xaml"
            ((MaritimeSecurityMonitoring.ScanParameterSetting)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dragMoveWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 89 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeWindowClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Angle1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 134 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 135 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinusClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Angle2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 162 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 163 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinusClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Percent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 194 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 195 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinusClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 213 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.comfirmClick);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 214 "..\..\..\ScanParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.cancelClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

