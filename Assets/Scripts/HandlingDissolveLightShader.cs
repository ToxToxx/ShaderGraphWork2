using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HandlingDissolveLightShader : MonoBehaviour
{
    private const float MAX_TRESHOLD = 1;
    private const string TRESHOLD_KEY = "_Treshold"; //находится в окне шейдер графа
    private MeshRenderer _meshRenderer;

    private Coroutine _show;

    private void Awake()
    => _meshRenderer = GetComponent<MeshRenderer>();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if(_show != null)
                StopCoroutine(_show);

            _show = StartCoroutine(Show());
        }
    }

    private IEnumerator Show()
    {
        float treshold = 0;

        while (treshold < MAX_TRESHOLD)
        {
            treshold += Time.deltaTime;
            _meshRenderer.material.SetFloat(TRESHOLD_KEY, treshold);
            yield return null;
        }
    }
}
