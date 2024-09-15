// GemFallScript - Phiên bản cơ bản
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine; // Sử dụng các tính năng được định nghĩa trong UnityEngine

public class GemFallScript : MonoBehaviour
{
    // Khai bao bien de chua prefab cua vien ngoc do.
    public List<GameObject> GemListPrefab;
    // Khai báo biến để chứa prefab của viên ngọc. Đây sẽ là đối tượng mà chúng ta sẽ tạo ra trong trò chơi.
    public List<GameObject> GemDebuffPrefab;
    // Biến đếm thời gian kể từ lần sinh viên ngọc cuối cùng.
    public float timer;
    // Khoảng thời gian (tính bằng giây) giữa mỗi lần sinh viên ngọc mới.
    public float spawnInterval = 3f; //tần suất spawn: 3 giây / 1 gem

    void Update()
    {
        // Cộng dồn thời gian từ lần cuối cập nhật đến bây giờ vào biến timer.
        timer += Time.deltaTime;
        // Kiểm tra nếu thời gian đã đủ lớn bằng hoặc lớn hơn khoảng thời gian sinh viên ngọc.
        if (timer >= spawnInterval)
        {
            SpawnGem(); // Gọi hàm sinh viên ngọc.
            timer = 0; // Đặt lại biến đếm thời gian.
        }
    }

    void SpawnGem()
    {
        /* Khai báo và tạo một biến có giá trị ngẫu nhiên trong khoảng màn hình trước khi tạo gem mới. 
        * Biến này đóng vai trò là tọa độ X (ngang) mới.
        */
        float randomX = Random.Range(-5f, 5f); //Màn hình rộng 16 point nên lề trái là -8 và biên phải là 8
                                                 //Khai báo một biến tọa độ vị trí và lưu giá trị tọa độ trên
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0); // Đưa biến số này vào Vector3, để tạo tọa độ vị trí mới

        //Đưa tọa độ này vào function (hàm) Instantiate để tạo và thả viên gem mới
        int ramdomNumber = Random.Range(0, 4);
        // float ramdomNumber = Random.Range(1, 2);

        Instantiate(GemListPrefab[ramdomNumber], spawnPosition, Quaternion.identity);

        //if (ramdomNumber == 1)
        //{
        //    Instantiate(GemListPrefab[0], spawnPosition, Quaternion.identity);
        //}
        //else if (ramdomNumber == 2)
        //{
        //    Instantiate(GemListPrefab[1], spawnPosition, Quaternion.identity);
        //}
        //else if (ramdomNumber == 3)
        //{
        //    Instantiate(GemDebuffPrefab[2], spawnPosition, Quaternion.identity);
        //}
        //else if (ramdomNumber == 4)
        //{
        //    Instantiate(GemDebuffPrefab[3], spawnPosition, Quaternion.identity);
        //}
        //    {
        //    // Tạo ra viên ngọc tại vị trí cố định ở trên màn hình. 
        //    Vector3 spawnPosition = new Vector3(0f, 6f, 0); //Vector3(tọa độ x, tọa độ y và chiều sâu z)

        //// Sử dụng Instantiate để tạo ra một bản sao của prefab viên ngọc tại vị trí và hướng quy định.
        //Instantiate(gemPrefab, spawnPosition, Quaternion.identity); // Instantiate(Object nào, vị trí nào, không có hướng quay)
        //    }
        //    Random.Range(1, 10);Chi lay tu 1 den 9
    }
}
