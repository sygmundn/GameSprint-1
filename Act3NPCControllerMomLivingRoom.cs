using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act3NPCControllerMomLivingRoom : MonoBehaviour
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
            momNPCSpriteRenderer.enabled = false; // Initially, disable the sprite renderer
            momNPCCollider.enabled = false;
        }
    }

    private void Update()
    {
        if ((GameManager3.Instance.spokeToSister4) && (GameManager3.Instance.spokeToMomSister))
        {
            momNPCSpriteRenderer.enabled = true; // Enable the sprite renderer
            momNPCCollider.enabled = true;
        }

    }

}