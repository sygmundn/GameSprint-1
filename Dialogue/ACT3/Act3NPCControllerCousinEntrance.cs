using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act3NPCControllerCousinEntrance : MonoBehaviour
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
            cousinNPCSpriteRenderer.enabled = true; // Initially, disable the sprite renderer
            cousinNPCCollider.enabled = true;
        }
    }

    private void Update()
    {
        if (GameManager3.Instance.spokeToCousinSister2 == 1 && !ConversationManager.Instance.IsConversationActive)
        {
            cousinNPCSpriteRenderer.enabled = false; // Enable the sprite renderer
            cousinNPCCollider.enabled = false;
        }

    }

}