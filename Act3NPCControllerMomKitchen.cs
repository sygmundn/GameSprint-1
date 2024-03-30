using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act3NPCControllerMomKitchen : MonoBehaviour
{
    public SpriteRenderer momNPCSpriteRenderer;
    public CapsuleCollider2D momNPCCollider;

    private void Start()
    {
        // Assuming you have assigned the Aunt NPC's sprite renderer in the Inspector
        if (momNPCSpriteRenderer == null)
        {
            Debug.LogError("Aunt NPC's SpriteRenderer not assigned.");
        }
        else
        {
            momNPCSpriteRenderer.enabled = true; // Initially, disable the sprite renderer
            momNPCCollider.enabled = true;
        }
    }

    private void Update()
    {
        if ((GameManager3.Instance.spokeToMomSister) && (!ConversationManager.Instance.IsConversationActive))
        {
            momNPCSpriteRenderer.enabled = false; // Enable the sprite renderer
            momNPCCollider.enabled = false;
        }

    }

}