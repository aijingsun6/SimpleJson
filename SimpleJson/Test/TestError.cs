using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace SimpleJson.Test
{
    class TestError
    {
        [Test]
        public void TestStringValue()
        {

            string json = "{\"name1\":value}";
            JsonNode node = JsonNode.FromJson(json);
        }
        [Test]
        public void TestNumber()
        {
            string json = "[234a]";

            JsonNode node = JsonNode.FromJson(json);
        }

        [Test]
        public void TestName()
        {
            string json = "{name1:\"value\"}";
            JsonNode node = JsonNode.FromJson(json);
        }
        [Test]
        public void TestNoEnd()
        {
            string json = "{\"name1\":{}";
            JsonNode node = JsonNode.FromJson(json);
        }
        [Test]
        public void TestEnded()
        {
            string json = "{\"name1\":{}}}";
            JsonNode node = JsonNode.FromJson(json);
        }
        [Test]
        public void TestMissPuc()
        {
            string json = "{\"name1\":123\"name2\":{}}";
            JsonNode node = JsonNode.FromJson(json);

        }
        [Test]
        public void TestMissPuc2()
        {
            string json = "[{}{}]";
            JsonNode node = JsonNode.FromJson(json);

        }
      
    }
}
