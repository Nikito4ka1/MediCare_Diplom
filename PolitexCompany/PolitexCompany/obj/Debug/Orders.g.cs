﻿#pragma checksum "..\..\Orders.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0EB1B650EAFFC508B8D8A8B77C0C1571F0903BB73052A2CDDB02110942878179"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PolitexCompany;
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


namespace PolitexCompany {
    
    
    /// <summary>
    /// Orders
    /// </summary>
    public partial class Orders : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush backgroundImage1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image backgroundImage;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox backgroundComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnItem;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOrder;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Orders.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/PolitexCompany;component/orders.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Orders.xaml"
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
            
            #line 14 "..\..\Orders.xaml"
            ((PolitexCompany.Orders)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.backgroundImage1 = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.backgroundImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.backgroundComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\Orders.xaml"
            this.backgroundComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BackgroundComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 32 "..\..\Orders.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exet_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnItem = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Orders.xaml"
            this.BtnItem.Click += new System.Windows.RoutedEventHandler(this.BtnItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnOrder = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Orders.xaml"
            this.BtnOrder.Click += new System.Windows.RoutedEventHandler(this.BtnOrder_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 9:
            
            #line 36 "..\..\Orders.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Minimazed_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 37 "..\..\Orders.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 38 "..\..\Orders.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MaxMin_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

