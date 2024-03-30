using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act2BathroomDoorDialogue : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation bathroomDoorConversation;
    private bool playerInRange = false;

    private void Start()
    {
        bathroomDoorConversation = dialogueObject.GetComponent<NPCConversation>();
        if (bathroomDoorConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (!GameManager2.Instance.spokeToBrother3) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(bathroomDoorConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

            GameManager2.Instance.spokeToBathroomDoor = true;
            Debug.Log("Bathroom Door triggered");

        }
    }
}
