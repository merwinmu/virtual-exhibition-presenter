using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField] private string selectableTag = "FarisTag";
    [SerializeField] private Material highlightedMaterial;
    //[SerializeField] private Material defaultMaterial;

    private Transform _selection;
    public Image button;
    public Image point;
    private UnityEngine.Color original;
    private PickUp grab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        button.gameObject.SetActive(false);
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.color = original;
            _selection = null;

        }
        
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    original = selectionRenderer.material.GetColor("_Color");
                    selectionRenderer.material = highlightedMaterial;
                    button.gameObject.SetActive(true);
                }
                

                _selection = selection;
            }
        }
    }
}
