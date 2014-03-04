using UnityEngine;
using System.Collections;

public class camera2D : MonoBehaviour
{

    public float pixels2units = 100.0f;

    // Update is called once per frame
    void Update()
    {
        camera.orthographicSize = (Screen.height / pixels2units / 2.0f);
    }
}
