using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.IO;

public class TestResultManager : MonoBehaviour {

    public static TestResultManager instance;
    private static List<TestResult> savingResult;
	private bool choice1;	// Here we need to make a list of bools for each of the choices... could maybe make it into an array to make coding easier, I (Steffen) can work on it when we get that far into the project

    void Awake(){
        instance = this;	// Not sure what this do... wakes up the script???
    }

	void Start () 
    {
        savingResult = new List<TestResult>();	// Creates a new list of test results
	}

	void Update () 
    {
        
	}
	
    public static void SaveResult()
    {
		TestResult Data = new TestResult();	// A new set of "TestResults" (See its script) called "Data"
		for (int i = 0; i < 6; i++){
			if(Choices.GetTimerRanOut(i) == false){	// If the test participant was able to answer on time then:
				if(Choices.GetChoice(i+1) == true)
					Data.choice[i] = "Rational";	// Insets the data from the test into the "Data"set
				else if(Choices.GetChoice(i+1) == false)
					Data.choice[i] = "Emotional";
			}
			else
				Data.choice[i] = "No answer";
		}
		savingResult.Add(Data);					// Adds the data into a "savingResult" variable which is used again a few lines below

        TestResultData trd = new TestResultData();		// Creates a new instance of "TestResultData" to a "trd" variable
        trd.testDataList = savingResult;				// Saves the final results into the data list (see "testResultData" script)


        System.IO.Directory.CreateDirectory(Application.dataPath + "/../FinalTestData/");	// Creates a "FinalTestData" folder inside next to where the game is saved
        var serializer = new XmlSerializer(typeof(TestResultData));							// Creates a new instance of a serializer for the objects of datatype "TestResultData"

		var stream = new FileStream(Application.dataPath + "/../FinalTestData" + "/Result" + TestStart.GetTestNumber() + ".xml", FileMode.Create); // Crates and opens a XML file with the name of "Result(the TestNumber input).xml"
        serializer.Serialize(stream, trd);	// Writes the data collected (trd) into the xml document
        stream.Close();						// Closes the xml document
    }
}
