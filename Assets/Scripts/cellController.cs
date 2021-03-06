﻿using UnityEngine;
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool hitCellFirst(int direction, bool leftHelper)
    {
        if (!solid && collision)
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

    public bool hitCellSecond(int direction, bool leftHelper)
    {
        if (!solid && collision)
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
