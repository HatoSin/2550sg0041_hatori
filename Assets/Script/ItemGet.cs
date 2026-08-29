using UnityEngine;

public class RandomCollectible : MonoBehaviour
{
    [Header("出現範囲設定")]
    public float minX = -8f;   // マップの左端
    public float maxX = 8f;    // マップの右端
    public float minZ = -8f;   // マップの手前
    public float maxZ = 8f;    // マップの奥
    public float height = 0.5f; // 球体の高さ

    void Start()
    {
        // 最初にランダムな位置に配置
        MoveToRandomPosition();
    }

    // プレイヤーが触れたときに呼ばれる
    private void OnTriggerEnter(Collider other)
    {
        // 触れた相手がプレイヤー（Capsule）かどうか判定
        if (other.CompareTag("Player"))
        {
            MoveToRandomPosition();
        }
    }

    // ランダムな位置に移動する関数
    void MoveToRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        transform.position = new Vector3(randomX, height, randomZ);
    }
}