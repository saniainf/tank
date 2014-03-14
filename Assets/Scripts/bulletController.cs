using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour
{
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
        if (Input.GetButtonDown("Fire2"))
            Destroy(gameObject);
    }

    public void tstpub(int a)
    {

    }
}
