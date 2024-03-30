using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D theRB;

    private Animator animatorPlayer;

    private bool isTextDisplayed = false; // Flag to track if text is displayed

    private static Vector2 playerEntryPoint; // Static variable to store the entry point

    public static void SetPlayerEntryPoint(Vector2 entryPoint)
    {
        playerEntryPoint = entryPoint;
    }

    public static Vector2 GetPlayerEntryPoint()
    {
        return playerEntryPoint;
    }

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        animatorPlayer = GetComponent<Animator>();

        transform.position = GetPlayerEntryPoint();

    }

    // Update is called once per frame
    void Update()
    {

        if (isTextDisplayed)
        {
            // If text is displayed, prevent movement
            theRB.velocity = Vector2.zero;
            if (!ConversationManager.Instance.IsConversationActive)
            {
                SetIsTextDisplayed(false); // Reset the flag when conversation ends
            }
            return;
        }


        // Get input values
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1f;
            moveHorizontal = 0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1f;
            moveHorizontal = 0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f;
            moveVertical = 0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f;
            moveVertical = 0f;
        }

        animatorPlayer.SetBool("MoveUp", moveVertical > 0);
        animatorPlayer.SetBool("MoveDown", moveVertical <0);
        animatorPlayer.SetBool("MoveLeft", moveHorizontal < 0);
        animatorPlayer.SetBool("MoveRight", moveHorizontal > 0);

        // Calculate movement vector
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;

        // Apply movement to the Rigidbody
        theRB.velocity = movement;
    }

    public void SetIsTextDisplayed(bool value)
    {
        isTextDisplayed = value;
    }


}
