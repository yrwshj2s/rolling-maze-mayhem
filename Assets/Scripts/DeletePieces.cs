using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePieces : MonoBehaviour
{
    public float deletionDelay = 0.5f;
    void Start()
    {
        StartCoroutine(DeleteChildrenRandomly());
    }

        private IEnumerator DeleteChildrenRandomly()
    {
        // Get the list of children
        List<Transform> children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        // Randomly delete children until none are left
        while (children.Count > 0)
        {
            // Pick a random child
            int randomIndex = Random.Range(0, children.Count);
            Transform childToDelete = children[randomIndex];

            // Delete the selected child
            Destroy(childToDelete.gameObject);
            children.RemoveAt(randomIndex);

            // Wait for a while before deleting the next child
            yield return new WaitForSeconds(deletionDelay);
        }
    }
}
