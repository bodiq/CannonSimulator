using UnityEngine;

namespace Projectile
{
    public class ProjectileMeshGenerator : MonoBehaviour
    {
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private float radius = 0.5f;
        [SerializeField] private float randomRange = 0.05f;

        public void SetRandomMesh()
        {
            meshFilter.mesh = GenerateMesh();
        }

        private Mesh GenerateMesh()
        {
            var mesh = meshFilter.mesh;
            var vertices = mesh.vertices;

            for (var i = 0; i < vertices.Length; i++)
            {
                vertices[i] = vertices[i] * radius + new Vector3(
                    Random.Range(-randomRange, randomRange),
                    Random.Range(-randomRange, randomRange),
                    Random.Range(-randomRange, randomRange)
                );
            }

            mesh.vertices = vertices;
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}