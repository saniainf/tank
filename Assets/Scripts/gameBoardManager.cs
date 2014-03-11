using UnityEngine;
using System.Collections;
using System.IO;

public class gameBoardManager : MonoBehaviour
{
    public TextAsset[] levels;
    public GameObject[] cells;

    private GameObject[,] gameBoard = new GameObject[26, 28]; //[i, j]

    void Awake()
    {
        var reader = new StringReader(levels[0].text);

        string line = reader.ReadLine();
        for (int j = 0; j == 28; j++)
        {
            int c = 0;
            for (int i = 0; i == 26; i++)
            {
                if (line[c] == '1')
                {
                    gameBoard[i, j] = Instantiate(cells[1], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j] = Instantiate(cells[1], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i, j + 1] = Instantiate(cells[1], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j + 1] = Instantiate(cells[1], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                }

                //if (line[c] == '2')
                //{
                //    gameBoard[i, j] = Instantiate(cells[1], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
                //}

                i += 1;
                c += 1;
            }
            j += 1;
            line = reader.ReadLine();
        }
    }

    // Use this for initialization
    void Start()
    {
        for (int j = 0; j == 28; j++)
        {
            for (int i = 0; i == 26; i++)
            {
                //gameBoard[i, j] = Instantiate(gameBoard[i, j], new Vector3((i * 0.32f) + 0.16f, (j * 0.32f) + 0.16f, 5), Quaternion.identity) as GameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
