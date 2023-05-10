using System.Collections.Generic;
using UnityEngine;

public class CreateFloor : MonoBehaviour
{
    public int width = 10; // zeminin genişliği
    public int depth = 10; // zeminin derinliği
    public float height = 0.1f; // zeminin yüksekliği

    public List<GameObject> cubePrefabs; // küp örnekleri listesi

    public GameObject blackCubePrefab; // Siyah küp örneği
    private bool blackCubeUsed = false; // Siyah küp daha önce kullanıldı mı?

    void Start()
    {
        // Zeminin orta noktasını hesapla
        Vector3 center = new Vector3(width / 2, -height / 2, depth / 2);

        // Her bir küpü oluştur ve konumlandır
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                Vector3 position = new Vector3(x, 0, z) - center;
                GameObject cubePrefab;

                // Siyah küp daha önce kullanılmadıysa, seçilen küp Siyah küp olsun.
                if (!blackCubeUsed && Random.value < 0.1f)
                {
                    cubePrefab = blackCubePrefab;
                    blackCubeUsed = true;
                }
                else
                {
                    cubePrefab = cubePrefabs[Random.Range(0, cubePrefabs.Count)];
                }

                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cube.transform.localScale = new Vector3(1, height, 1);
            }
        }
    }
}
