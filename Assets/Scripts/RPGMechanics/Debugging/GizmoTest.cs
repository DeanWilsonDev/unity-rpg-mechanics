using UnityEngine;

namespace RPGMechanics.Debugging
{
    public class GizmoTest : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position + Vector3.up * 2f, 1f);
        }
    }
}