using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPingGu.Models
{
    public class CarModels
    {
        //品牌ID
        public int brand_id { get; set; }
        //车系ID
        public int series_id { get; set; }
        //车型ID
        public int model_id { get; set; }
        //Year
        public int year { get; set; }
        //Month
        public int month { get; set; }
        //省份
        public int province { get; set; }
        //城市
        public int city { get; set; }
        public string city_full { get; set; }
        //里程
        public double kilometer { get; set; }
    }
}