using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    new Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    Animator animator;
    bool broken = true;

    public ParticleSystem smokeEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
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

    void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            animator.SetFloat("Move x", 0);
            animator.SetFloat("Move Y", direction);
            position.y = position.y + Time.deltaTime * speed * direction; ;
        }
        else
        {
            animator.SetFloat("Move x", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + Time.deltaTime * speed * direction; ;
        }

        rigidbody2D.MovePosition(position);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubysController player = other.gameObject.GetComponent<RubysController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");

        smokeEffect.Stop();
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}