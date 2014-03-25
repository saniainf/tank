using UnityEngine;
using System.Collections;

public class enemyTankController : MonoBehaviour
{
    enum Axis { HORIZONTAL, VERTICAL }

    public gameBoardManager gameBoard;
    public Transform helper;
    public Transform leftHelper;
    public Transform rightHelper;
    public float speed;
    public GameObject bullet;
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private float vectorVertical, vectorHorizontal;
    private Axis axis = Axis.HORIZONTAL;
    private Axis previousAxis = Axis.VERTICAL;
    private Vector2 positionRound = new Vector2();
    private GameObject goBullets;
    private bulletController bullets;

    private int vertical = 0;
    private int horizontal = 0;

    void Awake()
    {
        spriteRenderer = renderer as SpriteRenderer;
    }

    // Use this for initialization
    void Start()
    {
        SnapGrid();
        vertical = 1;
    }

    // Update is called once per frame
    void Update()
    {
        aiTank();
        tankCollision();
    }

    private void changeDirection()
    {
        int i = 0;
        i = Random.Range(0, 4);
        switch (i)
        {
            case 0:
                vertical = 1;
                horizontal = 0;
                break;

            case 1:
                vertical = -1;
                horizontal = 0;
                break;

            case 2:
                vertical = 0;
                horizontal = 1;
                break;

            case 3:
                vertical = 0;
                horizontal = -1;
                break;
        }
    }

    private void aiTank()
    {
        vectorVertical = vertical * speed;
        vectorHorizontal = horizontal * speed;

        if (vectorVertical != 0)
        {
            axis = Axis.VERTICAL;
            if (vectorVertical < 0)
            {
                spriteRenderer.sprite = sprites[1];
                helper.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                spriteRenderer.sprite = sprites[0];
                helper.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            vectorVertical *= Time.deltaTime;
            transform.Translate(0, vectorVertical, 0);
        }
        else if (vectorHorizontal != 0)
        {
            axis = Axis.HORIZONTAL;
            if (vectorHorizontal < 0)
            {
                spriteRenderer.sprite = sprites[2];
                helper.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                spriteRenderer.sprite = sprites[3];
                helper.transform.rotation = Quaternion.Euler(0, 0, 270);
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

    private void tankCollision()
    {
        if (gameBoard._getCollisionCell(leftHelper.transform.position) ||
            gameBoard._getCollisionCell(rightHelper.transform.position))
        {
            changeDirection();
            SnapGrid();
        }
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
