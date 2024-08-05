using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public int Level;
    public float Radius;
    [SerializeField] private Transform visualTransform;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Transform spawnPos;
    [SerializeField] public Renderer _renderer;
    [SerializeField] private ballSettings ballSettings;
    [SerializeField] private Transform quad;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private creator _creator;

    public void SetLevel(int level)
    {
        Level = level;
        int number = (int)Mathf.Pow(2, level + 1);
        text.text = number.ToString();

        Radius = Mathf.Lerp(0.4f, 0.7f, level / 10f);
        Vector3 ballScale = Vector3.one * Radius * 2f;
        visualTransform.localScale = ballScale;
        
        _renderer.material = ballSettings.ballMaterials[level];
    }
    void Start()
    {
        
    }

    void Update()
    {
        
        Ray ray=new Ray(spawnPos.position,Vector3.down);
        RaycastHit hit;
        if (_creator.ballInSpawner == null) GetComponentInChildren<MeshRenderer>().enabled = false;
        else GetComponentInChildren<MeshRenderer>().enabled = true;
        if (Physics.SphereCast(ray,Radius,out hit, 20f, _layerMask, QueryTriggerInteraction.Ignore))
        {
            visualTransform.position = spawnPos.position + Vector3.down * hit.distance;
            quad.localScale = new Vector3(Radius * 2, spawnPos.position.y - visualTransform.position.y+1f, 1);
            quad.position = new Vector3(visualTransform.position.x, visualTransform.position.y+(spawnPos.position.y - visualTransform.position.y) / 2f,0);
        }
    }
    
}
