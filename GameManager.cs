using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public bool spokeToBrother = false; //unlocks Mom2
    public bool spokeToAunt = false; //unlocks Uncle2
    public bool spokeToUncle2 = false; //unlocks Mom3
    public bool spokeToMom2 = false; //unlocks Cousin2
    public bool spokeToMom3 = false; //unlocks Cousin2 (either Mom2 or Mom3 can unlock it)
    public bool spokeToCousin1 = false; //Cousin1 (or Cousin2) unlocks Grandpa2
    public bool spokeToCousin2 = false; //unlocks Kid2 and Grandpa2
    public bool spokeToKid2 = false; //u nlocks Sister2
    public bool spokeToSister2 = false; //unlocks sister3
    public bool spokeToSister3 = false; //unlocks CUT SCENE

    private bool cutSceneLoaded = false;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!cutSceneLoaded && !ConversationManager.Instance.IsConversationActive && GameManager.Instance.spokeToSister2)
        {
            // Load the next scene
            SceneManager.LoadScene("CutSceneAct1To2");
            cutSceneLoaded = true; // Set the flag to true after loading the scene
        }

    }

    
}
