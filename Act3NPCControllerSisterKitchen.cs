using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act3NPCControllerSisterKitchen : MonoBehaviour
{
    public SpriteRenderer sisterNPCSpriteRenderer;
    public CapsuleCollider2D sisterNPCCollider;

    private void Start()
    {
        // Assuming you have assigned the Aunt NPC's sprite renderer in the Inspector
        if (sisterNPCSpriteRenderer == null)
        {
            Debug.LogError("Aunt NPC's SpriteRenderer not assigned.");
        }
        else
        {
            sisterNPCSpriteRenderer.enabled = false; // Initially, disable the sprite renderer
            sisterNPCCollider.enabled = false;
        }
    }

    private void Update()
    {
        if ((GameManager3.Instance.spokeToSister4) && (!GameManager3.Instance.spokeToMomSister))
        {
            sisterNPCSpriteRenderer.enabled = true; // Enable the sprite renderer
            sisterNPCCollider.enabled = true;
        }

        else if (!ConversationManager.Instance.IsConversationActive)
        {
            sisterNPCSpriteRenderer.enabled = false; 
            sisterNPCCollider.enabled = false;
        }

    }

}