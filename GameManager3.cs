using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class GameManager3 : MonoBehaviour
{

    private static GameManager3 instance;
    public static GameManager3 Instance { get { return instance; } }

    public bool spokeToBrother1 = false;
    public bool spokeToAunt2 = false;
    public bool spokeToAuntBrother3 = false;
    public int spokeToCousinSister1 = 0;
    public int spokeToCousinSister2 = 0;
    public bool spokeToMom2 = false;
    public bool spokeToSister4 = false;
    public bool spokeToMomSister = false;

    public bool spokeToAuntBrother4 = false;
    public bool spokeToCousin3 = false;
    public bool spokeToMom6 = false;
    public bool spokeToSister6 = false;


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
        
    }
}
