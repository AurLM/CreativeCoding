using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DifferentShapes : MonoBehaviour
{

    public enum ShapeType {Sphere,Cube,Torus};
    public enum Operation {None, Blend, Cut,Mask}

    public GameObject emptyObject;
    public int timerMax;
    private int timer;
    
    public ShapeType shapeType;
    public Operation operation;
    public Color colour = Color.white;
    [Range(0,1)]
    public float blendStrength;
    [HideInInspector]
    public int numChildren;

    public Vector3 Position {
        get {
            return transform.position;
        }
    }

    public Vector3 Scale {
        get {
            Vector3 parentScale = Vector3.one;
            if (transform.parent != null && transform.parent.GetComponent<DifferentShapes>() != null) {
                parentScale = transform.parent.GetComponent<DifferentShapes>().Scale;
            }
            return Vector3.Scale(transform.localScale, parentScale);
        }
    }

    public void Start()
    {
        StartCoroutine(CreateMore());
    }

    IEnumerator CreateMore()
    {
        timer = timerMax;
            
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);

            timer--;

            if (timer <= 0)
            {
                Vector3 position = new Vector3(Random.Range(-1f, 2f), Random.Range(-1f, 2f), Random.Range(-1f, 2f));
                Instantiate(emptyObject, position+gameObject.transform.position, Quaternion.identity);
                gameObject.GetComponent<DifferentShapes>().enabled = false;
                yield break;
            }
        }
    }
}