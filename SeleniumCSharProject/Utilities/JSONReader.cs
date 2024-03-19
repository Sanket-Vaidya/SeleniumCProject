using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumFrameWork.Utilities
{
    public class JSONReader
    {
        public JSONReader() { }

        public string extractData(string tokenname)
        {
            string myJsonString = File.ReadAllText(@"D:\\TRAINING\\SeleniumCSharProject - prac\\SeleniumCSharProject\\TestData\\TestData.json");
            var JsonObject = JToken.Parse(myJsonString);

            string tokenValue = JsonObject.SelectToken(tokenname).Value<string>();
            return tokenValue;
        }

        public string [] extractDataArray(string tokenname)
        {
            string myJsonString = File.ReadAllText("utilities//testdata.json");
            var JsonObject = JToken.Parse(myJsonString);

            List<string> tokenValue = JsonObject.SelectTokens(tokenname).Values<string>().ToList();
            return tokenValue.ToArray();
        }
    }
}
