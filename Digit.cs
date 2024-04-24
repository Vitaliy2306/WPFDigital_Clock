using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;




namespace WpfDigitalClock
{
    public class Digit : Panel
    {
        

        // Ширина цифри без фаски (скошених елементів) і проміжків.
        double widthBlankSegment = 100;

        // Висота квадрату верхньої чи нижньої половинок цифри.
        // Цифра складається із верхньої і нижньої половинок.
        public double heightBlankSegment = 100;

        // Товщина сегментів - обрізаних  полігонів.
        double thicknessSegment = 30;

        // Зміщення точок ліній суміжних полігонів
        // до центрального полігону (елементу).
        // Для керування товщини центрального сегмента
        double correctCenter = 10;

        // Зміщення сегментів цифри один від одного,
        // значення змінює проміжок між сегментами. 
        double _strokeThickness = 1;
        public double StrokeThickness
        {
            get { return _strokeThickness; }
            set { _strokeThickness = value; }
        }

        // Колір сегментів цифри.
        SolidColorBrush _colorDigit = Brushes.Black;
        public SolidColorBrush ColorDigit
        {
            get { return _colorDigit; }
            set
            {
                _colorDigit = value;
                // Якщо в XAML було скидання чи в інших випадках,
                // то відновлюємо пензлик за замовчуванням.
                if (value == null) _colorDigit = Brushes.Black;

                // Перемальовуємо сегменти.
                DrawDigit(0, 0);
            }
        }

        

        public Digit() : base()
        {
            // Розмір цифри за замовчуванням
            Width = 100;

            // Иніціалізація полігонів - сегментів цифри,
            // і додавання їх в колекцію дочірніх сегментів 
            // батьківської панелі.
            for (int i = 0; i < 7; i++)
            {
                Children.Add(new Polygon());
            }
        }

        


        

