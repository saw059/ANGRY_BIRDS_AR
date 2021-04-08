using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance {set; get; }
    public List<GameObject> allBlocks;
    private int niveau = 0;
    public GameObject[] levelPrefab;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        ChangeScene("Menu");
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // on charge la scene
    }
    public void OnLevelWasLoaded(int levelIndex)
    {
        if (SceneManager.GetActiveScene().name == "jeu")//si on est dans la scene jeu
        {
            if (niveau < levelPrefab.Length)//si il ya encore des niveaux
                Instantiate(levelPrefab[niveau]);//on charger ces niveaux sur la scene

            else
                ChangeScene("Menu"); // sinn si ya plus de niveau, on retourne au menu
            
 
            //"Block" est le tag des elements qu'on aimerait bouger
            //allblocks ce sont tous nos block
            GameObject[] a = GameObject.FindGameObjectsWithTag("Block");// elle nous permet d'indentifier les block qui devrait bouger et le mettre dans une liste
            allBlocks = new List<GameObject>();
            allBlocks.AddRange(a);
            

        }
        

    }
    //la fonction removeblock va nous permettre de voir si nos block ont bougés ou non
    public void RemoveBlock(GameObject block)
    {   //on dabord chercher a savoir si on a toujours des block qui n'ont pas bougés
        if (allBlocks.Find(b => b == block))
            allBlocks.Remove(block);
        //si on gagne cad que tous les blocks ont bouges
        if (allBlocks.Count == 0)
            Victoire();//on appelle la fonction victoire
    }
    public void Victoire()
    {
        //cette fonction remet le scene du jeu en augmentant le niveau 
        niveau++;
        ChangeScene("jeu");

    }
}
