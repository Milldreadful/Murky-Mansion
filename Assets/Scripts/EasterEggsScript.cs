using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggsScript : MonoBehaviour
{
    public Animator leaves;
    public GameObject textTrigger;
    public GameObject waterText;

    public Renderer myModel;


    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name == "Plant")
        {
            leaves.SetTrigger("Watering");
            waterText.SetActive(false);
            Destroy(textTrigger);
        }

        if (other.gameObject.name == "Smudge")
        {
            FadeMaterial();
        }
    }

    public void FadeMaterial()
    {
        Color color = myModel.material.color;
        color.a -= 0.05f;
        myModel.material.color = color;
    }
}
