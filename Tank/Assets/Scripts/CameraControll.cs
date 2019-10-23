using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Quaternion defPos;
    private float AngelVertical = 0;
    private float AngelHorizontal = 0;
    private float Zoom = 0;
    public float MouseSense = 5;
    public float ZoomSense = 30;
    void Start()
    {
        defPos = transform.rotation;
    }
    void Update()
    {
        AngelHorizontal += Input.GetAxis("Mouse X") * MouseSense;
        AngelVertical -= Input.GetAxis("Mouse Y") * MouseSense;
        Zoom -= Input.GetAxis("Mouse ScrollWheel") * ZoomSense;

        AngelVertical = Mathf.Clamp(AngelVertical, 10, 80);
        Zoom = Mathf.Clamp(Zoom, 15f, 60f);


        Quaternion rotY = Quaternion.AngleAxis(AngelHorizontal, Vector3.up);
        Quaternion rotX = Quaternion.AngleAxis(AngelVertical, Vector3.right);



        transform.rotation = defPos * rotY * rotX;
        Camera.main.fieldOfView = Zoom;
    }
}
