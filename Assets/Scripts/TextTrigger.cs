// text from We Go to the Gallery by Ezra Elia and Miriam Elia
// Text trigger tutorial from https://www.youtube.com/watch?v=CNNeD9oT4DY&t=22s

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{

    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
          uiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider player) {
        if (player.gameObject.tag == "person") {
          uiObject.SetActive(true);
        }
    }

    void OnTriggerExit (Collider player) {
        if (player.gameObject.tag == "person") {
          uiObject.SetActive(false);
        }
    }
}
