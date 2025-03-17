using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            talkUI.SetActive(true);

        }
    }
}
