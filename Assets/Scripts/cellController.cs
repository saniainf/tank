using UnityEngine;
using System.Collections;

public class cellController : MonoBehaviour
{

    public bool collision;
    public bool solid;
    public Sprite[] sprites;

    private int live = 1;
    private SpriteRenderer spriteRenderer;
    public char[] cellUnit = new char[] { '1', '0', '0', '1' };

    void Awake()
    {
        spriteRenderer = renderer as SpriteRenderer;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitCell(int direction)
    {
        if (live > 0)
        {
            live--;
            switch (direction)
            {
                case 0:
                    spriteRenderer.sprite = sprites[2];
                    break;

                case 180:
                    spriteRenderer.sprite = sprites[1];
                    break;

                case 90:
                    spriteRenderer.sprite = sprites[4];
                    break;

                case 270:
                    spriteRenderer.sprite = sprites[3];
                    break;
            }
        }
        else
        {
            if (!solid)
                Destroy(gameObject);
        }
    }

    private void refreshCell()
    {
        //switch(new string (testString))
        //{
        //    case "0011":
        //        break;
        //}

        //if (cellUnit[0] && cellUnit[1] && cellUnit[2] && cellUnit[3])
    }
}
