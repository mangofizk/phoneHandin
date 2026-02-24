using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] float movespeed;
    Rigidbody2D rb;

    [SerializeField] InputSys InputSys;

    public DodgerAttributes dodgerAttributes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dodgerAttributes = new DodgerAttributes(10 , 20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        int moveDir = 0;

        Vector2 screenPos;

        if (InputSys.IsPressing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0f));
            
            if(touchPos.x < 0)
            {
                moveDir = -1;
            }
            else
            {
                moveDir = 1;
            }            
        }

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);

        if ((viewportPos.x < 0f && moveDir < 0) || (viewportPos.x >= 1f && moveDir > 0))
        {
            moveDir = 0;
        }


        rb.linearVelocityX = moveDir * movespeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            dodgerAttributes.setcurrenthealth(dodgerAttributes.getcurrenthealth() - 1);

        if (collision.gameObject.CompareTag("Enemy") && dodgerAttributes.getcurrenthealth() == 0) 
        SceneManager.LoadScene(0);
    }
}
