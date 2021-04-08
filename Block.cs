
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    private Vector3 startPosition;
    private float lastCheck;
    private bool hasFallen;

    void Start()
    {
        startPosition = transform.position; //on enregistre la position de depart 
        
    }

    // Update is called once per frame
    void Update()
    {
        //si le block a bouge on fait rien
        if (hasFallen)
            return;
        //on verifie chaque seconde si le block a changer de posisition ou non
        if (Time.time - lastCheck > 1)
        {
            lastCheck = Time.time;
            if(Vector3.Magnitude(transform.position - startPosition) > 1.5)//si sa posistion a changé a augmenter de plus de 1.5m par rapport a sa position de depart
            {
                hasFallen = true;//on dit que le block a bougé
                GameManger.Instance.RemoveBlock(this.gameObject);//et on le dit a notre fonction remove dans le gamemanger
            }
        }
        
    }
}
