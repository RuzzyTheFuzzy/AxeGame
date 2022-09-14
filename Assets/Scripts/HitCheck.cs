using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{

    [SerializeField] private Transform capsule;
    private void OnDrawGizmosSelected()
    {
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);
        Gizmos.color = transparentRed;
        Vector3 centerForward = new Vector3(0, 0, 0);
        centerForward.z += capsule.lossyScale.z;
        Gizmos.matrix = Matrix4x4.TRS(capsule.position, capsule.rotation, capsule.lossyScale);
        Gizmos.DrawCube(centerForward, capsule.lossyScale);
    }

    public void Hit()
    {
        // Matrix so that OverlapBox it correctly placed and rotated
        Matrix4x4 capsuleMatrix = Matrix4x4.TRS(capsule.position, capsule.rotation, capsule.lossyScale);

        Vector3 centerForward = new Vector3(0, 0, capsule.lossyScale.z);
        centerForward = capsuleMatrix.MultiplyPoint3x4(centerForward);

        Collider[] collitions = Physics.OverlapBox(centerForward, capsule.lossyScale / 2, capsule.rotation);

        foreach (Collider collider in collitions)
        {
            if (collider.transform.GetInstanceID() != capsule.GetInstanceID())
            {
                Player player;
                Tree tree;
                if (collider.TryGetComponent<Player>(out player)) player.Hit();
                if (collider.TryGetComponent<Tree>(out tree)) tree.Chopped();
            }
        }
    }
}
