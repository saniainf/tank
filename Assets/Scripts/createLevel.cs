using UnityEngine;
using System.Collections;
using System.IO;

public class createLevel : MonoBehaviour
{

    public TextAsset leveldata;


    // Use this for initialization
    void Start()
    {
        var reader = new StringReader(leveldata.text);

        string line = reader.ReadLine();

        while (line != null)
        {
            Debug.Log(line);
            line = reader.ReadLine();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
