using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check the contact points to determine which part of the collider was hit
        foreach (ContactPoint contact in collision.contacts)
        {
            // Check the position of the contact point
            if (IsPointInCollider(contact.point, "BoxCollider1"))
            {
                Debug.Log("Image landed on Box Collider 1");
            }
            else if (IsPointInCollider(contact.point, "BoxCollider2"))
            {
                Debug.Log("Image landed on Box Collider 2");
            }
            else if (IsPointInCollider(contact.point, "BoxCollider3"))
            {
                Debug.Log("Image landed on Box Collider 3");
            }
        }
    }

    private bool IsPointInCollider(Vector3 point, string colliderTag)
    {
        // Use Physics.OverlapBox to check if a point is inside a specific box collider
        Collider[] colliders = Physics.OverlapBox(point, Vector3.one * 0.1f); // Adjust the size as needed

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(colliderTag))
            {
                return true;
            }
        }

        return false;
    }
}