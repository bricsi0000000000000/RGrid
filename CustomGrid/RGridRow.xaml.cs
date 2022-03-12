using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;

namespace CustomGrid
{
    public partial class RGridRow : UserControl
    {
        /*
        public RGridRow(List<PropertyInfo> properties)
        {
            InitializeComponent();

            foreach (PropertyInfo? propertyInfo in properties)
            {
                if (propertyInfo.PropertyType == typeof(int))
                {
                   // MainPanel.Children.Add(new Label { Content = propertyInfo.GetValue() });
                }
                else if (propertyInfo.PropertyType == typeof(string))
                {
                    MainPanel.Children.Add(new Label { Content = propertyInfo.Name });
                }
            }
        }
        */

        public RGridRow()
        {
            InitializeComponent();
        }

        public void InitializeTitleRow(List<string> titles)
        {
            foreach (string? title in titles)
            {
                

                MainPanel.Children.Add(new Label { Content = title });
            }
        }

        public RGridRow(List<object> values)
        {
            InitializeComponent();

            foreach (object value in values)
            {
                MainPanel.Children.Add(new Label { Content = value });
            }
        }
    }
}
