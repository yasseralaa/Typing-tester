﻿

#pragma checksum "D:\general\appfactory\Typing Tester final\Typing Tester\speedtest5.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8611DCF892E7A581EF9A340D85619FAD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Typing_Tester
{
    partial class speedtest5 : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 11 "..\..\speedtest5.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.pageRoot_GotFocus;
                 #line default
                 #line hidden
                #line 11 "..\..\speedtest5.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.pageRoot_Loaded;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 78 "..\..\speedtest5.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.txtWrite_TextChanged;
                 #line default
                 #line hidden
                #line 78 "..\..\speedtest5.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.txtWrite_KeyDown;
                 #line default
                 #line hidden
                #line 78 "..\..\speedtest5.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyUp += this.txtWrite_KeyUp;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


