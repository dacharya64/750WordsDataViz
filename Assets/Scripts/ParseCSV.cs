using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * takes the CSV of data and uses commands from CSVReader to split the data into arrays per row (trial)
 * then extracts the data out and saves them as variables
 * that can be called from other scripts
 */ 

public class ParseCSV : MonoBehaviour { 
    public TextAsset csv; //csv you're reading from, do not change 

    string[,] data; //a 2d string array of all of the data from the csv
    public GameObject dataPoint;
    public GameObject failDataPoint;
    public static Vector3 dataPointPosition;
  
    // Use this for initialization
    void OnEnable () {
        data = CSVReader.SplitCsvGrid(csv.text);
        for (int i = 0; i < data.GetLength(1); i++) {
            if (int.Parse(data[1, i]) >= 750)
            { // if the 750 words is met, put success data point
                dataPointPosition = new Vector3(int.Parse(data[0, i]) * 120, int.Parse(data[1, i]), 0);
                Instantiate(dataPoint, dataPointPosition, Quaternion.identity);
            }
            else { //put the fail data point
                dataPointPosition = new Vector3(int.Parse(data[0, i]) * 120, int.Parse(data[1, i]), 0);
                Instantiate(failDataPoint, dataPointPosition, Quaternion.identity);
            }
            
        }
    }
}