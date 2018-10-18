using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrase
{
    public string term;
    public float occurrences;
}

public class FormWordCloud : MonoBehaviour
{
    public GameObject childObject;
    public float size = 10.0f;
    private List<Phrase> phrases;
    private float totalOccurances = 0.0f;
    private List<Phrase> randomisedPhrases;


    public TextAsset csv; //csv you're reading from, do not change 
    public string[,] words; //a 2d string array of all of the data from the csv
    
    void OnEnable()
    {
        phrases = new List<Phrase>();
        randomisedPhrases = new List<Phrase>();
        words = TabReader.SplitCsvGrid(csv.text);
        ProcessWords();
        Sphere();
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;

        // Tell each of the objects to look at the camera
        foreach (Transform child in transform)
        {
            child.LookAt(camera.position);
            child.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void Sphere()
    {
        float points = phrases.Count;
        float increment = Mathf.PI * (3 - Mathf.Sqrt(5));
        float offset = 2 / points;
        for (int i = 0; i < points; i++)
        {
            float y = i * offset - 1 + (offset / 2);
            float radius = Mathf.Sqrt(1 - y * y);
            float angle = i * increment;
            Vector3 pos = new Vector3((Mathf.Cos(angle) * radius * size), y * size, Mathf.Sin(angle) * radius * size);

            // Create the object as a child of the sphere
            GameObject child = Instantiate(childObject, pos, Quaternion.identity) as GameObject;
            child.transform.parent = transform;
            TextMesh phraseText = child.transform.GetComponent<TextMesh>();

            Phrase phrase = randomisedPhrases[(int)i];
            phraseText.text = phrase.term;

            float scale = (phrase.occurrences / 10.0f);
            child.transform.localScale += new Vector3(scale, scale, scale);
            
        }
    }

    private void ProcessWords()
    {
        for (int i = 0; i < words.GetLength(1) - 1; i++) {
            Debug.Log(words[0, i] + ", " + words[1, i]);
                Phrase phrase = new Phrase();
                phrase.term = words[0, i];
                phrase.occurrences = float.Parse(words[1, i]);
                phrases.Add(phrase);
                totalOccurances += phrase.occurrences;
            
        }

        System.Random random = new System.Random();
        randomisedPhrases.Clear();

        for (int i = 0; i < phrases.Count; i++)
        {
            randomisedPhrases.Add(phrases[i]);
        }

        for (int i = 0; i < randomisedPhrases.Count; i++)
        {
            int first = i;
            int second = random.Next(0, randomisedPhrases.Count);
            Phrase temp = randomisedPhrases[second];
            randomisedPhrases[second] = randomisedPhrases[first];
            randomisedPhrases[first] = temp;
        }

    }
}
