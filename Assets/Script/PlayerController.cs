using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 5f;          // 移動速度
    public float rotationSpeed = 10f;     // 回転の滑らかさ

    private CharacterController controller;

    void Start()
    {
        // CharacterControllerが付いていなければ追加
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            controller = gameObject.AddComponent<CharacterController>();
            controller.height = 2f;
            controller.radius = 0.5f;
            controller.center = new Vector3(0, 1f, 0);
        }
    }

    void Update()
    {
        // WASD入力を取得
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        // カメラの向きを基準に移動方向を計算（推奨）
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * v + cameraRight * h;

        if (moveDirection.magnitude > 0.1f)
        {
            // 移動
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            // 進行方向に滑らかに回転
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}