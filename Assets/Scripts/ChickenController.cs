using System.Collections;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    [SerializeField] private GameObject eggPreFabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpamEgg());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpamEgg()
    {
        while (true) {
            Instantiate(eggPreFabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4, 20));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
