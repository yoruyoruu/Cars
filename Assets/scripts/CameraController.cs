using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotareSpeed = 20.0f, speed = 10.0f, zoomspeed = 10.0f;

    private void Update() 
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float rotate = 0f;

        if (Input.GetKey(KeyCode.Q))
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E))
            rotate = 1f;  

        
        transform.Rotate(Vector3.up * rotareSpeed * Time.deltaTime * rotate, Space.World);   // вертим камеру
        
        transform.Translate(new Vector3(hor,0,ver) * Time.deltaTime * speed, Space.Self);    // двигаем камерой
        
        transform.position += transform.up * zoomspeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");   // приближаем,отдаляем


        transform.position = new Vector3   // максимальное и минимальное приближение и отдаление
        (
            transform.position.x,
            Mathf.Clamp(transform.position.y, -20f, 30f),
            transform.position.z);    
    }
    
}
