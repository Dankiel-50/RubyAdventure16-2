using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    private int count;
    public TextMeshProUGUI countText;

    public AudioSource audioPlayer;

    public ParticleSystem smokeEffect;

    new Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    bool broken = true;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won�t be executed.
        if (!broken)
        {
            return;
        }


        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    public void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    void FixedUpdate()
    {
        //remember ! inverse the test, so if broken is true !broken will be false and return won�t be executed.
        if (!broken)
        {
            return;
        }


        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    //Public because we want to call it from elsewhere like the projectile script
    public void Fix()
    {
        count = count + 1;
        SetCountText();
        broken = false;
        
        //optional if you added the fixed animation
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
    }
    //daniel did the fix2
    public void Fix2()
    {
        count = count - 1;
        SetCountText();
        broken = true;
        rigidbody2D.simulated = true;
        //optional if you added the fixed animation
        smokeEffect.Play();
        audioPlayer.Play();
    }
}