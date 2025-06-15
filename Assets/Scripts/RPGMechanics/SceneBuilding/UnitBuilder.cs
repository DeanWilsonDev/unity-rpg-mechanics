using System;

using RPGMechanics.Characters.Enemies;

using UnityEngine;

namespace RPGMechanics.SceneBuilding
{
    public static class UnitBuilder
    {
        public static GameObject BuildEnemy()
        {
            var go = new GameObject("Enemy");

            var enemy = go.AddComponent<Enemy>();
            var renderer = go.AddComponent<MeshRenderer>();
            var filter = go.AddComponent<MeshFilter>();

            filter.mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
            renderer.material = new Material(Shader.Find("Standard"));

            go.tag = "Enemy";
            go.layer = Convert.ToInt32("Enemy");

            return go;
        }
        
    }
}