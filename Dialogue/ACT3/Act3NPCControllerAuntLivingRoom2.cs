using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act3NPCControllerAuntLivingRoom2 : MonoBehaviour
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
        if (GameManager3.Instance.spokeToAuntBrother3)
        {
            auntNPCSpriteRenderer.enabled = true; // Enable the sprite renderer
            auntNPCCollider.enabled = true;
        }

    }

}