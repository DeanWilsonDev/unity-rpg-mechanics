using System;
using System.Collections.Generic;

using UnityEngine;

namespace RPGMechanics.Debugging
{
    public class DebugDrawManager : MonoBehaviour
    {
        public static DebugDrawManager Instance { get; private set; }

        [SerializeField] private List<SphereGizmo> spheresToDraw = new();
        
        [Serializable]
        private struct SphereGizmo
        {
            public Vector3 Position;
            public float Radius;
            public Color Color;
        }


        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void DrawWireSphere(Vector3 position, float radius, Color color)
        {
            spheresToDraw.Add((new SphereGizmo { Position = position, Radius = radius, Color = color }));
        }

        private void OnDrawGizmos()
        {
            foreach (var sphere in spheresToDraw)
            {
                Gizmos.color = sphere.Color;
                Gizmos.DrawWireSphere(sphere.Position, sphere.Radius);
            }

            spheresToDraw.Clear();
        }
    }
}