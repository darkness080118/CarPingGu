using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPingGu.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.IO;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Wesalt.Basis.Tools;

namespace CarPingGu.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }
        //获取评估结果
        public ActionResult GetResult(CarModels car)
        {
            HttpClient httpClient = new HttpClient();
            //0=APP 1=PC;
            if (car.model_id == 0 || car.year ==0 || car.month ==0 || car.kilometer == 0 || car.city_full == null)
            {
                return View("Index");
            }
            int mode = 0;
            DateTime dataTime = new DateTime(car.year,car.month,1);
            
            if (dataTime > DateTime.Now)
            {
                return View("GetResultAPP_NoData");
            }

            //暂时不做Car数据过滤和检测

            string resultContent;

            //请求配置
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");

            switch (mode)
            {
                case 0:
                    {
                        httpClient.BaseAddress = new Uri("http://appserv.273.cn");
                        //APP          
                        var content = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("model_id", car.model_id.ToString()),
                            new KeyValuePair<string, string>("year", car.year.ToString()),
                            new KeyValuePair<string, string>("month", car.month.ToString()),
                            new KeyValuePair<string, string>("city", car.city.ToString()),
                            new KeyValuePair<string, string>("kilometer", (car.kilometer/10000).ToString()),
                        });
                        try
                        {
                            HttpResponseMessage response = httpClient.PostAsync("/1.3/priceevaluate.priceEvaluate", content).Result;
                            HttpRequestMessage request = response.RequestMessage;
                            HttpContent responseText = response.Content;
                            resultContent = response.Content.ReadAsStringAsync().Result;
                        }
                        catch (Exception e)
                        {
                            return Json("Error When Data Post");
                        }
                        dynamic jsonobj = JsonConvert.DeserializeObject(resultContent);
                        bool isEmpty = false;
                        CarPingGuJson carResult = new CarPingGuJson();
                        carResult.city = car.city_full;
                        carResult.year = car.year;
                        carResult.month = car.month;
                        int error_code = Convert.ToInt32(jsonobj.errorCode);
                        if (error_code == 1)
                        {
                            isEmpty = true;
                            return View("GetResultAPP_NoData");
                        }
                        carResult.head = jsonobj.data.head;
                        carResult.factory_price = Convert.ToDouble(jsonobj.data.factory_price);
                        carResult.factory_price_title = jsonobj.data.factory_price_title;
                        carResult.high_price = Convert.ToDouble(jsonobj.data.high_price);
                        carResult.kilometer = Convert.ToDouble(jsonobj.data.kilometer);
                        carResult.low_price = Convert.ToDouble(jsonobj.data.low_price);
                        carResult.price = Convert.ToDouble(jsonobj.data.price);
                        carResult.price_c = Convert.ToDouble(jsonobj.data.price_c);
                        carResult.type = jsonobj.data.type;
                        ViewBag.SimilarCar = getSimilarCars(car);
                        return View("GetResultAPP", carResult);
                    }

                case 1:
                    {
                        httpClient.BaseAddress = new Uri("http://pinggu.273.cn");
                        //Post数据写入
                        //PC
                        var content = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("brand_id", car.brand_id.ToString()),
                            new KeyValuePair<string, string>("series_id", car.series_id.ToString()),
                            new KeyValuePair<string, string>("model_id", car.model_id.ToString()),
                            new KeyValuePair<string, string>("year", car.year.ToString()),
                            new KeyValuePair<string, string>("month", car.month.ToString()),
                            new KeyValuePair<string, string>("province", car.province.ToString()),
                            new KeyValuePair<string, string>("city", car.city.ToString()),
                            new KeyValuePair<string, string>("kilometer", car.kilometer.ToString()),
                        });
                        //PC
                        //发送请求
                        HttpResponseMessage response = httpClient.PostAsync("/result.html", content).Result;
                        HttpRequestMessage request = response.RequestMessage;
                        HttpContent responseText = response.Content;
                        resultContent = response.Content.ReadAsStringAsync().Result;
                        //返回异常处理
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            return Json("Error", JsonRequestBehavior.AllowGet);
                        }
                        //返回页面分析
                        try
                        {
                            //返回页面分析
                            string resultDetails = resultContent;
                            string tempString;
                            int begin_Index;
                            int end_Index;
                            resultDetails = resultDetails.Substring(resultDetails.IndexOf("result-details") + 17);
                            CarPingGuModels test = new CarPingGuModels();

                            //首先分析是否有数据
                            if (resultDetails.Contains("您所填车源太过冷门"))
                            {
                                return View();
                            }

                            //车辆完整标题
                            tempString = resultDetails.Substring(resultDetails.IndexOf("car-info"));
                            begin_Index = tempString.IndexOf("<h2>");
                            end_Index = tempString.IndexOf("</h2>");
                            tempString = tempString.Substring(begin_Index + 4, end_Index - begin_Index - 4);
                            if (tempString.Length != 0)
                            {
                                test.CarTitle = tempString;
                            }
                            else
                            {
                                test.CarTitle = "未获取到数据，数据发生异常";
                            }


                            //第二行总信息提取
                            tempString = resultDetails.Substring(resultDetails.IndexOf("car-info"));
                            begin_Index = tempString.IndexOf("<p>");
                            end_Index = tempString.IndexOf("</p>");
                            string secInfomation = tempString.Substring(begin_Index + 3, end_Index - begin_Index - 3);

                            //上牌时间
                            tempString = secInfomation;
                            begin_Index = tempString.IndexOf("</em>");
                            end_Index = tempString.IndexOf("</span>");
                            tempString = tempString.Substring(begin_Index + 5, end_Index - begin_Index - 5);
                            if (tempString.Length != 0)
                            {
                                test.PublicTime = tempString;
                            }
                            else
                            {
                                test.PublicTime = "未获取到数据，数据发生异常";
                            }

                            //交易地点
                            tempString = secInfomation.Substring(secInfomation.IndexOf("交易地点"));
                            begin_Index = tempString.IndexOf("</em>");
                            end_Index = tempString.IndexOf("</span>");
                            tempString = tempString.Substring(begin_Index + 5, end_Index - begin_Index - 5);
                            if (tempString.Length != 0)
                            {
                                test.SaleLocation = tempString;
                            }
                            else
                            {
                                test.SaleLocation = "未获取到数据，数据发生异常";
                            }

                            //行驶里程
                            tempString = secInfomation.Substring(secInfomation.IndexOf("行驶里程"));
                            begin_Index = tempString.IndexOf("</em>");
                            end_Index = tempString.IndexOf("</span>");
                            tempString = tempString.Substring(begin_Index + 5, end_Index - begin_Index - 5 - 3);
                            if (tempString.Length != 0 && ValidateHelper.IsDouble(tempString))
                            {
                                test.MileAge = Convert.ToDouble(tempString);
                            }
                            else
                            {
                                test.MileAge = 0;
                            }


                            //第三行信息提取
                            tempString = resultDetails.Substring(resultDetails.IndexOf("pg-info"));
                            begin_Index = tempString.IndexOf("<p>");
                            end_Index = tempString.IndexOf("</div>");
                            string thrInfomation = tempString.Substring(begin_Index + 3, end_Index - begin_Index - 3);

                            //预计成交价
                            tempString = thrInfomation;
                            begin_Index = tempString.IndexOf("<b>");
                            end_Index = tempString.IndexOf("</b>");
                            tempString = tempString.Substring(begin_Index + 3, end_Index - begin_Index - 3);
                            if (tempString.Length != 0 && ValidateHelper.IsDouble(tempString))
                            {
                                test.ExpectedPrice = Convert.ToDouble(tempString);
                            }
                            else
                            {
                                test.ExpectedPrice = 0;
                            }

                            // 合理价格区间
                            tempString = thrInfomation.Substring(thrInfomation.IndexOf("合理价格区间"));
                            begin_Index = tempString.IndexOf("red-num");
                            end_Index = tempString.IndexOf("</span>");
                            tempString = tempString.Substring(begin_Index + 9, end_Index - begin_Index - 9);
                            if (tempString.Substring(0, tempString.IndexOf("-") - 2).Length != 0 && ValidateHelper.IsDouble(tempString.Substring(0, tempString.IndexOf("-") - 2)))
                            {
                                test.PriceRange_Down = Convert.ToDouble(tempString.Substring(0, tempString.IndexOf("-") - 2));
                            }
                            else
                            {
                                test.PriceRange_Down = 0;
                            }
                            if (tempString.Substring(tempString.IndexOf("-") + 1, tempString.IndexOf("万") - 1).Length != 0 && ValidateHelper.IsDouble(tempString.Substring(tempString.IndexOf("-") + 1, tempString.IndexOf("万") - 1)))
                            {
                                test.PriceRange_Up = Convert.ToDouble(tempString.Substring(tempString.IndexOf("-") + 1, tempString.IndexOf("万") - 1));
                            }
                            else
                            {
                                test.PriceRange_Up = 0;
                            }

                            //出厂报价
                            tempString = thrInfomation.Substring(thrInfomation.IndexOf("出厂报价"));
                            begin_Index = tempString.IndexOf("color-hei");
                            end_Index = tempString.IndexOf("</p>");
                            tempString = tempString.Substring(begin_Index + 11, end_Index - begin_Index - 11);
                            if (tempString.Substring(tempString.IndexOf("万") - 1).Length != 0 && ValidateHelper.IsDouble(tempString.Substring(0, tempString.IndexOf("万") - 1)))
                            {
                                test.FactoryPrice = Convert.ToDouble(tempString.Substring(0, tempString.IndexOf("万") - 1));
                            }
                            else
                            {
                                test.FactoryPrice = 0;
                            }
                            if (tempString.Substring(tempString.IndexOf("万") + 6, 5).Length != 0)
                            {
                                test.FactoryPrice_Year = tempString.Substring(tempString.IndexOf("万") + 6, 5);
                            }
                            else
                            {
                                test.FactoryPrice_Year = "未获取到数据，数据发生异常";
                            }

                            //数据量
                            tempString = resultDetails.Substring(resultDetails.IndexOf("车模型数据量是") + 11, 1);
                            if (tempString.Length != 0 && ValidateHelper.IsInt(tempString))
                            {
                                test.DataCount = Convert.ToUInt32(tempString);
                            }
                            else
                            {
                                test.DataCount = 0;
                            }
                            return View(test);
                        }
                        catch (Exception e)
                        {

                            return Json("Error", JsonRequestBehavior.AllowGet);
                        }

                        //return Json("Success", JsonRequestBehavior.AllowGet);
                    }
                default:
                    {
                        return HttpNotFound("配置错误-请检查配置信息");
                    }
            }
        }
        //相似车辆获取
        public JsonResult getSimilarCars(CarModels car)
        {
            HttpClient httpClient = new HttpClient();
            //0=APP 1=PC;
            int mode = 0;

            //暂时不做Car数据过滤和检测

            string resultContent;

            //请求配置
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36");
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");

            httpClient.BaseAddress = new Uri("http://appserv.273.cn");
            //APP          
            var content = new FormUrlEncodedContent(new[]
            {
                            new KeyValuePair<string, string>("model_id", car.model_id.ToString()),
                            new KeyValuePair<string, string>("year", car.year.ToString()),
                            new KeyValuePair<string, string>("month", car.month.ToString()),
                            new KeyValuePair<string, string>("city", car.city.ToString()),
                            new KeyValuePair<string, string>("kilometer", (car.kilometer/10000).ToString()),
                        });
            try
            {
                HttpResponseMessage response = httpClient.PostAsync("/1.3/priceevaluate.getSimilarCars", content).Result;
                HttpRequestMessage request = response.RequestMessage;
                HttpContent responseText = response.Content;
                resultContent = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return Json("Error When Data Post");
            }
            dynamic jsonobj = JsonConvert.DeserializeObject(resultContent);
            return Json(jsonobj);
            //return View("GetResultAPP", jsonobj.data);

        }
    }
}