using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class MomDialogue : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation momConversation;
    private bool playerInRange = false;

    private void Start()
    {
        momConversation = dialogueObject.GetComponent<NPCConversation>();
        if (momConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (!GameManager.Instance.spokeToBrother) && (!GameManager.Instance.spokeToUncle2) && (!ConversationManager.Instance.IsConversationActive))
        {

            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(momConversation);

            if (!GameManager.Instance.spokeToBrother)
            {
                Debug.Log("Starting mom conversation (not spoken to brother)");
            }
            else if (GameManager.Instance.spokeToBrother)
            {
                Debug.Log("Starting mom conversation (spoken to brother)");
            }

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
             
            }
        }
    }
}