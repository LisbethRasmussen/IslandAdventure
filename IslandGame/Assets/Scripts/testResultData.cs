using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Total Results")]
public class TestResultData
{
    //Holds the test results
    [XmlArray("Data List")]
    public List<TestResult> testDataList = new List<TestResult>();
}
