using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour
{
    //public gameBoardManager gameBoard;
    public Transform helper;
    public Transform leftHelper;
    public Transform rightHelper;

    public enum TypeBullet { one, two, tree }
    public TypeBullet type;

    private GameObject goGameBoard;


    void Awake()
    {
        goGameBoard = GameObject.Find("gameBoard");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.08f, 0f);
        if (Input.GetButtonDown("Fire2"))
            Destroy(gameObject);

        bulletCollision();
    }

    private void bulletCollision()
    {
        var gameBoard = goGameBoard.GetComponent<gameBoardManager>();

        if (gameBoard._getCollisionCell(leftHelper.transform.position) || gameBoard._getCollisionCell(rightHelper.transform.position) ||
            leftHelper.transform.position.x < 0 || leftHelper.transform.position.x > gameBoard._gameBoardWidth ||
            leftHelper.transform.position.y < 0 || leftHelper.transform.position.y > gameBoard._gameBoardHeight)
        {
            if (gameBoard._getCollisionCell(rightHelper.transform.position))
            {
                gameBoard._destroyBricks(rightHelper.transform.position);
            }

            if (gameBoard._getCollisionCell(leftHelper.transform.position))
            {
                gameBoard._destroyBricks(leftHelper.transform.position);
            }
            Destroy(gameObject);
        }
    }
}
