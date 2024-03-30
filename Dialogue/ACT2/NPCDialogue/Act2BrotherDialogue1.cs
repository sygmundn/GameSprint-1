using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act2BrotherDialogue1 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation botherConversation;
    private bool playerInRange = false;

    private void Start()
    {
        botherConversation = dialogueObject.GetComponent<NPCConversation>();
        if (botherConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (!GameManager2.Instance.spokeToBathroomDoor) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(botherConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

        }
    }
}