using UnityEngine;
using System.Collections;
using System.IO;

public class createLevel : MonoBehaviour
{

    public TextAsset leveldata;
    public GameObject wallBrick;
    public GameObject wallSteel;

    public GameObject[,] walls = new GameObject[13, 14]; //[i, j]

    // Use this for initialization
    void Start()
    {
        var reader = new StringReader(leveldata.text);

        string line = reader.ReadLine();

        for (int j = walls.GetLength(1) - 1; j >= 0; j--)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                if (line[i] == '1')
                    walls[i, j] = Instantiate(wallBrick, new Vector3((i * 0.64f) - 3.84f, (j * 0.64f) - 4.16f, 0), Quaternion.identity) as GameObject;

                if (line[i] == '2')
                    walls[i, j] = Instantiate(wallSteel, new Vector3((i * 0.64f) - 3.84f, (j * 0.64f) - 4.16f, 0), Quaternion.identity) as GameObject;
            }
            line = reader.ReadLine();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //walls[1, 7].transform.Translate(new Vector3(0.01f, 0.01f, 0));
    }
}
