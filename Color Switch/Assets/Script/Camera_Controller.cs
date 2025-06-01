using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform top;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(top.position.y >transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, top.position.y, transform.position.z);
        }
    }
}
