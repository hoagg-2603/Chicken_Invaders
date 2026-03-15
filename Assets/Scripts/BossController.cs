using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject EggPrefab;
    [SerializeField] private float speed = 2f;
    [SerializeField] private int health;
    [SerializeField] private GameObject VFX;

    public static BossController instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpamEgg());
        StartCoroutine(MoveBossToRandomPiont());
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Phá hủy Boss

            // 1. Gán bản sao của hiệu ứng vừa tạo vào một biến tạm tên là vfxClone
            GameObject vfxClone = Instantiate(VFX, transform.position, Quaternion.identity);

            // 2. Phá hủy bản sao (vfxClone) sau 1 giây, thay vì phá hủy Prefab gốc (VFX)
            Destroy(vfxClone, 1f);
        }
    }

    IEnumerator SpamEgg()
    {
        while (true)
        {
            Instantiate(EggPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0, 1f));
        }
    }

    IEnumerator MoveBossToRandomPiont()
    {
        Vector3 point = GetRandomPoint();
        while (transform.position != point)
        {
            transform.position = Vector3.MoveTowards(transform.position,point, speed * Time.fixedDeltaTime);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        } 
        StartCoroutine(MoveBossToRandomPiont());
    }

    Vector3 GetRandomPoint()
    {
        Vector3 posRandom = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0.5f, 1)));
        posRandom.z = 0;
        return posRandom;
    }
}
