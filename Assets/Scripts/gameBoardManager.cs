using UnityEngine;
using System.Collections;
using System.IO;

public class gameBoardManager : MonoBehaviour
{
    const int gameBoardCellsHight = 26;
    const int gameBoardCellsWidth = 26;
    const float cellHeight = 0.32f;
    const float cellWidth = 0.32f;
    const float cellHalfHeight = cellHeight / 2.0f;
    const float cellHalfWidth = cellWidth / 2.0f;
    const float gameBoardHeight = cellHeight * gameBoardCellsHight;
    const float gameBoardWidth = cellWidth * gameBoardCellsWidth;

    private GameObject[,] gameBoard = new GameObject[gameBoardCellsWidth, gameBoardCellsHight]; //[i, j]

    public int _gameBoardCellsHight { get { return gameBoardCellsHight; } }
    public int _gameBoardCellsWidth { get { return gameBoardCellsWidth; } }
    public float _cellHeight { get { return cellHeight; } }
    public float _cellWidth { get { return cellWidth; } }
    public float _cellHalfHeight { get { return cellHalfHeight; } }
    public float _cellHalfWidth { get { return cellHalfWidth; } }
    public float _gameBoardHeight { get { return gameBoardHeight; } }
    public float _gameBoardWidth { get { return gameBoardWidth; } }

    public TextAsset[] levels;
    public GameObject[] cells;

    /*
     * . null
     * # brick
     * a brick half left
     * d brick half right
     * w brick half top
     * s brick half bottom
     * @ stone
     * f stone half left
     * h stone half right
     * t stone half top
     * g stone half bottom
     * W water
     * G tree
     * I ice
     */



    // Use this for initialization
    void Awake()
    {
        var reader = new StringReader(levels[0].text);
        GameObject nextCell = null;

        string line = reader.ReadLine();
        for (int j = 0; j < gameBoardCellsHight; j += 2)
        {
            for (int i = 0, c = 0; i < gameBoardCellsWidth; i += 2, c++)
            {
                switch (line[c])
                {
                    case '#':
                        nextCell = cells[0];
                        break;

                    case '@':
                        nextCell = cells[1];
                        break;

                    case '.':
                        nextCell = null;
                        break;
                }

                if (nextCell != null)
                {
                    gameBoard[i, j] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    gameBoard[i, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
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

    }

    public GameObject _getTypeBricks(float x, float y)
    {
        if (x > 0 && x < gameBoardWidth && y > 0 && y < gameBoardHeight)
        {
            return gameBoard[(int)(x / cellWidth), (int)(y / cellHeight)];
        }
        return null;
    }
}
