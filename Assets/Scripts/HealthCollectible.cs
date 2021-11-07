using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public bool respawn;
    public float timeToRespawn;
    public GameObject apple;

    public AudioClip collectedClip;
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Object that entered the trigger : " + other);

        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                
                Destroy(gameObject);

                controller.PlaySound(collectedClip);

            }

            
        }
        
        //Respawnable();
    }

    /*void Respawnable()
    {
        timeToRespawn = 10f;
        respawn = true;
        apple.SetActive(true);
        gameObject.SetActive(true);
    }*/

}
