using UnityEngine;
using System.Collections;
using System.IO;

public class gameBoardManager : MonoBehaviour
{
    public enum Direction { UP, DOWN, LEFT, RIGHTS }

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
        bool cellHalf = false;

        string line = reader.ReadLine();
        for (int j = gameBoardCellsHight - 2; j >= 0; j -= 2)
        {
            for (int i = 0, c = 0; i < gameBoardCellsWidth; i += 2, c++)
            {
                switch (line[c])
                {
                    case '#':
                        nextCell = cells[0];
                        cellHalf = false;
                        break;

                    case 'a':
                    case 'd':
                    case 'w':
                    case 's':
                        nextCell = cells[0];
                        cellHalf = true;
                        break;

                    case '@':
                        nextCell = cells[1];
                        cellHalf = false;
                        break;

                    case 'f':
                    case 'h':
                    case 't':
                    case 'g':
                        nextCell = cells[1];
                        cellHalf = true;
                        break;

                    case 'W':
                        nextCell = null;
                        break;

                    case 'G':
                        nextCell = null;
                        break;

                    case 'I':
                        nextCell = null;
                        break;

                    case '.':
                        nextCell = null;
                        break;
                }

                //full cells
                if (nextCell != null && cellHalf == false)
                {
                    gameBoard[i, j] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    gameBoard[i, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    gameBoard[i + 1, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                }

                //half cells
                if (nextCell != null && cellHalf == true)
                {
                    if (line[c] == 'w' || line[c] == 't')
                    {
                        //gameBoard[i, j] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        //gameBoard[i + 1, j] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        gameBoard[i, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        gameBoard[i + 1, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    }
                    else if (line[c] == 's' || line[c] == 'g')
                    {
                        gameBoard[i, j] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        gameBoard[i + 1, j] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        //gameBoard[i, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        //gameBoard[i + 1, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    }
                    else if (line[c] == 'a' || line[c] == 'f')
                    {
                        gameBoard[i, j] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        //gameBoard[i + 1, j] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        gameBoard[i, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        //gameBoard[i + 1, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    }
                    else if (line[c] == 'd' || line[c] == 'h')
                    {
                        //gameBoard[i, j] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        gameBoard[i + 1, j] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        //gameBoard[i, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                        gameBoard[i + 1, j + 1] = Instantiate(nextCell, new Vector3((i * cellWidth + cellWidth) + cellHalfWidth, (j * cellHeight + cellHeight) + cellHalfHeight, 5), Quaternion.identity) as GameObject;
                    }
                }
            }
            line = reader.ReadLine();
        }
    }

    private void fillGameBoard()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool _getCollisionCell(Vector3 pos)
    {
        if (pos.x > 0 && pos.x < gameBoardWidth && pos.y > 0 && pos.y < gameBoardHeight)
        {
            if (gameBoard[(int)(pos.x / cellWidth), (int)(pos.y / cellHeight)])
            {
                cellController cellCollision = gameBoard[(int)(pos.x / cellWidth), (int)(pos.y / cellHeight)].GetComponent<cellController>();
                return cellCollision.collision;
            }
        }
        return false;
    }

    public void _destroyBricks(Vector3 pos)
    {
        if (pos.x > 0 && pos.x < gameBoardWidth && pos.y > 0 && pos.y < gameBoardHeight)
        {
            if (gameBoard[(int)(pos.x / cellWidth), (int)(pos.y / cellHeight)])
            {
                cellController cellCollision = gameBoard[(int)(pos.x / cellWidth), (int)(pos.y / cellHeight)].GetComponent<cellController>();
                cellCollision.hitCell();
            }
        }
    }
}
