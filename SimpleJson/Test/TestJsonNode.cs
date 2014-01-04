using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
namespace SimpleJson.Test
{
    class TestJsonNode
    {
        [Test]
       public void TestParseSimpleObj()
        {
            string json = "{\"name1\":123,\"name2\":true,\"name3\":1.23,\"name4\":\"hello, world.\"}";

            JsonNode root = JsonNode.FromJson(json);

            Assert.AreEqual(123,root["name1"].Value);
            Assert.AreEqual(true,root["name2"].Value);
            Assert.AreEqual(1.23,root["name3"].Value);
            Assert.AreEqual("hello, world.",root["name4"].Value);
            

            JsonNode subNode = root["name1"];
            int intergerValue = subNode;
            Assert.AreEqual(123,intergerValue);

            subNode = root["name2"];
            bool bValue = subNode;
            Assert.AreEqual(true,bValue);

            subNode = root["name3"];
            double dValue = subNode;
            Assert.AreEqual(1.23, dValue);

            subNode = root["name4"];
            string stringValue = subNode;
            Assert.AreEqual("hello, world.", stringValue);






        }

        [Test]
        public void TestParseSimpleArray()
        {
            string json = "[  123,  true,  1.23,   \"hello, world.\"]";

            JsonNode root = JsonNode.FromJson(json);


            Assert.AreEqual(123, root[0].Value);
            Assert.AreEqual(true, root[1].Value);
            Assert.AreEqual(1.23, root[2].Value);
            Assert.AreEqual("hello, world.", root[3].Value);
            
        }


        /// <summary>
        /// obj 包含 obj
        /// </summary>
        [Test]
        public void TestObjEmbedObj()
        {
            string json = "{\"name1\":{\"name1\":123},\"name2\":{\"name1\":123,\"name2\":{\"name1\":123}}}";

            JsonNode root = JsonNode.FromJson(json);
            JsonNode subNode;
            JsonNode subSubNode;

            Assert.AreEqual(NodeType.Object,root.NodeType);
            Assert.AreEqual(2,root.SubNodesCount);
            subNode = root["name1"];
            
            Assert.AreEqual(NodeType.Object,subNode.NodeType);
            Assert.AreEqual(1,subNode.SubNodesCount);
            Assert.AreEqual(123,subNode["name1"].Value);

            subNode = root["name2"];
            Assert.AreEqual(NodeType.Object,subNode.NodeType);
            Assert.AreEqual(2,subNode.SubNodesCount);
            Assert.AreEqual(123,subNode["name1"].Value);

            subSubNode = subNode["name2"];
            Assert.AreEqual(NodeType.Object,subSubNode.NodeType);
            Assert.AreEqual(1,subSubNode.SubNodesCount);
            Assert.AreEqual(123,subSubNode["name1"].Value);
        }

        /// <summary>
        /// obj 包含 array
        /// </summary>
        [Test]
        public void TestObjEmbedArray()
        {

            string json = "{\"name1\":[123,\"hello\",false,null],\"name2\":[{\"name1\":\"value1\"},{\"name2\":\"value2\"}]}";


            JsonNode root = JsonNode.FromJson(json);
            Console.WriteLine(root.ToJson());
            JsonNode subNode;
            JsonNode subSubNode;
            
            
            Assert.AreEqual(NodeType.Object,root.NodeType);
            Assert.AreEqual(2,root.SubNodesCount);

            subNode = root["name1"];
            Console.WriteLine(subNode.ToJson());
            Assert.AreEqual(NodeType.Array,subNode.NodeType);
            Assert.AreEqual(4,subNode.ElementNodeCount);
            Assert.AreEqual(123,subNode[0].Value);
            Assert.AreEqual("hello",subNode[1].Value);
            Assert.AreEqual(false,subNode[2].Value);
            Assert.AreEqual(null,subNode[3].Value);

            subNode = root["name2"];
            Console.WriteLine(subNode.ToJson());
            Assert.AreEqual(NodeType.Array,subNode.NodeType);
            Assert.AreEqual(2,subNode.ElementNodeCount);
            subSubNode = subNode[0];
            Console.WriteLine(subSubNode.ToJson());
            Assert.AreEqual(NodeType.Object,subSubNode.NodeType);
            Assert.AreEqual("value1",subSubNode["name1"].Value);

            subSubNode = subNode[1];
            Console.WriteLine(subSubNode.ToJson());
            Assert.AreEqual(NodeType.Object, subSubNode.NodeType);
            Assert.AreEqual("value2",subSubNode["name2"].Value);

            
        }
        /// <summary>
        /// array 包含 obj
        /// </summary>
        [Test]
        public void TestArrayEmbedObj()
        {
            string json = "[ {\"name1\": \"value1\"} ,{\"name2\": \"value2\"},{\"name3\":\"\\\"\"}]";

            JsonNode root = JsonNode.FromJson(json);

            Console.WriteLine(root.ToJson());


            Assert.AreEqual("value1",root[0]["name1"].Value);
            Assert.AreEqual("value2",root[1]["name2"].Value);
            Assert.AreEqual("\\\"",root[2]["name3"].Value);

        }
        /// <summary>
        /// array 包含 array
        /// </summary>
        [Test]
        public void TestArrayEmbedArray()
        {
            string json = "[[123,true,false,\"hello,world.\"],[null,456,true,false,\"string value\"]]";


            JsonNode root = JsonNode.FromJson(json);
            Console.WriteLine(root.ToJson());

            Assert.AreEqual(123,root[0][0].Value);
            Assert.AreEqual(true,root[0][1].Value);
            Assert.AreEqual(false, root[0][2].Value);
            Assert.AreEqual("hello,world.", root[0][3].Value);


            Assert.AreEqual(null, root[1][0].Value);
            Assert.AreEqual(456, root[1][1].Value);
            Assert.AreEqual(true, root[1][2].Value);
            Assert.AreEqual(false, root[1][3].Value);
            Assert.AreEqual("string value", root[1][4].Value);
        }







    }
}
