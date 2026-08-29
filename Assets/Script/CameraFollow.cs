using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("追従設定")]
    public Transform target;                 // 追従する対象（Capsule）
    public Vector3 offset = new Vector3(0, 5f, -8f);  // カメラの相対位置
    public float followSpeed = 5f;           // 追従の滑らかさ
    public float lookSpeed = 5f;             // 見る方向の滑らかさ

    void LateUpdate()
    {
        if (target == null) return;

        // 目標位置を計算
        Vector3 desiredPosition = target.position + offset;

        // 滑らかに移動
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
    }

    
}