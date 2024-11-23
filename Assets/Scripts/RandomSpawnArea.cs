using UnityEngine;

public class RandomSpawnArea : MonoBehaviour
{
    [Header("Box Dimensions")]
    public float width = 5f;
    public float depth = 5f; // Changed "height" to "depth" for Z-axis alignment.

    [Header("Box Offset")]
    public Vector3 offset = Vector3.zero;

    [Header("Gizmo Settings")]
    public Color gizmoColor = Color.green;

    /// <summary>
    /// Gets a random position within the defined box area.
    /// </summary>
    public Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-width / 2, width / 2);
        float randomZ = Random.Range(-depth / 2, depth / 2);
        return transform.position + offset + new Vector3(randomX, 0, randomZ);
    }

    private void OnDrawGizmos()
    {
        // Set the Gizmo color
        Gizmos.color = gizmoColor;

        // Calculate the corners of the box
        Vector3 bottomLeft = transform.position + offset + new Vector3(-width / 2, 0, -depth / 2);
        Vector3 bottomRight = transform.position + offset + new Vector3(width / 2, 0, -depth / 2);
        Vector3 topLeft = transform.position + offset + new Vector3(-width / 2, 0, depth / 2);
        Vector3 topRight = transform.position + offset + new Vector3(width / 2, 0, depth / 2);

        // Draw the box using lines
        Gizmos.DrawLine(bottomLeft, bottomRight);
        Gizmos.DrawLine(bottomRight, topRight);
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topLeft, bottomLeft);
    }
}
