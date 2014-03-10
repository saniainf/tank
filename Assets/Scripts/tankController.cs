using UnityEngine;
using System.Collections;

public class tankController : MonoBehaviour
{
    public float speed;
    public Sprite[] sprites;

    public int x;
    public int y;

    Vector2 positionRound = new Vector2();
    float vert, horiz;
    string direction = "Up";
    string prevDirection = "Up";
    string axis = "Horiz";
    string prevAxis = "Horiz";

    private SpriteRenderer spriteRenderer;

    createLevel gameBoard;

    void Awake()
    {
        gameBoard = GameObject.Find("background").GetComponent<createLevel>();
    }

    void Start()
    {
        spriteRenderer = renderer as SpriteRenderer;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            for (int j = gameBoard.walls.GetLength(1) - 1; j >= 0; j--)
            {
                for (int i = 0; i < gameBoard.walls.GetLength(0); i++)
                {
                    if (gameBoard.getTypeBricks(i, j) == null)
                        Debug.Log("0");
                    else if (gameBoard.getTypeBricks(i, j).tag == "wallBrick")
                        Debug.Log("1");
                    else if (gameBoard.getTypeBricks(i, j).tag == "wallSteel")
                        Debug.Log("2");
                    //Debug.Log(gameBoard.getTypeBricks(i, j));
                }
            }
        }
    }

    void Update()
    {
        vert = Input.GetAxisRaw("Vertical") * speed;
        horiz = Input.GetAxisRaw("Horizontal") * speed;

        if (vert != 0)
        {
            axis = "Vert";
            if (vert < 0)
            {
                direction = "Down";
                spriteRenderer.sprite = sprites[1];
            }
            else
            {
                direction = "Top";
                spriteRenderer.sprite = sprites[0];
            }
            vert *= Time.deltaTime;
            transform.Translate(0, vert, 0);
        }
        else if (horiz != 0)
        {
            axis = "Horiz";
            if (horiz < 0)
            {
                direction = "Left";
                spriteRenderer.sprite = sprites[2];
            }
            else
            {
                direction = "Right";
                spriteRenderer.sprite = sprites[3];
            }
            horiz *= Time.deltaTime;
            transform.Translate(horiz, 0, 0);
        }

        if (prevAxis != axis)
        {
            SnapGrid();
            prevAxis = axis;
        }

        Round();
    }

    void SnapGrid()
    {
        float roundX = (float)System.Math.Round((transform.position.x * 100) / 32) * 32;
        float roundY = (float)System.Math.Round((transform.position.y * 100) / 32) * 32;
        transform.position = new Vector2(roundX / 100, roundY / 100);
    }

    void Round()
    {
        positionRound.x = ((float)System.Math.Round(transform.position.x, 2));
        positionRound.y = ((float)System.Math.Round(transform.position.y, 2));
        transform.position = positionRound;
    }
}
