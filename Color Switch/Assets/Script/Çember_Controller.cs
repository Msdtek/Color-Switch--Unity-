using UnityEngine;

public class Çember_Controller : MonoBehaviour
{   
    public bool dönme;
    [SerializeField] float cemberhzı;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dönme == true)
        {
            transform.Rotate(0, 0, cemberhzı * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, - cemberhzı * Time.deltaTime);
        }
         
    }
    
}