        // Візуалізація значень цифри.
        public void ValueDigit(int digit)
        {
            switch (digit)
            {
                case 0:
                    // Ліве
                    Children[0].Opacity = 1;
                    // Верхнє
                    Children[1].Opacity = 1;
                    // Праве
                    Children[2].Opacity = 1;
                    // Центральне
                    Children[3].Opacity = 0;
                    // Ліве знизу
                    Children[4].Opacity = 1;
                    // Нижнє
                    Children[5].Opacity = 1;
                    // Праве знизу
                    Children[6].Opacity = 1;

                    break;
                case 1:
                    // Ліве
                    Children[0].Opacity = 0;
                    // Верхнє
                    Children[1].Opacity = 0;
                    // Праве
                    Children[2].Opacity = 1;
                    // Центральне
                    Children[3].Opacity = 0;
                    // Ліве знизу
                    Children[4].Opacity = 0;
                    // Нижнє
                    Children[5].Opacity = 0;
                    // Праве знизу
                    Children[6].Opacity = 1;

                    break;
                case 2:
                    // Ліве
                    Children[0].Opacity = 0;
                    // Верхнє
                    Children[1].Opacity = 1;
                    // Праве
                    Children[2].Opacity = 1;
                    // Центральне
                    Children[3].Opacity = 1;
                    // Ліве знизу
                    Children[4].Opacity = 1;
                    // Нижнє
                    Children[5].Opacity = 1;
                    // Праве знизу
                    Children[6].Opacity = 0;
                    break;
                case 3:
                    // Ліве
                    Children[0].Opacity = 0;
                    // Верхнє
                    Children[1].Opacity = 1;
                    // Праве
                    Children[2].Opacity = 1;
                    // Центральне
                    Children[3].Opacity = 1;
                    // Ліве знизу
                    Children[4].Opacity = 0;
                    // Нижнє
                    Children[5].Opacity = 1;
                    // Праве знизу
                    Children[6].Opacity = 1;
                    break;
                case 4:
                    // Ліве
                    Children[0].Opacity = 1;
                    // Верхнє
                    Children[1].Opacity = 0;
                    // Праве
                    Children[2].Opacity = 1;
                    // Центральне
                    Children[3].Opacity = 1;
                    // Ліве нижнє
                    Children[4].Opacity = 0;
                    // Нижнє
                    Children[5].Opacity = 0;
                    // Праве нижнє
                    Children[6].Opacity = 1;
                    break;
                case 5:
                    // Ліве
                    Children[0].Opacity = 1;
                    // Верхнє
                    Children[1].Opacity = 1;
                    // Праве
                    Children[2].Opacity = 0;
                    // Центральне
                    Children[3].Opacity = 1;
                    // Ліве верхнє
                    Children[4].Opacity = 0;
                    // Нижнє
                    Children[5].Opacity = 1;
                    // Праве верхнє
                    Children[6].Opacity = 1;
                    break;
                case 6:
                    // Ліве
                    Children[0].Opacity = 1;
                    // Верхнє
                    Children[1].Opacity = 1;
                    // Праве
                    Children[2].Opacity = 0;
                    // Центральне
                    Children[3].Opacity = 1;
                    // Ліве нижнє
                    Children[4].Opacity = 1;
                    // Нижнє
                    Children[5].Opacity = 1;
                    // Праве нижнє
                    Children[6].Opacity = 1;
                    break;
                case 7:
                    // Ліве
                    Children[0].Opacity = 0;
                    // Верхнє
                    Children[1].Opacity = 1;
                    // Праве
                    Children[2].Opacity = 1;
                    // Центральне
                    Children[3].Opacity = 0;
                    // Ліве нижнє
                    Children[4].Opacity = 0;
                    // Нижнє
                    Children[5].Opacity = 0;
                    // Праве нижнє
                    Children[6].Opacity = 1;
                    break;
                case 8:
                    // Ліве
                    Children[0].Opacity = 1;
                    // Верхнє
                    Children[1].Opacity = 1;
                    // Праве
                    Children[2].Opacity = 1;
                    // Center
                    Children[3].Opacity = 1;
                    // LeftBottom
                    Children[4].Opacity = 1;
                    // Bottom
                    Children[5].Opacity = 1;
                    // RightBottom
                    Children[6].Opacity = 1;
                    break;
                case 9:
                    // Left
                    Children[0].Opacity = 1;
                    // Top
                    Children[1].Opacity = 1;
                    // Right
                    Children[2].Opacity = 1;
                    // Center
                    Children[3].Opacity = 1;
                    // LeftBottom
                    Children[4].Opacity = 0;
                    // Bottom
                    Children[5].Opacity = 1;
                    // RightBottom
                    Children[6].Opacity = 1;
                    break;
            }



        }

    


        #region Вычисление размеров для сегментов цифры

        private void ComputeSize()
        {
            // Возможно при сбросе ширины в XAML дизайнере.
            if (double.IsNaN(Width) == true) Width = 100;

            // Вычисление ширины цифры на основе заданной пользователем общей ширины.
            widthBlankSegment = Width - (2 * thicknessSegment / 3 + _strokeThickness * 2);

            // Высота сегментов половинки и ширина цифры всегда одинаковые.
            // Цифра состоит из верхней половинки и нижней половинки.
            heightBlankSegment = widthBlankSegment;

            // Корректировка толщины центрального сегмента,
            // для уравнивания с толщинами других сегментов.
            correctCenter = widthBlankSegment / 8;

            // Корректировка толщины сегментов цифры.
            thicknessSegment = widthBlankSegment / 4;

            // Вычисление общей высоты цифры с верхней и нижней половинками.
            Height = heightBlankSegment * 2 + 2 * thicknessSegment / 3 + _strokeThickness * 2 + _strokeThickness * 2;

            // Рисование полной цифры с новыми размерами.
            DrawDigit(0, 0);
        }

        #endregion


        #region Рисование графики элементов цифры

