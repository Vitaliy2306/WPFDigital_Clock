using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;


namespace WpfDigitalClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Таймер слідкування за поточним часом.
        readonly DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();

            // Иніціалізація і запуск таймера.
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatcherTimer.Start();
        }


        

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            ShowDateTime();
        }


        // Лічильник тем
        int countTheme = 0;
        // Вибір кольорових тем
        private void BorderColors_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (SolidColorBrush color, SolidColorBrush bg)  = ThemeGenerator(countTheme);

            ThemeClock(color, bg);

            countTheme++;
            if (countTheme == 6) countTheme = 0;
        }


        // Зміщення вікна захоплюючи клієнтську частину
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        // Перемикання в пвноекранний режим і навпаки.
        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }


        // Закриття вікна
        private void BorderClose_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Відступ головного контейнера для цифр 2,5% від ширини вікна.
            maingrid.Margin = new Thickness(this.Width * 0.025);
        }

      


        

        // Отримання поточного часу і дати.
        // Вивід на табло.
        void ShowDateTime()
        {
            // Отримання і виведення часу 
            string time = DateTime.Now.ToString("HHmmss");
            int h1 = int.Parse(time.ToString()[0].ToString());
            int h2 = int.Parse(time.ToString()[1].ToString());
            int m1 = int.Parse(time.ToString()[2].ToString());
            int m2 = int.Parse(time.ToString()[3].ToString());
            int s1 = int.Parse(time.ToString()[4].ToString());
            int s2 = int.Parse(time.ToString()[5].ToString());
            digit1.ValueDigit(h1);
            digit2.ValueDigit(h2);
            digit3.ValueDigit(m1);
            digit4.ValueDigit(m2);
            digit5.ValueDigit(s1);
            digit6.ValueDigit(s2);

            // Отримання і виведення дати
            string date = DateTime.Now.ToString("ddMMyyyy");
            int d1 = int.Parse(date.ToString()[0].ToString());
            int d2 = int.Parse(date.ToString()[1].ToString());
            int M1 = int.Parse(date.ToString()[2].ToString());
            int M2 = int.Parse(date.ToString()[3].ToString());
            int y1 = int.Parse(date.ToString()[4].ToString());
            int y2 = int.Parse(date.ToString()[5].ToString());
            int y3 = int.Parse(date.ToString()[6].ToString());
            int y4 = int.Parse(date.ToString()[7].ToString());
            digitD1.ValueDigit(d1);
            digitD2.ValueDigit(d2);
            digitM1.ValueDigit(M1);
            digitM2.ValueDigit(M2);
            digitY1.ValueDigit(y1);
            digitY2.ValueDigit(y2);
            digitY3.ValueDigit(y3);
            digitY4.ValueDigit(y4);

            // Отримання і виведення дня тижня
            string day = DateTime.Now.ToString("ddd");
            labelddd.Content = day;
        }


        // призначення кольорових тем цифрового годинника.
        void ThemeClock(SolidColorBrush color, SolidColorBrush bg)
        {
            // Фон, табло годинника.
            this.Background = bg;


            // Цифри табло
            digit1.ColorDigit = color;
            digit2.ColorDigit = color;
            digit3.ColorDigit = color;
            digit4.ColorDigit = color;
            digit5.ColorDigit = color;
            digit6.ColorDigit = color;
            digitD1.ColorDigit = color;
            digitD2.ColorDigit = color;
            digitM1.ColorDigit = color;
            digitM2.ColorDigit = color;
            digitY1.ColorDigit = color;
            digitY2.ColorDigit = color;
            digitY3.ColorDigit = color;
            digitY4.ColorDigit = color;

            // Розподільчі точки (еліпси)
            dotTime1.Fill = color;
            dotTime2.Fill = color;
            dotDate1.Fill = color;
            dotDate2.Fill = color;

            // Розподільчі лінії.
            lineSeparator.Stroke = color;
            lineControl.Stroke = color;

            // Кнопка зміни кольору
            borderColors.BorderBrush = color;
            ellipseColors1.Stroke = color;
            ellipseColors1.Fill = bg;
            ellipseColors2.Stroke = color;
            ellipseColors2.Fill = color;

            // Кнопка закриття
            borderClose.BorderBrush = color;
            lineClose1.Stroke = color;
            lineClose2.Stroke = color;

            // Колір текстових міток.
            labelddd.Foreground = color;
            labelIP.Foreground = color;

            // Смайлик (Path) (Заради жарту)
            smile.Stroke = color;
        }


        // Генератор тем,
        // на виходе выдає колір графічних елементів і
        // колір фону дисплею годинника.
        public static (SolidColorBrush color, SolidColorBrush bg) ThemeGenerator(int count) => count switch
        {
            0 => (Brushes.Red, Brushes.Black),
            1 => (new SolidColorBrush(Color.FromRgb(70, 255, 70)), Brushes.Black),
            2 => (new SolidColorBrush(Color.FromRgb(30, 150, 255)), Brushes.Black),
            3 => (Brushes.Yellow, Brushes.Black),
            4 => (Brushes.White, Brushes.Black),
            _ => (Brushes.Black, new SolidColorBrush(Color.FromRgb(118, 167, 148)))
        };


        

    }
}
