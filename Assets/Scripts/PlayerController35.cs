using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController35 : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float jumpForce = 12.0f;
    float gravityModifier = 2.5f;
    float health = 10.0f;

    bool isCollide = true;
    bool isAlive = true;

    public Rigidbody playerRb;
    public Animator playerAnim;
    public GameObject HealthText;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        ForwardKey();
        LeftKey();
        DownKey();
        RightKey();

        if(Input.GetKeyDown(KeyCode.Space) && isCollide && isAlive)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            playerAnim.SetTrigger("trigFlip");

            isCollide = false;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            --health;
            print("Health: " + health);

            HealthText.GetComponent<Text>().text = ("Health: " + health);

            if(health <= 0)
            {
                playerAnim.SetTrigger("trigDeath");

                isAlive = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PlayPlane"))
        {
            isCollide = true;
        }
    }

    private void ForwardKey()
    {
        if (Input.GetKey(KeyCode.W) && isAlive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.W) && isAlive)
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

    private void LeftKey()
    {
        if (Input.GetKey(KeyCode.A) && isAlive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnim.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.A) && isAlive)
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

    private void DownKey()
    {
        if (Input.GetKey(KeyCode.S) && isAlive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.S) && isAlive)
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

    private void RightKey()
    {
        if (Input.GetKey(KeyCode.D) && isAlive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnim.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.D) && isAlive)
        {
            playerAnim.SetBool("isMoving", false);
        }
    }
}