        void DrawDigit(double x, double y)
        {
            x = x +
                // Смещение вправо на фаску левых сегментов
                thicknessSegment / 3 +
                // Смещение вправо на толщину промежутка
                // (смещение левых сегментов вправо для создания промежутка).
                _strokeThickness;

            // Смещение по высоте на фаску сегмента и
            // межсегментного промежутка (смещения верхнего элемента вверх для создания промежутка между сегментами).
            y = y + thicknessSegment / 3 + _strokeThickness;

            // Рисование сегментов цифры.
            SegmentLeft(x, y, _colorDigit, _strokeThickness);
            SegmentTop(x, y, _colorDigit, _strokeThickness);
            SegmentRight(x, y, _colorDigit, _strokeThickness);
            SegmentCenter(x, y, _colorDigit, _strokeThickness);
            SegmentLeftBottom(x, y, _colorDigit, _strokeThickness);
            SegmentBottom(x, y, _colorDigit, _strokeThickness);
            SegmentRightBottom(x, y, _colorDigit, _strokeThickness);
        }

        void SegmentLeft(double x, double y, SolidColorBrush color, double strokeThickness)
        {
            Polygon pg = (Polygon)Children[0];
            PointCollection Points = new()
            {
				// left
				new System.Windows.Point(x - widthBlankSegment / 2, y + heightBlankSegment / 2),
				// top
				new Point(x, y),
				// right
				new Point(x + widthBlankSegment / 2, y + heightBlankSegment / 2),
				// right2
				new Point(x + widthBlankSegment / 2, y + heightBlankSegment / 2 + correctCenter /*корректирвка центрального*/),
				// bottom
				new Point(x, y + heightBlankSegment)
            };
            pg.Points = Points;
            pg.Fill = color;

            TranslateTransform tt = new()
            {
                X = -strokeThickness
            };
            pg.RenderTransform = tt;

            // Обрезание прямоугольного полигона до трапеции.
            RectangleGeometry rg = new()
            {
                Rect = new Rect(x - thicknessSegment / 3, y, thicknessSegment, heightBlankSegment)
            };
            pg.Clip = rg;
        }

        void SegmentTop(double x, double y, SolidColorBrush color, double strokeThickness)
        {
            Polygon pg = (Polygon)Children[1];
            PointCollection Points = new()
            {
                new Point(x + widthBlankSegment / 2, y - heightBlankSegment / 2),
                new Point(x + widthBlankSegment, y),
                new Point(x + widthBlankSegment / 2, y + heightBlankSegment / 2),
                new Point(x, y)
            };
            pg.Points = Points;
            pg.Fill = color;

            TranslateTransform tt = new()
            {
                Y = -strokeThickness
            };
            pg.RenderTransform = tt;

            RectangleGeometry rg = new()
            {
                Rect = new Rect(x, y - thicknessSegment / 3, widthBlankSegment, thicknessSegment)
            };
            pg.Clip = rg;
        }

        void SegmentRight(double x, double y, SolidColorBrush color, double strokeThickness)
        {
            Polygon pg = (Polygon)Children[2];
            PointCollection Points = new()
            {
                // left-correct
                new Point(x + widthBlankSegment / 2,y + heightBlankSegment / 2 + correctCenter),
                // left
                new Point(x + widthBlankSegment / 2,y + heightBlankSegment / 2),
                // top
                new Point(x + widthBlankSegment, y),
                // right
                new Point(x + widthBlankSegment*1.5, y + heightBlankSegment / 2),

                new Point(x + widthBlankSegment, y + heightBlankSegment)
            };
            pg.Points = Points;
            pg.Fill = color;

            TranslateTransform tt = new()
            {
                X = strokeThickness
            };
            pg.RenderTransform = tt;

            RectangleGeometry rg = new()
            {
                Rect = new Rect(x - thicknessSegment / 1.5 + widthBlankSegment, y, thicknessSegment, heightBlankSegment)
            };
            pg.Clip = rg;
        }

        void SegmentCenter(double x, double y, SolidColorBrush color, double strokeThickness)
        {
            Polygon pg = (Polygon)Children[3];
            PointCollection Points = new()
            {
                // top
                new Point(x + widthBlankSegment/2, y + heightBlankSegment / 2 + correctCenter /*корректирвка центрального*/),
                new Point(x + widthBlankSegment, y + heightBlankSegment),
                // bottom
                new Point(x + widthBlankSegment/2, y + heightBlankSegment*1.5 - correctCenter /*корректирвка центрального*/),
                new Point(x, y + heightBlankSegment)
            };
            pg.Points = Points;
            pg.Fill = color;

            TranslateTransform tt = new()
            {
                Y = strokeThickness
            };
            pg.RenderTransform = tt;

            RectangleGeometry rg = new()
            {
                Rect = new Rect(x, y + heightBlankSegment - thicknessSegment / 2, widthBlankSegment, thicknessSegment)
            };

            pg.Clip = rg;
        }

