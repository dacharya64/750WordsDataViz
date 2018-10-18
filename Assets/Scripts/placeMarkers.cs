using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeMarkers : MonoBehaviour {
    int count;
    public GameObject marker;

    // Use this for initialization
    void Start () {
        count = 0;
        for (int i = 0; i < 40; i++) {
            Instantiate(marker, new Vector3(-100, count, 0), Quaternion.identity);
            count = count + 100;
        }
	}
}
