using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Top_Controller : MonoBehaviour
{
    public string Mevcutrenk;
    private Color toprenk;
    public Color sarı;
    public Color turkuaz;
    public Color kırmızı;
    public Color mor;
    public Transform çember;
    public  Text skortext;
    public GameObject [] cemberler;
    public GameObject renktekeri;
    public GameObject puan;
    public static int skor = 0 ;
    [SerializeField] float jump;

    private Rigidbody2D rb;
    private bool oyunBasladi = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Başta yerçekimi kapalı
        skortext.text = skor.ToString();
        Random_Color();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!oyunBasladi && Input.GetMouseButtonDown(0))
        {
            oyunBasladi = true;
            rb.gravityScale = 3f; // Yerçekimini aç
            rb.linearVelocity = Vector2.up * jump; // Zıplama efekti
        }
        else if (oyunBasladi && Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jump;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bu pozisyon yeni çemberin doğacağı yer
        

        if (collision.CompareTag("Skoru Arttir"))
        {
            skor += 3;
            skortext.text = skor.ToString();
            int rastgelecember = Random.Range(0, 2);
            Debug.Log(rastgelecember);
            Vector3 yeniCemberPozisyonu = new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z);
            Instantiate(cemberler[rastgelecember], yeniCemberPozisyonu, transform.rotation);
            Destroy(collision.gameObject);
            return;
        }

        if (collision.CompareTag("Renk Tekeri"))
        {
            Random_Color();
            Destroy(collision.gameObject);
            Instantiate(renktekeri, new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z), transform.rotation);

            return;
        }

        if (!collision.CompareTag(Mevcutrenk))
        {
            skor = 0;
            skortext.text = skor.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("dead");
        }
    }


    public void Random_Color()
    { 
        int Random_Color_Number = Random.Range(0, 4);

        switch(Random_Color_Number)
        {
            case 0:
                Mevcutrenk = "turkuaz";
                toprenk = turkuaz;
                break;
            case 1:
                Mevcutrenk = "mor";
                toprenk = mor;
                break;
            case 2:
                Mevcutrenk = "sarı";
                toprenk = sarı;
                break;
            case 3:
                Mevcutrenk = "kırmızı";
                toprenk = kırmızı;
                break;
        }
        GetComponent<SpriteRenderer>().color = toprenk;
    }
}
