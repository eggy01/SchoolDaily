using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class sushepengzhuang : MonoBehaviour
{
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 获取Tilemap下玩家位置的瓦片
            Vector3Int position = WorldToCell(collision.transform.position);
            TileBase tile = tilemap.GetTile(position);

            if (tile != null)
            {
                // 根据瓦片类型执行不同的操作
                if (tile.name == "bed")
                {
                    Debug.Log("玩家触碰到床，触发睡觉对话");
                }
                else if (tile.name == "Chair")
                {
                    Debug.Log("玩家触碰到椅子，坐下");
                }
                else if (tile.name == "Computer")
                {
                    Debug.Log("玩家触碰到电脑，显示电脑屏幕");
                }
            }
        }
    }

    Vector3Int WorldToCell(Vector3 position)
    {
        Vector3Int cell = new Vector3Int(
            Mathf.FloorToInt(position.x),
            Mathf.FloorToInt(position.y),
            0
        );
        return cell;
    }
}
