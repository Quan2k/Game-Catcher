using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speed = 5f;
    public int characterSpeedboost = 10;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); //tạo chuyển động theo phương thẳng đứng hướng xuống với tốc độ trên theo thời gian
    }

    void OnTriggerEnter2D(Collider2D other) //other chính là thông tin của bất kỳ collider nào va chạm với collider này
    {
        // thiết lập điều kiện kiểm tra thông tin của OTHER
        if (other.gameObject.CompareTag("Player"))
        // nếu, phương thức so sánh gameobject tag của other với nhãn "Player" là đúng
        { // thì
            CharacterMovement.AddSpeed(characterSpeedboost);
            Destroy(gameObject); //xóa gameObject đang gắn collider này. (Không phải là other)
                                 //nghĩa là xóa viên ngọc này, không phải xóa người chơi đang va chạm
        }
        else if (other.gameObject.CompareTag("Ground")) // còn không thì, nếu là mặt đất,
        { // thì
            //ScoreManager.AddScore(-score);
            Destroy(gameObject); //xóa gameObject đang gắn collider này. (Không phải là other)
                                 //nghĩa là xóa viên ngọc này, không phải xóa mặt đất
        }
    }
}
