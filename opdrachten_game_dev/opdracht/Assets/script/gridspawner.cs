using UnityEngine;
using UnityEngine.Tilemaps;

public class gridspawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Tilemap groundTilemap;

    public int spawnAttempts = 20;

    public int gridXMin = -12;
    public int gridXMax = 12;
    public int gridYMin = -5;
    public int gridYMax = 5;

    public void SpawnCoin()
    {
        for (int i = 0; i < spawnAttempts; i++)
        {
            Vector3Int randomCell = new Vector3Int(
                Random.Range(gridXMin, gridXMax + 1),
                Random.Range(gridYMin, gridYMax + 1),
                0
            );

            // Check of er GEEN ground tile is op deze plek
            if (!groundTilemap.HasTile(randomCell))
            {
                Vector3 worldPos = groundTilemap.CellToWorld(randomCell) + new Vector3(0.5f, 0.5f, 0); // centreren
                Instantiate(coinPrefab, worldPos, Quaternion.identity);
                return;
            }
        }

        Debug.LogWarning("Kon geen lege tegel vinden om een coin te spawnen.");
    }
}