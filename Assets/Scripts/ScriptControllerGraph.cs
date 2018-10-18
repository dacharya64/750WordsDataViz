using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptControllerGraph : MonoBehaviour {
    public TextAsset file1;
    public TextAsset file2;
    public TextAsset file3;
    public TextAsset file4;
    public TextAsset file5;
    public TextAsset file6;
    public TextAsset file7;
    public TextAsset file8;
    public TextAsset file9;
    public TextAsset file10;
    public TextAsset file11;
    public TextAsset file12;

    private GameObject[] dataPoints;
    private List<TextAsset> files;
    private int count;

    // Use this for initialization
    void Start () {
        count = 1;
        files = new List<TextAsset>();
        makeArrayOfFiles();
    }

     void makeArrayOfFiles()
    {
        files.Add(file1);
        files.Add(file2);
        files.Add(file3);
        files.Add(file4);
        files.Add(file5);
        files.Add(file6);
        files.Add(file7);
        files.Add(file8);
        files.Add(file9);
        files.Add(file10);
        files.Add(file11);
        files.Add(file12);
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space")) {
            
            // Only do this for 12 months / files
            if (count < 12) {
                dataPoints = GameObject.FindGameObjectsWithTag("DataPoint");
                
                foreach (GameObject dataPoint in dataPoints) {
                    Destroy(dataPoint);
                }

                // Rerun the script with new word counts
                GameObject.Find("GameController").GetComponent<ParseCSV>().enabled = false;
                GameObject.Find("GameController").GetComponent<ParseCSV>().csv = files[count];
                count++;
                GameObject.Find("GameController").GetComponent<ParseCSV>().enabled = true;
            }
        }

        // Close game on escape press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
