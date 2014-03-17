using UnityEngine;
using System.Collections;

public class cellController : MonoBehaviour
{

    public bool collision;
    public bool solid;
    private int live = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hitCell()
    {
        if (live > 0)
        {
            live--;
        }
        else
        {
            if (!solid)
                Destroy(gameObject);
        }
    }
}
