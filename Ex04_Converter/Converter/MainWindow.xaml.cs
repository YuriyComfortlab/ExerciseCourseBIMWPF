using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;

namespace Converter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string ParserRate(string currency)
        {
            WebClient client = new WebClient();
            string usd, eur, uah, amd;
            usd = eur = uah = amd = "";
            try
            {
                var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
                XDocument xdoc = XDocument.Parse(xml);
                var el = xdoc.Element("ValCurs").Elements("Valute");
                usd = el.Where(x => x.Attribute("ID").Value == "R01235").Select(x => x.Element("Value").Value).FirstOrDefault();
                eur = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
                uah = el.Where(x => x.Attribute("ID").Value == "R01720").Select(x => x.Element("Value").Value).FirstOrDefault();
                amd = el.Where(x => x.Attribute("ID").Value == "R01060").Select(x => x.Element("Value").Value).FirstOrDefault();
            }
            catch
            {
                MessageBox.Show("Ошибка связи с сайтом ЦБ", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            switch (currency)
            {
                case "usd":
                    {
                        return usd;
                    }
                case "eur":
                    {
                        return eur;
                    }
                case "uah":
                    {
                        return uah;
                    }
                case "amd":
                    {
                        return amd;
                    }
                default:
                    return "";
            }
        }
        private void rateGet_Click(object sender, RoutedEventArgs e)
        {
            rateDollarCB.Text = ParserRate("usd");
            rateEurCB.Text = ParserRate("eur");
            rateGrvnCB.Text = ParserRate("uah");
            rateDrmCB.Text = ParserRate("amd");
        }
        public string CalcRate(object rate, object sum, string parsRate)
        {
            double res;
            bool checkRate = double.TryParse((string)rate, out double rateDouble);
            bool checkSum = double.TryParse((string)sum, out double sumDouble);
            bool checkParsRate = double.TryParse((string)parsRate, out double parsRateDouble);

            if (!checkRate && (string)rate != "")

            {
                MessageBox.Show("Введено неверное значение вашего курса, расчет произведен по курсу ЦБ", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if ((checkRate || checkParsRate) && checkSum)
            {
                if (checkRate)
                {
                    res = rateDouble * sumDouble;
                }
                else
                {
                    res = parsRateDouble * sumDouble;
                }
                string resString = Convert.ToString(res);
                return resString;
            }
            else
            {
                MessageBox.Show("Введено неверное значение суммы или нет корректного значения курса", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resSumDollar.Text = CalcRate(rateDollar.Text, sumDollar.Text, rateDollarCB.Text);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            resSumEur.Text = CalcRate(rateEur.Text, sumEur.Text, rateEurCB.Text);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            resSumGrvn.Text = CalcRate(rateGrvn.Text, sumGrvn.Text, rateGrvnCB.Text);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            resSumDrm.Text = CalcRate(rateDrm.Text, sumDrm.Text, rateDrmCB.Text);
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            rateDollar.Text = sumDollar.Text = rateDollarCB.Text = resSumDollar.Text = null;
            rateEur.Text = sumEur.Text = rateEurCB.Text = resSumEur.Text = null;
            rateGrvn.Text = sumGrvn.Text = rateGrvnCB.Text = resSumGrvn.Text = null;
            rateDrm.Text = sumDrm.Text = rateDrmCB.Text = resSumDrm.Text = null;
        }

        public string CalcLength(object value, string unitsFrom, string unitsTo)
        {
            double resultMeters = 0;
            string meters, foots, milesLand, milesSea, yard, cab;
            meters = foots = milesLand = milesSea = yard = cab = "";
            double valueDouble = (double)value;
            switch (unitsFrom)
            {
                case "meters":
                    {
                        resultMeters = (valueDouble);
                        break;
                    }
                case "foots":
                    {
                        resultMeters = (valueDouble * 0.3048);
                        break;
                    }
                case "milesLand":
                    {
                        resultMeters = (valueDouble * 1609.344);
                        break;
                    }
                case "milesSea":
                    {
                        resultMeters = (valueDouble * 1852);
                        break;
                    }
                case "yard":
                    {
                        resultMeters = (valueDouble * 0.9144);
                        break;
                    }
                case "cab":
                    {
                        resultMeters = (valueDouble * 219.456004);
                        break;
                    }
                default:
                    {
                        break;
                    }

            }


            switch (unitsTo)
            {
                case "meters":
                    {
                        meters = Convert.ToString(resultMeters);
                        return meters;
                    }
                case "foots":
                    {
                        foots = Convert.ToString(resultMeters / 0.3048);
                        return foots;
                    }
                case "milesLand":
                    {
                        milesLand = Convert.ToString(resultMeters / 1609.344);
                        return milesLand;
                    }
                case "milesSea":
                    {
                        milesSea = Convert.ToString(resultMeters / 1852);
                        return milesSea;
                    }
                case "yard":
                    {
                        yard = Convert.ToString(resultMeters / 0.9144);
                        return yard;
                    }
                case "cab":
                    {
                        cab = Convert.ToString(resultMeters / 219.456004);
                        return cab;
                    }
                default:
                    return "";
            }


        }


        string units = "";
        public double CheckField()
        {
            bool checkMeters = double.TryParse(meters.Text, out double metersDouble);
            bool checkFoots = double.TryParse(foots.Text, out double footsDouble);
            bool checkMilesLand = double.TryParse(milesLand.Text, out double milesLandDouble);
            bool checkMilesSea = double.TryParse(milesSea.Text, out double milesSeaDouble);
            bool checkYard = double.TryParse(yard.Text, out double yardDouble);
            bool checkCab = double.TryParse(cab.Text, out double cabDouble);




            if (checkMeters)
            {
                units = "meters";
                return metersDouble;
            }
            else if (checkFoots)
            {
                units = "foots";
                return footsDouble;
            }
            else if (checkMilesLand)
            {
                units = "milesLand";
                return milesLandDouble;
            }
            else if (checkMilesSea)
            {
                units = "milesSea";
                return milesSeaDouble;
            }
            else if (checkYard)
            {
                units = "yard";
                return yardDouble;
            }
            else if (checkCab)
            {
                units = "cab";
                return cabDouble;
            }
            else
            {
                return 0;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            foots.Text = CalcLength(CheckField(), units, "foots");
            meters.Text = CalcLength(CheckField(), units, "meters");
            milesLand.Text = CalcLength(CheckField(), units, "milesLand");
            milesSea.Text = CalcLength(CheckField(), units, "milesSea");
            yard.Text = CalcLength(CheckField(), units, "yard");
            cab.Text = CalcLength(CheckField(), units, "cab");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            foots.Text = null;
            meters.Text = null;
            milesLand.Text = null;
            milesSea.Text = null;
            yard.Text = null;
            cab.Text = null;
        }


    }
}
