using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPingGu.Models
{
    public class CarPingGuModels
    {
        //车辆完整标题
        public string CarTitle { get; set; }
        //上牌时间
        public string PublicTime { get; set; }
        //交易地点
        public string SaleLocation { get; set; }
        //行驶里程
        public double MileAge { get; set; }
        //预计成交价
        public double ExpectedPrice { get; set; }
        // 合理价格区间
        public double PriceRange_Down { get; set; }
        public double PriceRange_Up { get; set; }
        //出厂报价
        public double FactoryPrice { get; set; }
        //出厂报价年份
        public string FactoryPrice_Year { get; set; }
        //数据量
        public uint DataCount { get; set; }

    }

    public class CarPingGuJson
    {
        public double factory_price { get; set; }
        public string factory_price_title { get; set; }
        public string head { get; set; }
        public double high_price { get; set; }
        public double kilometer { get; set; }
        public double low_price { get; set; }
        public double price { get; set; }
        public double price_c { get; set; }
        public string type { get; set; }
        public string city { get; set; }
        public int year { get; set; }
        public int month { get; set; }
    }
}