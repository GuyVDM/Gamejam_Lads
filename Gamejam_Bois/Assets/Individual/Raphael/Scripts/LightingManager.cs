using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour {

    public Light directionalLight;

    public void StartBlackOut()
    {
        StartCoroutine(BlackOut());
    }

    public IEnumerator BlackOut()
    {
        yield return new WaitForSeconds(5);

        ToggleLight(directionalLight, false);
    }


    private void ToggleLight(Light toToggle, bool toggle)
    {
        toToggle.enabled = toggle;
    }
}
