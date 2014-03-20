using UnityEngine;
using System.Collections;

public class cameraPixelPerfect : MonoBehaviour
{
    public float pixels2units = 100.0f;

    // Use this for initialization
    void Start()
    {
        
        //float UnitsPerPixel = 1f / 100f;
        //float PixelsPerUnit = 100f / 1f; // yeah, yeah, 100
        //Camera.main.orthographicSize = Screen.height / 2f; // ortho-size is half the screen height...
        camera.orthographicSize = (Screen.height / pixels2units / 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //camera.orthographicSize = (Screen.height / pixels2units / 2.0f);
    }
}
