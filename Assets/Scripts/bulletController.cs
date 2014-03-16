using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour
{
    public gameBoardManager gameBoard;
    public Transform helper;
    public Transform leftHelper;
    public Transform rightHelper;

    public enum TypeBullet { one, two, tree }
    public TypeBullet type;

    void Awake()
    {

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
        if (gameBoard._getTypeBricks(leftHelper.transform.position) ||
            gameBoard._getTypeBricks(rightHelper.transform.position) ||
            leftHelper.transform.position.x < 0 || leftHelper.transform.position.x > gameBoard._gameBoardWidth ||
            leftHelper.transform.position.y < 0 || leftHelper.transform.position.y > gameBoard._gameBoardHeight)
        {
            Destroy(gameObject);
        }
    }
}
