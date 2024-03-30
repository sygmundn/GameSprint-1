using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour

{
    void OnDrawGizmos()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        Gizmos.color = Color.red;
        foreach (Collider2D collider in colliders)
        {
            Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
        }
    }

}