        void SegmentLeftBottom(double x, double y, SolidColorBrush color, double strokeThickness)
        {
            Polygon pg = (Polygon)Children[4];
            PointCollection Points = new()
            {
                // left
                new Point(x - widthBlankSegment / 2, y + heightBlankSegment *  1.5),
                // top
                new Point(x, y + heightBlankSegment),
                // right correct
                new Point(x + widthBlankSegment / 2, y - correctCenter + heightBlankSegment *  1.5),
                // right
                new Point(x + widthBlankSegment / 2, y + heightBlankSegment *  1.5),
                // bottom
                new Point(x, y + heightBlankSegment * 2)
            };
            pg.Points = Points;
            pg.Fill = color;

            TranslateTransform tt = new()
            {
                X = -strokeThickness,
                Y = 2 * strokeThickness
            };
            pg.RenderTransform = tt;

            RectangleGeometry rg = new()
            {
                Rect = new Rect(x - thicknessSegment / 3, y + heightBlankSegment, thicknessSegment, heightBlankSegment)
            };
            pg.Clip = rg;
        }

        void SegmentBottom(double x, double y, SolidColorBrush color, double strokeThickness)
        {
            Polygon pg = (Polygon)Children[5];
            PointCollection Points = new()
            {
                new Point(x + widthBlankSegment / 2, y  + heightBlankSegment * 1.5) ,
                new Point(x + widthBlankSegment, y + heightBlankSegment * 2) ,
                new Point(x + widthBlankSegment / 2, y + heightBlankSegment * 2.5) ,
                new Point(x, y + heightBlankSegment * 2)
            };

            pg.Points = Points;
            pg.Fill = color;

            TranslateTransform tt = new()
            {
                Y = 3 * strokeThickness
            };
            pg.RenderTransform = tt;

            RectangleGeometry rg = new()
            {
                Rect = new Rect(x, y - thicknessSegment / 1.5 + heightBlankSegment * 2, widthBlankSegment, thicknessSegment)
            };
            pg.Clip = rg;
        }

        void SegmentRightBottom(double x, double y, SolidColorBrush color, double strokeThickness)
        {
            Polygon pg = (Polygon)Children[6];
            pg.Points = new PointCollection()
            {
                // left 
                new Point(x + widthBlankSegment / 2, y + heightBlankSegment * 1.5) ,
                // left correct
                new Point(x + widthBlankSegment / 2, y + heightBlankSegment * 1.5 - correctCenter) ,
                new Point(x + widthBlankSegment, y + heightBlankSegment) ,
                new Point(x + widthBlankSegment * 1.5, y + heightBlankSegment * 1.5) ,
                new Point(x + widthBlankSegment, y + heightBlankSegment * 2)
            };
            pg.Fill = color;

            TranslateTransform tt = new()
            {
                X = strokeThickness,
                Y = 2 * strokeThickness
            };
            pg.RenderTransform = tt;

            RectangleGeometry rg = new()
            {
                Rect = new Rect(x - thicknessSegment / 1.5 + widthBlankSegment, y + heightBlankSegment, thicknessSegment, heightBlankSegment)
            };
            pg.Clip = rg;
        }

        #endregion


        #region Переопределенные  методы класса Panel

        
        // Измерение дочерних элементов
        protected override Size MeasureOverride(Size availableSize)
        {
            Size panelDesiredSize = new();

            foreach (UIElement child in InternalChildren)
            {
                
                child.Measure(availableSize);
                panelDesiredSize = child.DesiredSize;
            }

            return panelDesiredSize;
        }


        // Размещение дочерних элементов
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                
                child.Arrange(new Rect(new Point(), child.DesiredSize));
            }

            // Вычисление размеров всей цифры в зависимости от ширины панели.
            ComputeSize();

            return finalSize;
        }

        #endregion
    }
}
