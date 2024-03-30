using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class GameManager2 : MonoBehaviour
{

    private static GameManager2 instance;
    public static GameManager2 Instance { get { return instance; } }

    public bool spokeToBathroomDoor = false; 
    public bool spokeToBrother2 = false;


    public int spokeToUncle2 = 0; 
    public int spokeToAunt2 = 0;
    public int spokeToGrandpa2 = 0;
    public int spokeToKid2 = 0;
    public int spokeToMom2 = 0;
    public int spokeToCousin2 = 0;


    public int spokeToMom3 = 0;
    public int spokeToCousin3 = 0;
    public int spokeToKid3 = 0;
    public int spokeToGrandpa3 = 0;
    public int spokeToAunt3 = 0;
    public int spokeToUncle3 = 0;

    public bool spokeToBrother3 = false;
    public bool spokeToBathroomDoor2 = false;
    public bool spokeToBathroomDoor3 = false;

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
