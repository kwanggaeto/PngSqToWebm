using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private string _currentFile;
        private string _currentInputPath;

        public MainWindow()
        {
            _persistant = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            if (!System.IO.Directory.Exists(_persistant))
                System.IO.Directory.CreateDirectory(_persistant);

            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            string settingsPath = System.IO.Path.Combine(_persistant, "appSettings.json");

            if (!System.IO.File.Exists(settingsPath))
            {
                string json = JsonConvert.SerializeObject(new AppSettings { lastworkDirectory= Environment.CurrentDirectory });
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var fs = System.IO.File.Create(settingsPath);

                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                fs.Dispose();
            }

            string settingsText = System.IO.File.ReadAllText(settingsPath);

            JsonConvert.DeserializeObject<AppSettings>(settingsText);

            AppSettings.Value.settingsFilePath = settingsPath;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            SqNumPanel.Children.Clear();

            var browser = new OpenFileDialog();
            browser.Title = "시퀀스의 첫번째 파일을 선택해 주세요";
            browser.InitialDirectory = AppSettings.Value.lastworkDirectory;
            browser.Filter = "PNG File (*.png)|*.png";
            browser.Multiselect = false;
            var res = browser.ShowDialog();

            if (res.HasValue && res.Value)
            {
                _currentFile = browser.FileName;
                var dir = System.IO.Path.GetDirectoryName(browser.FileName);
                var filename = System.IO.Path.GetFileName(browser.FileName);

                string[] files = System.IO.Directory.GetFiles(dir, "*", System.IO.SearchOption.TopDirectoryOnly);

                var images = files.Where(f=>Regex.IsMatch(System.IO.Path.GetExtension(f), "png"));

                string blockname = Regex.Replace(filename, @"\d", "#");

                var matchfiles = images.Where((img)=>
                {
                    string onlyname = System.IO.Path.GetFileName(img);
                    return Regex.Replace(onlyname, @"\d", "#").Equals(blockname);
                });

                if (matchfiles == null || matchfiles.Count() <= 1)
                {
                    MessageBox.Show("동일한 이름 패턴을 가진 파일을 찾을 수 없습니다", "동일한 패턴의 파일이 없습니다", MessageBoxButton.OK);
                    return;
                }

                AppSettings.Value.lastworkDirectory = dir;
                AppSettings.Value.Save();

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
                            var btn = new RadioButton();
                            btn.DataContext = currentDigit;
                            btn.Checked += OnIsPattern;
                            btn.FontSize = 14;
                            btn.FontWeight = FontWeights.Bold;
                            btn.GroupName = "SQNum";
                            btn.IsThreeState = false;
                            btn.Content = currentDigit.Value;
                            /*btn.Padding = new Thickness { Left=5, Right=5 };*/
                            btn.Margin = new Thickness { Left=5, Right=5, Top= btn.Margin.Top, Bottom= btn.Margin.Bottom };
                            SqNumPanel.Children.Add(btn);
                            i += currentDigit.Length-1;
                            digitIdx++;
                        }
                    }
                    else
                    {
                        tb[digitIdx].Text += filename[i];
                    }
                    
                }
            }
        }

        private void OnIsPattern(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFile))
                return;

            RadioButton btn = sender as RadioButton;
            Match m = btn.DataContext as Match;

            var dir = System.IO.Path.GetDirectoryName(_currentFile);
            var filename = System.IO.Path.GetFileName(_currentFile);
            var pattern = filename.Remove(m.Index, m.Length).Insert(m.Index, string.Format("%0{0}d", m.Length));
            _currentInputPath = System.IO.Path.Combine(dir, pattern);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var browser = new SaveFileDialog();
            browser.Filter = "WebM (*.webm)|*.webm";
            browser.Title = "저장할 Webm 파일의 경로를 지정해 주세요";
            var res = browser.ShowDialog();

            if (res.HasValue && res.Value)
            {
                SavePath.Text = browser.FileName;
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentFile))
            {
                MessageBox.Show("시퀀스 파일이 지정되지 않았습니다.", "오류", MessageBoxButton.OK);
                return;
            }

            if (string.IsNullOrEmpty(_currentInputPath))
            {
                MessageBox.Show("시퀀스 파일의 패턴이 지정되지 않았습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(SavePath.Text))
            {
                MessageBox.Show("저장 경로가 지정되지 않았습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(AppSettings.Value.ffmpegPath))
            {
                MessageBox.Show("FFmpeg 파일 경로가 지정되지 않았습니다", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!System.IO.File.Exists(AppSettings.Value.ffmpegPath))
            {
                MessageBox.Show("지정한 경로에 FFmpeg 파일이 없습니다", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!System.IO.File.Exists(AppSettings.Value.ffmpegPath))
            {
                MessageBox.Show("지정한 경로에 FFmpeg 파일이 없습니다", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            CheckExist:
            if (System.IO.File.Exists(SavePath.Text))
            {
                var res = MessageBox.Show("동일한 이름의 파일이 있습니다. 덮어쓰시겠습니까?", "경고", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {

                }
                else
                {
                    var browser = new SaveFileDialog();
                    browser.Filter = "WebM (*.webm)|*.webm";
                    browser.Title = "저장할 Webm 파일의 경로를 지정해 주세요";
                    var res = browser.ShowDialog();

                    if (res.HasValue && res.Value)
                    {
                        SavePath.Text = browser.FileName;
                        goto
                    }
                }
            }

            string frameRate = string.IsNullOrEmpty(FrameRateField.Text)?"30": FrameRateField.Text;
            string bitRate = string.IsNullOrEmpty(BitRateField.Text)?"10000": BitRateField.Text;

            ProcessStartInfo psi = new ProcessStartInfo(AppSettings.Value.ffmpegPath, 
                string.Format("-framerate {2} -f image2 -i {0} -vcodec vp8 -acodec libvorbis " +
                "-metadata:s:v:0 alpha_mode=\"1\" -auto-alt-ref 0 -b:v {3}k {1}", _currentInputPath, SavePath.Text, frameRate, bitRate));
            psi.CreateNoWindow = !IsShowConsole.IsChecked.HasValue || !IsShowConsole.IsChecked.Value;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            var proc = Process.Start(psi);
            proc.OutputDataReceived += OnProcess;
        }

        private void OnProcess(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _currentFile = null;
            _currentInputPath = null;
            OpenPath.Text = "";
            SavePath.Text = "";
            SqNumPanel.Children.Clear();
        }

        private void FFmpegMenu_Click(object sender, RoutedEventArgs e)
        {
            var browser = new OpenFileDialog();
            browser.Title = "FFmpeg 파일을 선택해 주세요";
            browser.InitialDirectory = AppSettings.Value.lastworkDirectory;
            browser.Filter = "Executable File (*.exe)|*.exe";
            browser.Multiselect = false;
            var res = browser.ShowDialog();

            if (res.HasValue && res.Value)
            {
                AppSettings.Value.ffmpegPath = browser.FileName;
                AppSettings.Value.Save();
            }
        }
    }
}
