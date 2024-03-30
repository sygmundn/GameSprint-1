using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class KidDialogue2 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation kidConversation;
    private bool playerInRange = false;

    private void Start()
    {
        kidConversation = dialogueObject.GetComponent<NPCConversation>();
        if (kidConversation == null)
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (GameManager.Instance.spokeToCousin2) && (!ConversationManager.Instance.IsConversationActive))
        {
            Debug.Log("Enter key pressed");
            ConversationManager.Instance.StartConversation(kidConversation);

            if (!GameManager.Instance.spokeToCousin2)
            {
                Debug.Log("Starting kid conversation (not spoken to cousin2)");
            }
            else if (GameManager.Instance.spokeToCousin2)
            {
                Debug.Log("Starting kid conversation (spoken to cousin2)");
            }

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);

            }

            GameManager.Instance.spokeToKid2 = true;

        }
    }
}
