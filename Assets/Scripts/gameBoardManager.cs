using UnityEngine;
using System.Collections;
using System.IO;

public class gameBoardManager : MonoBehaviour
{
    public TextAsset[] levels;
    public GameObject[] cells;

    private GameObject[,] gameBoard = new GameObject[26, 28]; //[i, j]

    // Use this for initialization
    void Awake()
    {
        var reader = new StringReader(levels[0].text);

        string line = reader.ReadLine();
        for (int j = 0; j < 28; j += 2)
        {
            for (int i = 0, c = 0; i < 26; i += 2, c++)
            {
                if (line[c] == '1')
                {
                    gameBoard[i, j] = Instantiate(cells[0], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j] = Instantiate(cells[0], new Vector3((i * 0.32f + 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i, j + 1] = Instantiate(cells[0], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f + 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j + 1] = Instantiate(cells[0], new Vector3((i * 0.32f + 0.32f) + 0.16f, (j * 0.32f + 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                }

                if (line[c] == '2')
                {
                    gameBoard[i, j] = Instantiate(cells[1], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j] = Instantiate(cells[1], new Vector3((i * 0.32f + 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i, j + 1] = Instantiate(cells[1], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f + 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j + 1] = Instantiate(cells[1], new Vector3((i * 0.32f + 0.32f) + 0.16f, (j * 0.32f + 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                }
            }
            line = reader.ReadLine();
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //gameBoard[0, 0].transform.Translate(new Vector3(0.01f, 0.01f));
    }

    public GameObject getTypeBricks(int i, int j)
    {
        if (i >= 0 && j >= 0)
            return gameBoard[i, j];
        else return null;
    }
}
