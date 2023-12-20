using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    //[SerializeField] private List<MeshFilter> sourceMeshFilters;
    //[SerializeField] private MeshFilter targetMeshFilter;
    [SerializeField] private MeshFilter[] meshFilters;
    private void Start()
    {
        meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        Mesh mesh = new Mesh();
        mesh.CombineMeshes(combine);
        transform.GetComponent<MeshFilter>().sharedMesh = mesh;
        transform.gameObject.SetActive(true);
    }
    //[ContextMenu("Combine Meshes")]
    //private void CombineMeshes()
    //{
    //    var combine = new CombineInstance[sourceMeshFilters.Count];

    //    for (var i = 0; i < sourceMeshFilters.Count; i++)
    //    {
    //        combine[i].mesh = sourceMeshFilters[i].sharedMesh; // sharedMesh 가 뭘까요?
    //        combine[i].transform = sourceMeshFilters[i].transform.localToWorldMatrix; //로컬에서 월드 매트릭스로 ? 
    //    }

    //    var mesh = new Mesh();
    //    mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
    //    mesh.CombineMeshes(combine);
    //    targetMeshFilter.mesh = mesh;
    //}



}
