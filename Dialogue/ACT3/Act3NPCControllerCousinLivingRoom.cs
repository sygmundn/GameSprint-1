using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act3NPCControllerCousinLivingRoom : MonoBehaviour
{
    public SpriteRenderer cousinNPCSpriteRenderer;
    public CapsuleCollider2D cousinNPCCollider;

    private void Start()
    {
        // Assuming you have assigned the Aunt NPC's sprite renderer in the Inspector
        if (cousinNPCSpriteRenderer == null)
        {
            Debug.LogError("Aunt NPC's SpriteRenderer not assigned.");
        }
        else
        {
            cousinNPCSpriteRenderer.enabled = false; // Initially, disable the sprite renderer
            cousinNPCCollider.enabled = false;
        }
    }

    private void Update()
    {
        if (GameManager3.Instance.spokeToCousinSister2 >= 1)
        {
            cousinNPCSpriteRenderer.enabled = true; // Enable the sprite renderer
            cousinNPCCollider.enabled = true;
        }

    }

}