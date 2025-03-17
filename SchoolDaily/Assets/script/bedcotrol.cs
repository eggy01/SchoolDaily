using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class bedcotrol : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI Text;
    public Button yesButton;
    public Button noButton;

    void onYesClicked()
    {
        panel.SetActive(false);
        player.Instance.SetPlayerControl(false);
        // 触发上床睡觉的逻辑
        StartCoroutine(GoToBed());
    }

    private IEnumerator GoToBed()
    {
        // 播放上床睡觉的动画或逻辑
        Vector3 bed = new Vector3(-4.5f, 1.9f, 0f);
        player.Instance.MoveToTarget(bed);

        Debug.Log("玩家上床睡觉");

        // 等待玩家按下 F 键
        while (!Input.GetKeyDown(KeyCode.F))
        {
            yield return null; // 等待下一帧
        }

        // 播放下床的动画或逻辑
        Debug.Log("玩家下床");

        // 恢复玩家控制
        player.Instance.SetPlayerControl(true);
    }
    void onNoClicked()
    {
        panel.SetActive(false);
        player.Instance.SetPlayerControl(true);
    }

    void showDialogue(string massage)
    {
        Text.text = massage;
        panel.SetActive(true);
        yesButton.onClick.AddListener(onYesClicked);
        noButton.onClick.AddListener(onNoClicked);
        player.Instance.SetPlayerControl(false);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            showDialogue("sleep?");
        }
    }
}
