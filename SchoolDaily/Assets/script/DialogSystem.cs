using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public TextMeshProUGUI textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;

    private List<CSVReader.CSVRow> data; // 存储解析后的 CSV 数据
    private int index = 0; // 当前对话索引
    private bool isDialogueActive = false; // 是否正在对话


    // Start is called before the first frame update
    void Start()
    {
        data = CSVReader.Instance.read_csv(textFile);
        index = 0;
        StartDialogue();

    }

    // Update is called once per frame
    void Update()
    {
        // // 按下 E 键开始对话
        // if (Input.GetKeyDown(KeyCode.E) && !isDialogueActive)
        // {
        //     StartDialogue();
        // }

        // 对话进行中，点击鼠标左键继续
        if (isDialogueActive && Input.GetMouseButtonDown(0))
        {
            if (index < data.Count - 1)
            {
                index++; // 切换到下一条对话
                UpdateDialogueUI(data[index]);
            }
            else
            {
                EndDialogue(); // 对话结束
            }
        }
    }
    void StartDialogue()
    {
        isDialogueActive = true;
        index = 0; // 重置索引


        // 显示第一条对话
        UpdateDialogueUI(data[index]);
    }

    void UpdateDialogueUI(CSVReader.CSVRow row)
    {
        Debug.Log($"角色: {row.角色}, 地点: {row.地点}, F: {row.对话文本}");
        // 更新对话文本
        textLabel.text = row.对话文本;
        // 输出解析后的数据



        // 加载并显示角色图标
        Sprite characterSprite = Resources.Load<Sprite>(row.角色);
        if (characterSprite != null)
        {
            faceImage.sprite = characterSprite;
        }
        else
        {
            Debug.LogError($"未找到角色图标: {row.角色}");
        }
    }
    void EndDialogue()
    {
        isDialogueActive = false;

        // 隐藏对话 UI
        textLabel.gameObject.SetActive(false);
        faceImage.gameObject.SetActive(false);

        Debug.Log("对话已结束！");
    }
}
