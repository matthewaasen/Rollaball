using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private int count = 0;
    private float movementX;
    private float movementY;

    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
       {
           winTextObject.SetActive(true);
       }

    }
    void Start()
    {
        winTextObject.SetActive(false);
        rb = GetComponent <Rigidbody>(); 
        SetCountText();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
        

    }

    void OnTriggerEnter(Collider other)
    {
 
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);  
            count = count + 1;
            SetCountText();
        }
        
    } 
}
