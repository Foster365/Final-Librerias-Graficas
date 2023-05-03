using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] Material material;

    float dissolveAmount;
    bool isDissolving;

    // Update is called once per frame
    void Update()
    {
        if (isDissolving)
        {
            //dissolveAmount = Mathf.Clamp01(dissolveAmount += Time.deltaTime);
            material.SetVector("_remapModifier", new Vector2(0, 1)); //Se disuelve
        }
        else
        {
            material.SetVector("_remapModifier", new Vector2(1, 1)); //No se disuelve
        }

        if (Input.GetKeyDown(KeyCode.X)) isDissolving = true;
        else if (Input.GetKeyDown(KeyCode.Z)) isDissolving = false;
    }
}
