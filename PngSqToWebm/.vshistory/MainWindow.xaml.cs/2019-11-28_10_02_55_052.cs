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
                var filename = browser.FileName;
                var split = Regex.Split(filename, @"\d+");
                var split = Regex.Split(filename, @"\d+");
                foreach(var f in split)
                {
                    Button btn = new Button();
                    btn.Content = f;
                    SqNumPanel.Children.Add(btn);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
