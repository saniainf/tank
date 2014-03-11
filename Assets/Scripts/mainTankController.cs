using UnityEngine;
using System.Collections;

public class mainTankController : MonoBehaviour
{
    public float speed;
    public Sprite[] sprites;

    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHTS
    }

    enum Axis
    {
        HORIZONTAL,
        VERTICAL
    }

    private gameBoardManager gameBoard;
    private SpriteRenderer spriteRenderer;
    private float vectorVertical, vectorHorizontal;
    private Axis axis = Axis.HORIZONTAL;
    private Axis previousAxis = Axis.VERTICAL;
    private Direction direction = Direction.UP;
    private Direction previousDirection = Direction.UP;
    private Vector2 positionRound = new Vector2();

    void Awake()
    {
        gameBoard = GameObject.Find("gameBoard").GetComponent<gameBoardManager>();
        spriteRenderer = renderer as SpriteRenderer;
    }

    void Start()
    {

    }

    void Update()
    {
        keyController();
        tankCollision();
    }

    private void tankCollision()
    {
        Vector2 pointLeft = new Vector2();
        Vector2 pointRight = new Vector2(); 

        if (direction == Direction.UP)
        {
            pointLeft.x = transform.position.x - 0.16f;
            pointLeft.y = transform.position.y + 0.32f;
            pointRight.x = transform.position.x + 0.16f;
            pointRight.y = transform.position.y + 0.32f;
        }

        if (direction == Direction.DOWN)
        {
            pointLeft.x = transform.position.x + 0.16f;
            pointLeft.y = transform.position.y - 0.32f;
            pointRight.x = transform.position.x - 0.16f;
            pointRight.y = transform.position.y - 0.32f;
        }

        if (direction == Direction.LEFT)
        {
            pointLeft.x = transform.position.x - 0.32f;
            pointLeft.y = transform.position.y - 0.16f;
            pointRight.x = transform.position.x - 0.32f;
            pointRight.y = transform.position.y + 0.16f;
        }

        if (direction == Direction.RIGHTS)
        {
            pointLeft.x = transform.position.x + 0.32f;
            pointLeft.y = transform.position.y + 0.16f;
            pointRight.x = transform.position.x + 0.32f;
            pointRight.y = transform.position.y - 0.16f;
        }

        int il = (int)(pointLeft.x / 0.32f);
        int jl = (int)(pointLeft.y / 0.32f);
        int ir = (int)(pointRight.x / 0.32f);
        int jr = (int)(pointRight.y / 0.32f);

        if (gameBoard.getTypeBricks(il, jl) || gameBoard.getTypeBricks(ir, jr))
        {
            SnapGrid();
            Debug.Log("snap");
        }
    }

    private void keyController()
    {
        vectorVertical = Input.GetAxisRaw("Vertical") * speed;
        vectorHorizontal = Input.GetAxisRaw("Horizontal") * speed;

        if (vectorVertical != 0)
        {
            axis = Axis.VERTICAL;
            if (vectorVertical < 0)
            {
                direction = Direction.DOWN;
                spriteRenderer.sprite = sprites[1];
            }
            else
            {
                direction = Direction.UP;
                spriteRenderer.sprite = sprites[0];
            }
            vectorVertical *= Time.deltaTime;
            transform.Translate(0, vectorVertical, 0);
        }
        else if (vectorHorizontal != 0)
        {
            axis = Axis.HORIZONTAL;
            if (vectorHorizontal < 0)
            {
                direction = Direction.LEFT;
                spriteRenderer.sprite = sprites[2];
            }
            else
            {
                direction = Direction.RIGHTS;
                spriteRenderer.sprite = sprites[3];
            }
            vectorHorizontal *= Time.deltaTime;
            transform.Translate(vectorHorizontal, 0, 0);
        }

        if (previousAxis != axis)
        {
            SnapGrid();
            previousAxis = axis;
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
