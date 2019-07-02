using UnityEngine;
using System.Collections;

public class scrollerScirpt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)

        {

            if (Camera.main.fieldOfView <= 100)

                Camera.main.fieldOfView += 2;

            if (Camera.main.orthographicSize <= 20)

                Camera.main.orthographicSize += 0.5F;

        }

        //Zoom in

        if (Input.GetAxis("Mouse ScrollWheel") > 0)

        {

            if (Camera.main.fieldOfView > 2)

                Camera.main.fieldOfView -= 2;

            if (Camera.main.orthographicSize >= 1)

                Camera.main.orthographicSize -= 0.5F;

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, 200 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, -200 * Time.deltaTime);
        }
    }
}
