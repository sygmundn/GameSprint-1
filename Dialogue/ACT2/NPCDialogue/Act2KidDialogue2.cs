using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act2KidDialogue2 : MonoBehaviour
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
        if ((playerInRange && Input.GetKeyDown(KeyCode.Return)) && (!ConversationManager.Instance.IsConversationActive) && (GameManager2.Instance.spokeToBrother2) 
            && ((GameManager2.Instance.spokeToUncle2 == 0) || (GameManager2.Instance.spokeToUncle2 >= 1 && GameManager2.Instance.spokeToKid2 == 0)))
        {
            Debug.Log("Enter key pressed");

            ConversationManager.Instance.StartConversation(kidConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
                GameManager2.Instance.spokeToKid2 += 1;
                Debug.Log("Spoke to Kid2: " + GameManager2.Instance.spokeToKid2); // Display the count

            }

        }
    }
}
