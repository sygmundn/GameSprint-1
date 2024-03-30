using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class UncleDialogue1 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation uncleConversation;
    private bool playerInRange = false;

    private void Start()
    {
        uncleConversation = dialogueObject.GetComponent<NPCConversation>();
        if (uncleConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (!GameManager.Instance.spokeToAunt) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");

            ConversationManager.Instance.StartConversation(uncleConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
            }

        }
    }
}