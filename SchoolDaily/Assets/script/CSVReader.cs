using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    // 单例实例
    private static CSVReader _instance;
    public static CSVReader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CSVReader>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("CSVReader");
                    _instance = obj.AddComponent<CSVReader>();
                }
            }
            return _instance;
        }
    }
    [System.Serializable]
    public class CSVRow
    {
        public string 序号;
        public string 角色;
        public string 地点;
        public string 对话文本;
        public string 选项;
        public string 表情差分;
        public string 字数;
    }


    public List<CSVRow> read_csv(TextAsset csvFile)
    {
        List<CSVRow> data = new List<CSVRow>();
        if (csvFile != null)
        {
            string[] lines = csvFile.text.Split('\n');
            for (int i = 0; i < lines.Length; i++) // 从第 1 行开始，跳过表头
            {
                string[] fields = lines[i].Split(',');
                if (fields.Length >= 7) // 确保字段数量正确
                {
                    CSVRow row = new CSVRow
                    {
                        序号 = fields[0],
                        选项 = fields[1],
                        角色 = fields[2],
                        地点 = fields[3],
                        对话文本 = fields[4],
                        表情差分 = fields[5],
                        字数 = fields[6]
                    };
                    data.Add(row);
                }
            }

            // // 输出解析后的数据
            // foreach (var row in data)
            // {
            //     Debug.Log($"角色: {row.角色}, 地点: {row.地点}, F: {row.对话文本}");
            // }
        }
        else
        {
            Debug.LogError("CSV 文件未分配！");
        }
        return data;
    }
}
