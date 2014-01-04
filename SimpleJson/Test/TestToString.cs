using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SimpleJson.Test
{
    class TestToString
    {
        [Test]
        public void TestSimpleObj()
        {

            JsonNode root = new JsonNode(NodeType.Object);

            JsonNode subNode = 123;

            root.AddSubNode("name1",subNode);

            subNode = true;
            root.AddSubNode("name2", subNode);

            subNode = false;
            root.AddSubNode("name3", subNode);

            subNode = "hello world.";
            root.AddSubNode("name4", subNode);

            subNode = null;
            root.AddSubNode("name5", subNode);
            subNode = 1.23;
            root.AddSubNode("name6", subNode);

            string json = root.ToJson();
            Assert.AreEqual("{\"name1\":123,\"name2\":true,\"name3\":false,\"name4\":\"hello world.\",\"name5\":null,\"name6\":1.23}",json);


           

        }
        [Test]
        public void TestSimpleArray()
        {
            JsonNode root = new JsonNode(NodeType.Array);

            JsonNode subNode = 123;
            root.AddNode(subNode);
            
            subNode = true;
            root.AddNode(subNode);


            subNode = "hello world.";
            root.AddNode(subNode);

            subNode = null;
            root.AddNode(subNode);

            subNode = 1.234;
            root.AddNode(subNode);

            string json = root.ToJson();

            Assert.AreEqual("[123,true,\"hello world.\",null,1.234]", json);

        }





    }
}
