using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ToiletDialogue : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation toiletConversation;
    private bool playerInRange = false;

    private void Start()
    {
        toiletConversation = dialogueObject.GetComponent<NPCConversation>();
        if (toiletConversation == null)
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
            ConversationManager.Instance.StartConversation(toiletConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
            }
        }
    }
}