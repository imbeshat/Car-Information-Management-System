﻿#pragma checksum "..\..\ForgotPasswordPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0F47E7CEE2B39EEF18BEDE2F69047A3897323D96"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CIMS;
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


namespace CIMS {
    
    
    /// <summary>
    /// ForgotPasswordPage
    /// </summary>
    public partial class ForgotPasswordPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ForgotPasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSecurityQuestion;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ForgotPasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblResponse;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ForgotPasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowpwd;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ForgotPasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtResponse;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ForgotPasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSwitchToLogin;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ForgotPasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbQuest;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ForgotPasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUname;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ForgotPasswordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUname;
        
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
            System.Uri resourceLocater = new System.Uri("/CIMS;component/forgotpasswordpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ForgotPasswordPage.xaml"
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
            
            #line 7 "..\..\ForgotPasswordPage.xaml"
            ((CIMS.ForgotPasswordPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblSecurityQuestion = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblResponse = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnShowpwd = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ForgotPasswordPage.xaml"
            this.btnShowpwd.Click += new System.Windows.RoutedEventHandler(this.BtnShowpwd_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtResponse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSwitchToLogin = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ForgotPasswordPage.xaml"
            this.btnSwitchToLogin.Click += new System.Windows.RoutedEventHandler(this.BtnSwitchToLogin_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmbQuest = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.lblUname = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.txtUname = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
