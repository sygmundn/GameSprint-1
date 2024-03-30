using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //always necessary when dealing with text

public class TypewriterEffect : MonoBehaviour
{

    [SerializeField] private float typewriterSpeed = 50f;

    public Coroutine Run(string textToType, TMP_Text textLabel) //runs the coroutine, driver method
        // parameters >> textToType = string we wanna type, textLabel = label we wanna type it on 
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel) //method reponsible for the type writting effect
    {

        textLabel.text = string.Empty;

        float t = 0; // elaplsed time since we began writting
        int charIndex = 0; // how many characters we wanna type on screen at the given frame

        //to express that:
        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typewriterSpeed; //becomes one after one second, increments over time
            charIndex = Mathf.FloorToInt(t); //stores the float value of the timer -- will round numebers since frames are integers 
            // wanna make sure that the value that comes out is nerver longer than textToType so...
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text= textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType; //the label is the text we want to type
    }
}
