﻿#pragma checksum "..\..\..\Views\NotesWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "77EE2EA4B28DFB568256281FBACD1C247FAE1E1D2F8D44EF5C20A3133DF89802"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NotesApp.ViewModels;
using NotesApp.ViewModels.Converters;
using NotesApp.Views;
using NotesApp.Views.Controls;
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
using System.Windows.Interactivity;
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


namespace NotesApp.Views {
    
    
    /// <summary>
    /// NotesWindow
    /// </summary>
    public partial class NotesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel ContainerDockPanel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock statusTextBlock;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton speechButton;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton boldButton;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton italicButton;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton underlineButton;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox fontFamilyComboBox;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox fontSizeComboBox;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveFileButton;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\Views\NotesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox contentReachTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/NotesApp;component/views/noteswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\NotesWindow.xaml"
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
            this.ContainerDockPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            
            #line 28 "..\..\..\Views\NotesWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.statusTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.speechButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 106 "..\..\..\Views\NotesWindow.xaml"
            this.speechButton.Click += new System.Windows.RoutedEventHandler(this.speechButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.boldButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 108 "..\..\..\Views\NotesWindow.xaml"
            this.boldButton.Click += new System.Windows.RoutedEventHandler(this.boldButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.italicButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 113 "..\..\..\Views\NotesWindow.xaml"
            this.italicButton.Click += new System.Windows.RoutedEventHandler(this.italicButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.underlineButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 118 "..\..\..\Views\NotesWindow.xaml"
            this.underlineButton.Click += new System.Windows.RoutedEventHandler(this.underlineButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.fontFamilyComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 124 "..\..\..\Views\NotesWindow.xaml"
            this.fontFamilyComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.fontFamilyComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.fontSizeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 128 "..\..\..\Views\NotesWindow.xaml"
            this.fontSizeComboBox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.SelectionChangedEvent, new System.Windows.RoutedEventHandler(this.fontSizeComboBox_SelectionChanged));
            
            #line default
            #line hidden
            return;
            case 10:
            this.SaveFileButton = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\..\Views\NotesWindow.xaml"
            this.SaveFileButton.Click += new System.Windows.RoutedEventHandler(this.SaveFileButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.contentReachTextBox = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 138 "..\..\..\Views\NotesWindow.xaml"
            this.contentReachTextBox.SelectionChanged += new System.Windows.RoutedEventHandler(this.contentReachTextBox_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 139 "..\..\..\Views\NotesWindow.xaml"
            this.contentReachTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.contentReachTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

