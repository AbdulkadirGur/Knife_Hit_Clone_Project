using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;

    private bool isActive = true;

    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider= rb.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive) 
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            //FindObjectOfType<GameController>().Voices[5].Play();
            rb.gravityScale = 1;
            GameController.Instance.GameUI.DecrementDisplayedKnifeCount();

        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!isActive)
            return;

        isActive= false;

        if(collision.collider.tag == "kutuk")
        {
            GetComponent<ParticleSystem>().Play();
            FindObjectOfType<GameController>().Voices[4].Play();

            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.2f);

            GameController.Instance.OnSuccessfulKnifeHit();          
        }
        else if(collision.collider.tag == "bicak")
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            GameController.Instance.StartGameOverSequance(false);
            FindObjectOfType<GameController>().Voices[3].Play();
        }
       
    }
}
