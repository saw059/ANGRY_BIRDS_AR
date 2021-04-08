using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //des qu'on click sur le bouton on change de scene
    //il faut declarer cette fonction dans l'inspector du bouton
    public void OnPlayButtonClick()
    {
        GameManger.Instance.ChangeScene("jeu");

    }
}
