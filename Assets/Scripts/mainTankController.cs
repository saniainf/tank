using UnityEngine;
using System.Collections;

public class mainTankController : MonoBehaviour
{
    enum Direction { UP, DOWN, LEFT, RIGHTS }
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
    private Direction direction = Direction.UP;
    private Vector2 positionRound = new Vector2();
    private GameObject bullets;

    void Awake()
    {
        spriteRenderer = renderer as SpriteRenderer;
    }

    void Start()
    {

    }

    void Update()
    {
        keyController();
        tankCollision();

        if (Input.GetButtonDown("Fire1"))
        {
            if (!bullets)
            {
                bullets = Instantiate(bullet, transform.position, helper.transform.rotation) as GameObject;
                var bc = bullets.GetComponent<bulletController>();
                bc.type = bulletController.TypeBullet.one;
                //Debug.Log(bc);
            }
        }
    }

    private void tankCollision()
    {
        if (gameBoard._getTypeBricks(leftHelper.transform.position) ||
            gameBoard._getTypeBricks(rightHelper.transform.position) ||
            leftHelper.transform.position.x < 0 || leftHelper.transform.position.x > gameBoard._gameBoardWidth ||
            leftHelper.transform.position.y < 0 || leftHelper.transform.position.y > gameBoard._gameBoardHeight)
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
                helper.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                direction = Direction.UP;
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
                direction = Direction.LEFT;
                spriteRenderer.sprite = sprites[2];
                helper.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                direction = Direction.RIGHTS;
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
