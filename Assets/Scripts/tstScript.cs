using UnityEngine;
using System.Collections;

public class tstScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var value = Input.GetAxis("Horizontal");
        Debug.Log(value);
    }
}
