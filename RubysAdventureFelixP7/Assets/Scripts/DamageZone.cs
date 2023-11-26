using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        RubysController controller = other.GetComponent<RubysController >();
        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
