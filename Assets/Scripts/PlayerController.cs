using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        countText.text = "Count: " + count.ToString();
        winText.text = "";
    }

    // Use this for physics
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
     }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count.ToString();
            if (count == 5)
            {
                winText.text = "Gewonnen!";
                
            }
        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

  