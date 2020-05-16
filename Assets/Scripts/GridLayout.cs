using UnityEngine;
using System.Collections;

public class GridLayout : MonoBehaviour
{
    public Transform spawnThis;

    public int x = 5;
    public int y = 5;

    public float radius = 0.5f;
    public bool useAsInnerCircleRadius = true;

    private float offsetX, offsetY;

    void Start()
    {
        float unitLength = (useAsInnerCircleRadius) ? (radius / (Mathf.Sqrt(3) / 2)) : radius;

        offsetX = unitLength * Mathf.Sqrt(3);
        offsetY = unitLength * 1.5f;

        for (int i = 0; i < x; i++)
        { 
             for (int j = 0; j < y; j++)
                {
                    Vector2 hexpos = HexOffset(i, j);
                    Vector3 pos = new Vector3(hexpos.x, hexpos.y, 0);
                    Instantiate(spawnThis, pos, Quaternion.identity);
                }
            
            }
        }

    Vector2 HexOffset(int x, int y)
    {
        Vector2 position = Vector2.zero;

        if (y % 2 == 0)
        {
            position.x = x * offsetX;
            position.y = y * offsetY;
        }
        else
        {
            position.x = (x + 0.5f) * offsetX;
            position.y = y * offsetY;
        }

        return position;
    }
}
