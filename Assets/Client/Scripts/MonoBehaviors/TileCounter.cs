using UnityEngine;
using UnityEngine.Tilemaps;

namespace Client.Scripts.MonoBehaviors
{
    public class TileCounter
    {
        public static int GetTileAmountTiles(TileBase targetTile, Tilemap tilemap)
        {
            int amount = 0;
            BoundsInt bounds = tilemap.cellBounds;

            foreach (Vector3Int pos in bounds.allPositionsWithin)
            {
                TileBase tile = tilemap.GetTile(pos);
                if (tile != null)
                {
                    if (tile == targetTile)
                    {
                        amount += 1;
                    }
                }
            }

            return amount;
        }
    }
}
