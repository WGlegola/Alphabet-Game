using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double baseFontSize;
        private double baseWindowWidth;
        private double baseWindowHeight;
        private double baseLineWidth;
        private double baseLineHeight;
        private double baseLineVerticalMargin;
        private double baseLineHorisontalMargin;
        WindowState LastWindowState;
        String AlphabetBox1Text;
        String AlphabetBox2Text;

        Stopwatch scalingStopWatch;
        Boolean isWidthScaling;

        public MainWindow()
        {
            InitializeComponent();

            baseFontSize = AlphabetBox1.FontSize;
            baseWindowWidth = MainWindow1.Width;
            baseWindowHeight = MainWindow1.Height;
            baseLineWidth = AlphabetBox1.Width;
            baseLineHeight = AlphabetBox1.Height;
            baseLineVerticalMargin = AlphabetBox1.Margin.Top;
            baseLineHorisontalMargin = AlphabetBox1.Margin.Left;
            LastWindowState = MainWindow1.WindowState;
            AlphabetBox1Text = AlphabetBox1.Text;
            AlphabetBox2Text = AlphabetBox2.Text;

            scalingStopWatch = new Stopwatch();

            //generating commands
            char[] commands = { 'L', 'O', 'P' };
            Random random = new Random();
            int lastCommand = -1, secondLastCommand = -1, currentCommand = -1;

            //first row
            char[] arr1 = new char[26];
            for(int i = 0; i < 26; ++i)
            {
                arr1[i] = ' ';
            }
            for (int i = 0; i < AlphabetBox1Text.Length; i += 2)
            {
                do
                {
                    currentCommand = random.Next(3);
                }
                while ((currentCommand.Equals(lastCommand) && random.Next(100) < 90) ||  AlphabetBox1.Text[i].Equals(commands[currentCommand]) ||
                    (currentCommand.Equals(secondLastCommand) && random.Next(100) < 60));
                secondLastCommand = lastCommand;
                lastCommand = currentCommand;
                arr1[i] = commands[currentCommand];
                arr1[i + 1] = ' ';
            }
            CommandBox1.Text = new String(arr1);

            //second row
            char[] arr2 = new char[26];
            for (int i = 0; i < 26; ++i)
            {
                arr2[i] = ' ';
            }
            for (int i = 0; i < AlphabetBox2Text.Length; i += 2)
            {
                do
                {
                    currentCommand = random.Next(3);
                }
                while ((currentCommand.Equals(lastCommand) && random.Next(100) < 90) || AlphabetBox2.Text[i].Equals(commands[currentCommand]) ||
                    (currentCommand.Equals(secondLastCommand) && random.Next(100) < 60));
                secondLastCommand = lastCommand;
                lastCommand = currentCommand;
                arr2[i] = commands[currentCommand];
                arr2[i + 1] = ' ';
            }
            CommandBox2.Text = new String(arr2);
        }
        

        private void changeSize(object sender, SizeChangedEventArgs e)
        {
            //maintain scale ratio
            if (e.WidthChanged && scalingStopWatch.)
            {
                MainWindow1.Height = baseWindowHeight * e.NewSize.Width / baseWindowWidth;
            }
            else
            {
                MainWindow1.Width = baseWindowWidth * e.NewSize.Height / baseWindowHeight;
            }

            //scaling gui
            double scale = MainWindow1.Height / baseWindowHeight;

            AlphabetBox1.FontSize = baseFontSize * scale;
            AlphabetBox1.Width = baseLineWidth * scale;
            AlphabetBox1.Height = baseLineHeight * scale;
            Thickness margin1 = AlphabetBox1.Margin;
            margin1.Left = baseLineHorisontalMargin * scale;
            margin1.Top = baseLineVerticalMargin * scale;
            AlphabetBox1.Margin = margin1;

            CommandBox1.FontSize = baseFontSize * scale;
            CommandBox1.Width = baseLineWidth * scale;
            CommandBox1.Height = baseLineHeight * scale;
            Thickness margin2 = CommandBox1.Margin;
            margin2.Left = baseLineHorisontalMargin * scale;
            margin2.Top = baseLineVerticalMargin * scale * 2 + baseLineHeight * scale;
            CommandBox1.Margin = margin2;

            AlphabetBox2.FontSize = baseFontSize * scale;
            AlphabetBox2.Width = baseLineWidth * scale;
            AlphabetBox2.Height = baseLineHeight * scale;
            Thickness margin3 = AlphabetBox2.Margin;
            margin3.Left = baseLineHorisontalMargin * scale;
            margin3.Top = baseLineVerticalMargin * scale * 3 + baseLineHeight * scale * 2;
            AlphabetBox2.Margin = margin3;

            CommandBox2.FontSize = baseFontSize * scale;
            CommandBox2.Width = baseLineWidth * scale;
            CommandBox2.Height = baseLineHeight * scale;
            Thickness margin4 = CommandBox2.Margin;
            margin4.Left = baseLineHorisontalMargin * scale;
            margin4.Top = baseLineVerticalMargin * scale * 4 + baseLineHeight * scale *3;
            CommandBox2.Margin = margin4;

        }

        private void stateChanged(object sender, EventArgs e)
        {
            if(MainWindow1.WindowState.Equals(WindowState.Normal))
            {

            }else if(MainWindow1.WindowState.Equals(WindowState.Maximized))
            {
            }
        }
    }
}
