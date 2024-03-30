using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act3NPCControllerBrotherLivingRoom2 : MonoBehaviour
{
    public SpriteRenderer brotherNPCSpriteRenderer;
    public CapsuleCollider2D brotherNPCCollider;

    private void Start()
    {
        // Assuming you have assigned the Aunt NPC's sprite renderer in the Inspector
        if (brotherNPCSpriteRenderer == null)
        {
            Debug.LogError("Brother NPC's SpriteRenderer not assigned.");
        }
        else
        {
            brotherNPCSpriteRenderer.enabled = false; // Initially, disable the sprite renderer
            brotherNPCCollider.enabled = false;
        }
    }

    private void Update()
    {
        if (GameManager3.Instance.spokeToAuntBrother3)
        {
            brotherNPCSpriteRenderer.enabled = true; // Enable the sprite renderer
            brotherNPCCollider.enabled = true;
        }

    }

}