using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteEmployeeSearch();
            Console.ReadLine();
        }

        static void ExecuteEmployeeSearch()
        {
            string sampleJson = "{\"results\":[" +
                "{\"employeename\":\"name1\",\"employeesupervisor\":\"supervisor1\"}," +
                "{\"employeename\":\"name2\",\"employeesupervisor\":\"supervisor1\"}," +
                "{\"employeename\":\"name3\",\"employeesupervisor\":[\"supervisor1\",\"supervisor2\"]}" +
                "]}";

            JObject results = JObject.Parse(sampleJson);

            foreach (var result in results["results"])
            {
                string employeeName = (string)result["employeename"];

                JToken supervisor = result["employeeSupervisor"];

                string supervisorName = "";
                if (supervisor is JValue)
                {
                    supervisorName = (string)supervisor;
                }
                else if (supervisor is JArray)
                {
                    supervisorName = (string)((JArray)supervisor).First;
                }
                Console.WriteLine("Employee: {0}, Supervisor: {1}", employeeName, supervisorName);
            }

        }
    }
}
