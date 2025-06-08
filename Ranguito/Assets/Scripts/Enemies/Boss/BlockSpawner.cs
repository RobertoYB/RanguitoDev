using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject greenBlockPrefab;
    public GameObject magentaBlockPrefab;
    public int blockCount = 0;
    public int blockLimit = 50;

    public void SpawnBlock()
    {
        if (blockCount <= blockLimit)
        {
            int randomColor = Random.Range(0, 2);
            GameObject block;
            if (randomColor == 0)
            {
                block = CreateBlock(greenBlockPrefab);
            }
            else
            {
                block = CreateBlock(magentaBlockPrefab);
            }

            Rigidbody2D rb = block.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(Random.Range(-7, 7), Random.Range(1, 3)), ForceMode2D.Impulse);
            blockCount++;
        }
    }

    public GameObject CreateBlock(GameObject blockPrefab)
    {
        return Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
    }
}
