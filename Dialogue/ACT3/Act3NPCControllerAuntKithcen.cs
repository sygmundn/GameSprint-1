using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act3NPCControllerAuntKithcen : MonoBehaviour
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
            auntNPCSpriteRenderer.enabled = false; // Initially, disable the sprite renderer
            auntNPCCollider.enabled = false;
        }
    }

    private void Update()
    {
        if (GameManager3.Instance.spokeToAunt2 && !GameManager3.Instance.spokeToAuntBrother3)
        {
            auntNPCSpriteRenderer.enabled = true; // Enable the sprite renderer
            auntNPCCollider.enabled = true;
        }

        else if (!ConversationManager.Instance.IsConversationActive)
        {
            auntNPCSpriteRenderer.enabled = false; // Disable the sprite renderer
            auntNPCCollider.enabled = false;
        }

    }
}
