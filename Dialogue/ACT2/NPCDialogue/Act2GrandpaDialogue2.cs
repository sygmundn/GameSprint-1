using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Act2GrandpaDialogue2 : MonoBehaviour
{
    public GameObject dialogueObject; // Reference to the object
    private NPCConversation grandpaConversation;
    private bool playerInRange = false;

    private void Start()
    {
        grandpaConversation = dialogueObject.GetComponent<NPCConversation>();
        if (grandpaConversation == null)
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
        && ((GameManager2.Instance.spokeToMom3 == 0) || (GameManager2.Instance.spokeToMom3 >= 1 && GameManager2.Instance.spokeToGrandpa2 == 0) 
                || (GameManager2.Instance.spokeToMom3 >= 1 && GameManager2.Instance.spokeToGrandpa2 == 1)))
        {
            Debug.Log("Enter key pressed");

            ConversationManager.Instance.StartConversation(grandpaConversation);

            // Set the isTextDisplayed flag on the PlayerController
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                playerController.SetIsTextDisplayed(true);
                GameManager2.Instance.spokeToGrandpa2 += 1;
                Debug.Log("Spoke to Grandpa2: " + GameManager2.Instance.spokeToGrandpa2); // Display the count

            }

        }
    }
}