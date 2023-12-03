using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    
    public AudioClip collectedClip;
    public ParticleSystem sparkles;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        RubysController controller = other.GetComponent<RubysController>();
        

        if (controller != null)
        {
            if (controller.currentHealth < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
                sparkles.Stop();

                controller.PlaySound(collectedClip);

            }
           
        }
    }
}
