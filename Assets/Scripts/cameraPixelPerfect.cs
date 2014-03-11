using UnityEngine;
using System.Collections;

public class cameraPixelPerfect : MonoBehaviour
{
    public float pixels2units = 100.0f;

    // Use this for initialization
    void Start()
    {
        camera.orthographicSize = (Screen.height / pixels2units / 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
