using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggsScript : MonoBehaviour
{
    public Animator leaves;
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name == "Plant")
        {
            leaves.SetTrigger("Watering");
        }
    }
}
