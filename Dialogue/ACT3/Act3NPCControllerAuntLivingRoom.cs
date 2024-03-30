using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act3NPCControllerAuntLivingRoom : MonoBehaviour
{
    public SpriteRenderer auntNPCSpriteRenderer;
    public CapsuleCollider2D auntNPCCollider;

    private void Start()
    {
        // Assuming you have assigned the Aunt NPC's sprite renderer in the Inspector
        if (auntNPCSpriteRenderer == null)
        {
            Debug.LogError("Aunt NPC's SpriteRenderer not assigned.");
        }
        else
        {
            auntNPCSpriteRenderer.enabled = true; // Initially, disable the sprite renderer
            auntNPCCollider.enabled = true;
        }
    }

    private void Update()
    {
        if ((GameManager3.Instance.spokeToAunt2) && (!ConversationManager.Instance.IsConversationActive))
        {
            auntNPCSpriteRenderer.enabled = false; // Enable the sprite renderer
            auntNPCCollider.enabled = false;
        }

    }
}
