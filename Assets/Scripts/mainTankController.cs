using UnityEngine;
using System.Collections;

public class mainTankController : MonoBehaviour
{
    enum Direction { UP, DOWN, LEFT, RIGHTS }
    enum Axis { HORIZONTAL, VERTICAL }

    private gameBoardManager gameBoard;
    private SpriteRenderer spriteRenderer;
    private float vectorVertical, vectorHorizontal;
    private Axis axis = Axis.HORIZONTAL;
    private Axis previousAxis = Axis.VERTICAL;
    private Direction direction = Direction.UP;
    private Vector2 positionRound = new Vector2();

    public float speed;
    public Sprite[] sprites;

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

        switch (direction)
        {
            case Direction.UP:
                pointLeft.x = transform.position.x - gameBoard._cellHalfWidth;
                pointLeft.y = transform.position.y + gameBoard._cellHeight;
                pointRight.x = transform.position.x + gameBoard._cellHalfWidth;
                pointRight.y = transform.position.y + gameBoard._cellHeight;
                break;

            case Direction.DOWN:
                pointLeft.x = transform.position.x + gameBoard._cellHalfWidth;
                pointLeft.y = transform.position.y - gameBoard._cellHeight;
                pointRight.x = transform.position.x - gameBoard._cellHalfWidth;
                pointRight.y = transform.position.y - gameBoard._cellHeight;
                break;

            case Direction.LEFT:
                pointLeft.x = transform.position.x - gameBoard._cellWidth;
                pointLeft.y = transform.position.y - gameBoard._cellHalfHeight;
                pointRight.x = transform.position.x - gameBoard._cellWidth;
                pointRight.y = transform.position.y + gameBoard._cellHalfHeight;
                break;

            case Direction.RIGHTS:
                pointLeft.x = transform.position.x + gameBoard._cellWidth;
                pointLeft.y = transform.position.y + gameBoard._cellHalfHeight;
                pointRight.x = transform.position.x + gameBoard._cellWidth;
                pointRight.y = transform.position.y - gameBoard._cellHalfHeight;
                break;
        }

        if (gameBoard._getTypeBricks(pointLeft.x, pointLeft.y) || gameBoard._getTypeBricks(pointRight.x, pointRight.y))
        {
            SnapGrid();
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
        float roundX = (float)System.Math.Round((transform.position.x) / (gameBoard._cellWidth)) * (gameBoard._cellWidth);
        float roundY = (float)System.Math.Round((transform.position.y) / (gameBoard._cellHeight)) * (gameBoard._cellHeight);
        transform.position = new Vector2(roundX, roundY);
    }

    void Round()
    {
        positionRound.x = ((float)System.Math.Round(transform.position.x, 2));
        positionRound.y = ((float)System.Math.Round(transform.position.y, 2));
        transform.position = positionRound;
    }
}
