﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PngSqToWebm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var browser = new OpenFileDialog();
            browser.InitialDirectory = Environment.CurrentDirectory;
            Console.WriteLine(Environment.CurrentDirectory);
            browser.Filter = "PNG File (*.png)|*.png";
            browser.Multiselect = false;
            var res = browser.ShowDialog();

            if (res.HasValue && res.Value)
            {
                var filename = System.IO.Path.GetFileName(browser.FileName);
                var split = Regex.Split(filename, @"\d+");
                var digit = Regex.Matches(filename, @"\d+");
                
                for (int i = 0; i < digit.Count; i++)
                {
                    int start = 0;
                    var prev = i > 0 ? digit[i - 1] : null;
                    var current = digit[i];
                    var next = i < digit.Count - 1 ? digit[i + 1] : null;

                    TextBlock text = new TextBlock();
                    text.VerticalAlignment = VerticalAlignment.Center;
                    SqNumPanel.Children.Add(text);

                    if (i == 0)
                    {
                        if (current.Index == 0)
                        {
                            if (next == null)
                                text.Text = filename.Substring(current.Length, filename.Length - current.Length);
                            else
                                text.Text = filename.Substring(current.Length, next.Index - (current.Index + current.Length));
                        }
                        else
                        {
                            if (next == null)
                                text.Text = filename.Substring(current.Length, filename.Length - current.Length);
                            else
                                text.Text = filename.Substring(current.Length, next.Index - (current.Index + current.Length));
                        }
                    }
                    else
                    {

                    }

                    Button btn = new Button();
                    btn.Content = digit[i].Value;
                    SqNumPanel.Children.Add(btn);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
