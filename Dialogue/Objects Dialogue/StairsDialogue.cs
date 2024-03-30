using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class StairsDialogue : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation stairsConversation;
    private bool playerInRange = false;

    private void Start()
    {
        stairsConversation = dialogueObject.GetComponent<NPCConversation>();
        if (stairsConversation == null)
        {
            Debug.LogError("NPCConversation component not found on " + dialogueObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        // Check player interaction
        if (playerInRange && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(stairsConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
            }
        }
    }
}