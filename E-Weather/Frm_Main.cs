using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
namespace E_Weather
{
    public partial class Frm_Main : Form
    {
        public String city;//城市名，公有字段，同一命名空间下的类均可使用
        public Frm_Main()
        {
            InitializeComponent();
            this.getCityFromIP();
        }

        private void WeatherLoad()
        {
            // * 窗口加载事件
            // * 1.获取城市名
            // * 2.调用服务
            // * 3.得到返回数据
            // * 判断返回数据
            // * 1.空，则只把城市介绍的label填为无此城市的天气信息
            //*2.不空 填充对应项的数据
            cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
            string[] str = w.getWeatherbyCityName(this.city);
            if (str[1] == null)
            {
                MessageBox.Show("这城市或区域暂时不被支持", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                //外框

                LbDate.Text = str[4].Substring(0,8);
                LbCity.Text=str[1];
                LbCityInf.Text=str[22];
                PbWeatherPic1.ImageLocation = "http://www.webxml.com.cn/images/weather/a_" + str[8];
                PbWeatherPic2.ImageLocation = "http://www.webxml.com.cn/images/weather/a_" + str[9];
                //string strDest=source.Substring(source.IndexOf("CompanyName:"),source.IndexOf("Exports TEUs:"));
                //气象指数
                LbTime.Text =str[4];
                LbLocation.Text=str[0]+" "+str[1];
                LbTemperature.Text=str[5];
                LbWeather.Text = str[6].Substring(4,str[6].Length-4);
                LbWind.Text = str[7];
                LbTimeWeather.Text = str[10];
                //未来两天
                LbTomorrow.Text = str[13];
                LbTomorrowTemperature.Text = str[12];
                LbTomorrowWind.Text=str[14];
                PbWeatherPic3.ImageLocation = "http://www.webxml.com.cn/images/weather/a_" + str[15];
                PbWeatherPic4.ImageLocation = "http://www.webxml.com.cn/images/weather/a_" + str[16];
                LbLastDay.Text = str[18];
                LbLastDayTemperature.Text=str[17];
                LbLastDayWind.Text = str[19];
                PbWeatherPic5.ImageLocation = "http://www.webxml.com.cn/images/weather/a_" + str[20];
                PbWeatherPic6.ImageLocation = "http://www.webxml.com.cn/images/weather/a_" + str[21];
                //生活指数
                LblifeNum.Text=str[11];
            }
        }

        private void BtnCityChange_Click(object sender, EventArgs e)
        {
            // * 切换城市按钮的点击事件
            // * 1.实例化问询窗口
            // * 2.获取值
            // * 3.调用窗口加载事件**/
            Frm_input frm = new Frm_input();
            frm.ShowDialog(this);
            this.WeatherLoad();
            
        }
        private void getCityFromIP()
        {
            try
            {
                //由网络应用获取本机IP地址的字符串
                String ipStr = getIP();
                //根据ip地址由webService获取到所在城市
                String cityStr = getCityStr(ipStr);
                //解析城市字符串
                String cityName = GetCityName(cityStr);
                //将值赋予this.city
                this.city = cityName;
                //load一下
                this.WeatherLoad();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //由网络应用获取本机IP地址的字符串
        public string getIP()
        {
            string strUrl = "http://1212.ip138.com/ic.asp"; //获得IP的网址了
            Uri uri = new Uri(strUrl);
            System.Net.WebRequest wr = System.Net.WebRequest.Create(uri);
            System.IO.Stream s = wr.GetResponse().GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(s, System.Text.Encoding.Default);
            string all = sr.ReadToEnd(); //读取网站的数据
            Match match;
            string pattern = "(\\d+)\\.(\\d+)\\.(\\d+)\\.(\\d+)";
            match = Regex.Match(all, pattern, RegexOptions.IgnoreCase);
            return match.ToString();    
        }
        /*
         * 根据ip地址由webService获取到所在城市
         * **/
        public string getCityStr(string ipStr)
        {
            cn.com.webxml.www_IP.IpAddressSearchWebService iCityName = new cn.com.webxml.www_IP.IpAddressSearchWebService();
            string[] str = iCityName.getCountryCityByIp(ipStr);
            return str[1];
        }
        /*
         * 解析城市字符串**/
        public string GetCityName(string address)
        {
            string setCity = "";
            int strate = 0;
            int end = 0;
            try
            {
                if (address.StartsWith("北") || address.StartsWith("上") || address.StartsWith("重") || address.StartsWith("天"))
                {
                    setCity = address.Substring(0, address.IndexOf("市"));
                }
                else if (address.StartsWith("香"))
                {
                    setCity = address.Substring(0, address.IndexOf("港") + 1);
                }
                else if (address.StartsWith("澳"))
                {
                    setCity = address.Substring(0, address.IndexOf("门") + 1);
                }
                else if (address.StartsWith("广西") || address.StartsWith("西藏") || address.StartsWith("新疆") || address.StartsWith("宁夏") || address.StartsWith("内蒙古"))
                {
                    strate = address.IndexOf("自治区");
                    end = address.IndexOf("市");
                    int cout = end - strate;
                    setCity = address.Substring(address.IndexOf("自治区") + 3, cout - 3);

                }
                else
                {
                    strate = address.IndexOf("省");
                    end = address.IndexOf("市");
                    int cout = end - strate;
                    setCity = address.Substring(address.IndexOf("省") + 1, cout - 1);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return setCity;
        }
    }
}
