using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System;
using System.Diagnostics;

namespace CustomGrid
{
    public static partial class Extensions
    {
        public static object GetPropertyValue<T>(this T propertyType, string propertyName)
        {
            Type type = propertyType.GetType();
            PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            return property.GetValue(propertyType, null);
        }
    }

    public partial class RGrid : UserControl
    {
        public RGrid()
        {
            InitializeComponent();
        }

        public void InitializeItems<T>(List<T> items)
        {
            PropertyInfo[]? properties = typeof(T).GetProperties();
            RGridRow titleRow = MakeTitleRow(properties.Select(x => x.Name).ToList());
            List<RGridRow> contentRows = new();

            foreach (T? item in items)
            {
                List<object> values = new();
                for (int index = 0; index < properties.Length; index++)
                {
                    values.Add(item.GetPropertyValue(properties[index].Name));
                }
                contentRows.Add(new RGridRow(values));
            }

            Render(titleRow, contentRows);
        }

        private static RGridRow MakeTitleRow(List<string> titles)
        {
            RGridRow titleRow = new();
            titleRow.InitializeTitleRow(titles);

            return titleRow;
        }

        public void Render(RGridRow titleRow, List<RGridRow> contentRows)
        {
            MainPanel.Children.Add(titleRow);

            foreach (RGridRow? contentRow in contentRows)
            {
                MainPanel.Children.Add(contentRow);
            }
        }
    }
}
