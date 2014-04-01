using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace SimpleJson.Test
{
    class TestTrade
    {
        public class Trade
        {
            /// <summary>
            /// 订单的状态
            /// </summary>
            public enum TradeState
            {
                /// <summary>
                /// 正在购买中。
                /// </summary>
                Purchasing = 1,
                /// <summary>
                /// 已经购买了，但是没有发货。
                /// </summary>
                Purchased = 2,
                /// <summary>
                /// 取消支付。
                /// </summary>
                Canceled = 3,
                /// <summary>
                /// 支付失败。
                /// </summary>
                Failed = 4,
                /// <summary>
                /// 彻底结束。
                /// </summary>
                Finished = 5

            }

            public string ProductId { get; set; }

            public string OutTradeNo { get; set; }

            public string TransactionId { get; set; }

            public string Receipt { get; set; }

            public TradeState State { get; set; }

            public Trade()
            {
                ProductId = "";

                OutTradeNo = "";

                TransactionId = "";

                Receipt = "";

                State = TradeState.Purchasing;

            }

            public void FromJson(string json)
            {
                try
                {
                    JsonNode root = JsonNode.FromJson(json);

                    JsonNode productIdNode = root["productId"];

                    if (productIdNode != null)
                    {
                        ProductId = productIdNode;
                    }

                    JsonNode outTradeNoNode = root["outTradeNo"];
                    if (outTradeNoNode != null)
                    {
                        OutTradeNo = outTradeNoNode;
                    }

                    JsonNode transactionIdNode = root["transactionId"];
                    if (transactionIdNode != null)
                    {
                        TransactionId = transactionIdNode;
                    }

                    JsonNode receiptNode = root["receipt"];

                    if (receiptNode != null)
                    {
                        Receipt = receiptNode;
                    }

                    JsonNode stateNode = root["state"];

                    if (stateNode != null)
                    {
                        State = (TradeState)(int)stateNode;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        
        [Test]
        public void Test1()
        {
            string json = "{\"outTradeNo\":\"\",\"productId\":\"com.morln.guandan.RMB_small_Yinpiao_1\",\"transactionId\":\"1000000105400355\",\"receipt\":\"ewoJInNpZ25hdHVyZSIgPSAiQXFHdXlyWENQSlpOWjAzQ2xnOTVkREgrbzc2VUZx\",\"state\":2}";

            Trade trade = new Trade();
            
            trade.FromJson(json);

            Assert.AreEqual("1000000105400355",trade.TransactionId);

        }
    }

   
}
