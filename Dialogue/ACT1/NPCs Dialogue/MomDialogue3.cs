using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class MomDialogue3 : MonoBehaviour
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (GameManager.Instance.spokeToUncle2) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(momConversation);

            if (!GameManager.Instance.spokeToBrother)
            {
                Debug.Log("Starting mom3 conversation (not spoken to uncle2)");
            }
            else if (GameManager.Instance.spokeToBrother)
            {
                Debug.Log("Starting mom3 conversation (spoken to uncle2)");
            }

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

            GameManager.Instance.spokeToMom3 = true;
            Debug.Log("Mom3 triggered");

        }
    }
}