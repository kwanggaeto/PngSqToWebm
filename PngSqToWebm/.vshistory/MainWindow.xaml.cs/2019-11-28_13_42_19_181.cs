using Microsoft.Win32;
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
        private string _persistant;

        public MainWindow()
        {
            _persistant = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            if (System.IO.Directory.Exists(_persistant))
                System.IO.Directory.CreateDirectory(_persistant);

            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            SqNumPanel.Children.Clear();

            var browser = new OpenFileDialog();
            browser.InitialDirectory = Environment.CurrentDirectory;
            browser.Filter = "PNG File (*.png)|*.png";
            browser.Multiselect = false;
            var res = browser.ShowDialog();

            if (res.HasValue && res.Value)
            {
                var dir = System.IO.Path.GetDirectoryName(browser.FileName);
                var filename = System.IO.Path.GetFileName(browser.FileName);

                string[] files = System.IO.Directory.GetFiles(dir, "*", System.IO.SearchOption.TopDirectoryOnly);

                var images = files.Where(f=>Regex.IsMatch(System.IO.Path.GetExtension(f), "png"));

                string blockname = Regex.Replace(filename, @"\d+", "#");

                var matchfiles = images.Where((img)=>{
                    Console.WriteLine(img);
                    string onlyname = System.IO.Path.GetFileName(img);
                    return Regex.Replace(onlyname, @"\d+", "#").Equals(blockname);
                });

                if (matchfiles == null || matchfiles.Count() == 0)
                {
                    MessageBox.Show("동일한 이름 패턴을 가진 파일을 찾을 수 없습니다", "동일한 패턴의 파일이 없습니다", MessageBoxButton.OK);
                    return;
                }

                SqLabel.Content = string.Format("시퀀스 파일 ({0})", matchfiles.Count());

                OpenPath.Text = dir;         

                var split = Regex.Split(filename, @"\d+");
                var digit = Regex.Matches(filename, @"\d+");

                int digitIdx = 0;
                List<TextBlock> tb = new List<TextBlock>();
                for (int i = 0; i < filename.Length; i++)
                {
                    
                    while (tb.Count < digitIdx + 1)
                    {
                        var text = new TextBlock();
                        text.VerticalAlignment = VerticalAlignment.Center;
                        text.FontSize = 14;
                        tb.Add(text);
                        SqNumPanel.Children.Add(text);
                    }

                    if (digitIdx < digit.Count)
                    {
                        var currentDigit = digit[digitIdx];

                        if (i < currentDigit.Index)
                        {
                            tb[digitIdx].Text += filename[i];
                        }
                        else if (i == currentDigit.Index)
                        {
                            digitIdx++;
                            var btn = new RadioButton();
                            btn.Click += OnPatternClicked;
                            btn.FontSize = 14;
                            btn.FontWeight = FontWeights.Bold;
                            btn.GroupName = "SQNum";
                            btn.IsThreeState = false;
                            btn.Content = currentDigit.Value;
                            /*btn.Padding = new Thickness { Left=5, Right=5 };*/
                            btn.Margin = new Thickness { Left=5, Right=5, Top= btn.Margin.Top, Bottom= btn.Margin.Bottom };
                            SqNumPanel.Children.Add(btn);
                            i += currentDigit.Length-1;
                        }
                    }
                    else
                    {
                        tb[digitIdx].Text += filename[i];
                    }
                    
                }
            }
        }

        private void OnPatternClicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
