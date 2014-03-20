using UnityEngine;
using System.Collections;

public class cellController : MonoBehaviour
{

    public bool collision;
    public bool solid;
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int cellUnit = 15;

    /* cell
     * 
     * 01
     * 23
     * 
     * 0000 0
     * 0001 1
     * 0010 2
     * 0011 3
     * 0100 4
     * 0101 5
     * 0110 6
     * 0111 7
     * 1000 8
     * 1001 9
     * 1010 10
     * 1011 11
     * 1100 12
     * 1101 13
     * 1110 14
     * 1111 15
     * 
     */

    void Awake()
    {
        spriteRenderer = renderer as SpriteRenderer;
    }

    // Use this for initialization
    void Start()
    {
        //int b = 15;

        //b |= 1 << 0; //Принудительно включаем бит номер 0
        //Debug.Log(b);

        //b &= ~(1 << 3); //Принудительно выключаем бит номер 3
        //Debug.Log(b);

        //if ((b & 1 << 2) == 1)
        //{
        //    //Бит с номером 2 установлен
        //}
        //else
        //{
        //    //Бит не установлен
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool hitCell(int direction, bool leftHelper)
    {
        if (!solid)
        {
            switch (direction)
            {
                case 0:
                    if (leftHelper)
                    {
                        if ((cellUnit & 1 << 3) != 0)
                        {
                            cellUnit &= ~(1 << 2);
                            cellUnit &= ~(1 << 3);
                            refreshCell();
                            return true;
                        }
                    }
                    else
                    {
                        if ((cellUnit & 1 << 2) != 0)
                        {
                            cellUnit &= ~(1 << 2);
                            cellUnit &= ~(1 << 3);
                            refreshCell();
                            return true;
                        }
                    }
                    return false;

                case 180:
                    if (leftHelper)
                    {
                        if ((cellUnit & 1 << 0) != 0)
                        {
                            cellUnit &= ~(1 << 0);
                            cellUnit &= ~(1 << 1);
                            refreshCell();
                            return true;
                        }
                    }
                    else
                    {
                        if ((cellUnit & 1 << 1) != 0)
                        {
                            cellUnit &= ~(1 << 1);
                            cellUnit &= ~(1 << 0);
                            refreshCell();
                            return true;
                        }
                    }
                    return false;

                case 90:
                    if (leftHelper)
                    {
                        if ((cellUnit & 1 << 1) != 0)
                        {
                            cellUnit &= ~(1 << 1);
                            cellUnit &= ~(1 << 3);
                            refreshCell();
                            return true;
                        }
                    }
                    else
                    {
                        if ((cellUnit & 1 << 3) != 0)
                        {
                            cellUnit &= ~(1 << 3);
                            cellUnit &= ~(1 << 1);
                            refreshCell();
                            return true;
                        }
                    }
                    return false;

                case 270:
                    if (leftHelper)
                    {
                        if ((cellUnit & 1 << 2) != 0)
                        {
                            cellUnit &= ~(1 << 2);
                            cellUnit &= ~(1 << 0);
                            refreshCell();
                            return true;
                        }
                    }
                    else
                    {
                        if ((cellUnit & 1 << 0) != 0)
                        {
                            cellUnit &= ~(1 << 0);
                            cellUnit &= ~(1 << 2);
                            refreshCell();
                            return true;
                        }
                    }
                    return false;

                default:
                    return false;
            }
        }
        return true;
    }

    public bool hitCell2(int direction, bool leftHelper)
    {
        if (!solid)
        {
            switch (direction)
            {
                case 0:
                    if (leftHelper)
                    {
                        if ((cellUnit & 1 << 1) != 0)
                        {
                            cellUnit &= ~(1 << 0);
                            cellUnit &= ~(1 << 1);
                            refreshCell();
                            return true;
                        }
                    }
                    else
                    {
                        if ((cellUnit & 1 << 0) != 0)
                        {
                            cellUnit &= ~(1 << 0);
                            cellUnit &= ~(1 << 1);
                            refreshCell();
                            return true;
                        }
                    }
                    return false;

                case 180:
                    if (leftHelper)
                    {
                        if ((cellUnit & 1 << 2) != 0)
                        {
                            cellUnit &= ~(1 << 2);
                            cellUnit &= ~(1 << 3);
                            refreshCell();
                            return true;
                        }
                    }
                    else
                    {
                        if ((cellUnit & 1 << 3) != 0)
                        {
                            cellUnit &= ~(1 << 3);
                            cellUnit &= ~(1 << 2);
                            refreshCell();
                            return true;
                        }
                    }
                    return false;

                case 90:
                    if (leftHelper)
                    {
                        if ((cellUnit & 1 << 0) != 0)
                        {
                            cellUnit &= ~(1 << 0);
                            cellUnit &= ~(1 << 2);
                            refreshCell();
                            return true;
                        }
                    }
                    else
                    {
                        if ((cellUnit & 1 << 2) != 0)
                        {
                            cellUnit &= ~(1 << 2);
                            cellUnit &= ~(1 << 0);
                            refreshCell();
                            return true;
                        }
                    }
                    return false;

                case 270:
                    if (leftHelper)
                    {
                        if ((cellUnit & 1 << 3) != 0)
                        {
                            cellUnit &= ~(1 << 3);
                            cellUnit &= ~(1 << 1);
                            refreshCell();
                            return true;
                        }
                    }
                    else
                    {
                        if ((cellUnit & 1 << 1) != 0)
                        {
                            cellUnit &= ~(1 << 1);
                            cellUnit &= ~(1 << 3);
                            refreshCell();
                            return true;
                        }
                    }
                    return false;

                default:
                    return false;
            }
        }
        return true;
    }

    private void refreshCell()
    {
        if (cellUnit == 0)
            Destroy(gameObject);
        spriteRenderer.sprite = sprites[cellUnit];
    }
}
