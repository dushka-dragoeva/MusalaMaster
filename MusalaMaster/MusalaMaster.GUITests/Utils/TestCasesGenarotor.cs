using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MusalaMaster.GUITests.Utils
{
    public class TestCasesGenarotor
    {
        public static IEnumerable GenerateSignInTestCases(string csvFileName)
        {
            var csvLines = File.ReadAllLines(csvFileName);

            var testCases = new List<TestCaseData>();

            foreach (var line in csvLines)
            {
                string[] values = line.Replace(" ", "").Split(',');

                string username= values[0];
                string password = values[1];


                testCases.Add(new TestCaseData(username, password));
            }

            return testCases;
        }
    }
}
