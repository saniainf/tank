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
    private gameBoardManager gameBoard;


    void Awake()
    {
        goGameBoard = GameObject.Find("gameBoard");
        gameBoard = goGameBoard.GetComponent<gameBoardManager>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.1f, 0f); // need speed
        bulletCollision();
    }

    private void bulletCollision()
    {
        if (gameBoard._getCollisionCell(leftHelper.transform.position, rightHelper.transform.position, (int)transform.rotation.eulerAngles.z))
            Destroy(gameObject);

    }
}
