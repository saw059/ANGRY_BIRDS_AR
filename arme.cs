using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arme : MonoBehaviour
{
    public GameObject RedPrefab; //declaration de l'objet qu'on va tirer ici l'oiseau rouge qui se trouve dans le prefab
    public Transform sObject;  
    private void Update()
    {   //a chaque fois qu'on appuie sur l'ecran de notre telephone on va effectuer l'action de tirer
        if (Input.GetMouseButtonDown(0))
        {
            //cette action va faire changer la posistion et la rotation de oiseau 
            GameObject tir = Instantiate(RedPrefab, sObject.position, sObject.rotation) as GameObject;
            //pour cela on rajoute une force a notre action qui est velocitychange qui va nous permettre de tirer
            //on multip cette force par 70 pour que notre oiseau aille suffisament loin pour toucher les constructions
            //cette force depend aussi du poids de notre gameobejct
            tir.GetComponent<Rigidbody>().AddForce(transform.forward * 70,ForceMode.VelocityChange);
        }
    }
}
