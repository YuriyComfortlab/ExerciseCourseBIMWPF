/*1. Разработать в WPF приложении класс WeatherControl, моделирующий погодную сводку 
 * – температуру (целое число в диапазоне от -50 до +50), 
 * направление ветра (строка), 
 * скорость ветра (целое число), 
 * наличие осадков (возможные значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег. Можно использовать целочисленное значение, либо создать перечисление enum). 
 * Свойство «температура» преобразовать в свойство зависимости.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PropertyTemp
{
    class WetherControl : DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        private string directionWind;
        private int speedWind;
        //private enum precipitation : int
        //{
        //    Sunny = 0,
        //    Cloudy = 1,
        //    Rain = 2,
        //    Snow = 3
        //}
        private int precipitation;

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        public string DirectionWind
        {
            get => directionWind;
            set => directionWind = value;
        }

        public int SpeedWind
        {
            get => speedWind;
            set => speedWind = value;
        }

        public enum Precipitations : int
        {
                Sunny = 0,
                Cloudy = 1,
                Rain = 2,
                Snow = 3
        }

        // не уверен что правильно определил свойство с перечислением

        public Precipitations Precipitation 
        {
            //set
            //{
            //    if ((int)value >= 0 && (int)value <= 3)
            //    {
            //        precipitation = (int)value;
            //    }
            //    else
            //    {
            //        precipitation = 0;
            //    }
            //}
            //get
            //{
            //    return (Precipitations)precipitation;
            //}
            get;set;
        }
           

        public WetherControl(int temp, string directionWind, int speedWind, int precipitation)
        {
            this.Temp = temp;
            this.DirectionWind = directionWind;
            this.SpeedWind = speedWind;
            this.Precipitation = (WetherControl.Precipitations)precipitation;
        }

        static WetherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WetherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemp)
                    ),
                new ValidateValueCallback(ValidateTemp)
                );
        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
            {
                return true;
            }            
            else
            {
                return false;
            }
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else if (v < -50)
            {
                return -50;
            }
            else if (v > 50)
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }

        public string Print()
        {
            return $"{Temp}  {DirectionWind}  {SpeedWind}  {Precipitation}";
        }
    }
}

