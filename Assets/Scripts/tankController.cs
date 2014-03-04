using UnityEngine;
using System.Collections;

public class tankController : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 currentPosition;

    private Vector3 moveDirection;


    // Update is called once per frame
    void Update()
    {
        /*
        // 1
        Vector3 currentPosition = transform.position;
        // 2
        if (Input.GetButton("Horizontal"))
        {
            // 3
            Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 4
            moveDirection = moveToward - currentPosition;
            moveDirection.z = 0;
            moveDirection.Normalize();
            Debug.Log(moveDirection);
            Vector3 target = moveDirection * moveSpeed + currentPosition;
            transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
        }

        //Vector3 target = moveDirection * moveSpeed + currentPosition;
        //transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
        */
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
            transform.position = (currentPosition + direction * moveSpeed);
        }


        Debug.Log(currentPosition);
    }
}
