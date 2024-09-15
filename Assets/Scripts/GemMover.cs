using UnityEngine;

public class GemMover : MonoBehaviour
{
    /*
    * khai báo biến tốc độ là một số thực có giá trị bằng 5.
    * Public sẽ cho phép ta truy cập giá trị speed từ UnityEditor
    */
    public float speed = 5f;
    public int score = 1; 
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
            ScoreManager.AddScore(score);
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

//void SpawnGem()
//{
//    /* Khai báo và tạo một biến có giá trị ngẫu nhiên trong khoảng màn hình trước khi tạo gem mới. 
//    * Biến này đóng vai trò là tọa độ X (ngang) mới.
//    */
//    float randomX = Random.Range(-8f, 8f); //Màn hình rộng 16 point nên lề trái là -8 và biên phải là 8
//                                           //Khai báo một biến tọa độ vị trí và lưu giá trị tọa độ trên
//    Vector3 spawnPosition = new Vector3(randomX, 6f, 0); // Đưa biến số này vào Vector3, để tạo tọa độ vị trí mới

//    //Đưa tọa độ này vào function (hàm) Instantiate để tạo và thả viên gem mới
//    Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
//}

