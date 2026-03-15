using UnityEngine;

public class Swapner : MonoBehaviour
{
    private float gridSize =1;
    private Vector3 spawnPos;
    private int ChickenCurrent;
    [SerializeField] private GameObject chickenPrefabs;
    [SerializeField] private Transform gridChiken;
    [SerializeField] private GameObject boss;
    public static Swapner instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width/Screen.height;

        spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 10));

        // 3. Dịch chuyển spawnPos sang trái một nửa độ rộng của lưới gà để nó nằm chính giữa
        // Giả sử bạn muốn hàng gà rộng khoảng 'numberChicken * gridSize'
        // Ở đây mình tạm dịch sang trái để bắt đầu vẽ từ trái sang phải
        float totalWidthOfGrid = (width / 1.5f); // Tỉ lệ bạn đã dùng ở hàm SpawnChicken
        spawnPos.x -= totalWidthOfGrid / 2;
        spawnPos.y -= gridSize; // Cách mép trên một khoảng
        spawnPos.z = 0;

        SpawnChicken(Mathf.FloorToInt(height / 2 / gridSize), Mathf.FloorToInt(width / gridSize / 1.5f));
    }

    void SpawnChicken(int row, int numberChicken)
    {
        float x = spawnPos.x;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < numberChicken; j++)
            {
                spawnPos.x = spawnPos.x + gridSize;
                GameObject chicken = Instantiate(chickenPrefabs, spawnPos, Quaternion.identity);
                chicken.transform.parent = gridChiken;
                ChickenCurrent++;
            }
            spawnPos.x = x;
            spawnPos.y -= gridSize;
        }
    }

    public void DecreaChicken()
    {
        ChickenCurrent--;
        if(ChickenCurrent <= 0)
        {
            boss.gameObject.SetActive(true);
        }
    }
}
