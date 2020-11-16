using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController01 : MonoBehaviour
{
    public Animator playerAni;
    public Rigidbody RB;
    public GameObject health;

    float speed = 5;
    float jumpForce = 5f;
    int healthCounter = 0;

    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAni.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            playerAni.SetBool("isMove", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAni.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAni.SetBool("isMove", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAni.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAni.SetBool("isMove", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAni.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAni.SetBool("isMove", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded))
        {
            playerJump();
            playerAni.SetTrigger("TFlip");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            healthCounter++;
            Debug.Log(healthCounter);
            health.GetComponent<Text>().text = "Death at 10:" + healthCounter;

            if (healthCounter == 10)
            {
                playerAni.SetTrigger("TDeath");
                speed = 0;
                jumpForce = 0;
            }      
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void playerJump()
    {
        isGrounded = false;
        RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
