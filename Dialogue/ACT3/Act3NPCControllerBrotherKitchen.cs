using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act3NPCControllerBrotherKitchen : MonoBehaviour
{
    public SpriteRenderer brotherNPCSpriteRenderer;
    public CapsuleCollider2D brotherNPCCollider;

    private void Start()
    {
        // Assuming you have assigned the Aunt NPC's sprite renderer in the Inspector
        if (brotherNPCSpriteRenderer == null)
        {
            Debug.LogError("Aunt NPC's SpriteRenderer not assigned.");
        }
        else
        {
            brotherNPCSpriteRenderer.enabled = true; // Initially, disable the sprite renderer
            brotherNPCCollider.enabled = true;
        }
    }

    private void Update()
    {
        if (GameManager3.Instance.spokeToAuntBrother3 && !ConversationManager.Instance.IsConversationActive)
        {
            brotherNPCSpriteRenderer.enabled = false; // Enable the sprite renderer
            brotherNPCCollider.enabled = false;
        }

    }

}
