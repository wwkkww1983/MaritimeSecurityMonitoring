﻿#pragma checksum "..\..\GorgeParameterSetting.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4A1A647FE00FE40EFA029EDA00B69BA1"
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
    /// GorgeParameterSetting
    /// </summary>
    public partial class GorgeParameterSetting : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 64 "..\..\GorgeParameterSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox baudRate;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\GorgeParameterSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox dataBits;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\GorgeParameterSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox evenOddCheck;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\GorgeParameterSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox stopBit;
        
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
            System.Uri resourceLocater = new System.Uri("/MaritimeSecurityMonitoring;component/gorgeparametersetting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GorgeParameterSetting.xaml"
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
            
            #line 5 "..\..\GorgeParameterSetting.xaml"
            ((MaritimeSecurityMonitoring.GorgeParameterSetting)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dragMoveWindow);
            
            #line default
            #line hidden
            
            #line 5 "..\..\GorgeParameterSetting.xaml"
            ((MaritimeSecurityMonitoring.GorgeParameterSetting)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 33 "..\..\GorgeParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeWindowClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.baudRate = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.dataBits = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.evenOddCheck = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.stopBit = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            
            #line 108 "..\..\GorgeParameterSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.saveClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

