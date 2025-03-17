using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaa : MonoBehaviour
{
    void Start()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0x4E00; i <= 0x9FFF; i++)
        {
            sb.Append((char)i);
        }
        Debug.Log(sb.ToString());
    }
}
