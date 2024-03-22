using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class PatrolPath : MonoBehaviour
    {
        [Tooltip("Enemies that will be assigned to this path on Start")]
        public List<EnemyController> Enemies = new List<EnemyController>();

        [Tooltip("The Nodes making up the path")]
        public List<Transform> Points = new List<Transform>();

        void Start()
        {
            foreach (var enemy in Enemies)
            {
                enemy.PatrolPath = this;
            }
        }

        public float GetDistanceToNode(Vector3 origin, int destinationNodeIndex)
        {
            if (destinationNodeIndex < 0 || destinationNodeIndex >= Points.Count ||
                Points[destinationNodeIndex] == null)
            {
                return -1f;
            }

            return (Points[destinationNodeIndex].position - origin).magnitude;
        }

        public Vector3 GetPositionOfPathNode(int nodeIndex)
        {
            if (nodeIndex < 0 || nodeIndex >= Points.Count || Points[nodeIndex] == null)
            {
                return Vector3.zero;
            }

            return Points[nodeIndex].position;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            for (int i = 0; i < Points.Count; i++)
            {
                int nextIndex = i + 1;
                if (nextIndex >= Points.Count)
                {
                    nextIndex -= Points.Count;
                }

                Gizmos.DrawLine(Points[i].position, Points[nextIndex].position);
                Gizmos.DrawSphere(Points[i].position, 0.1f);
            }
        }
    }
}
