using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    private ParticleSystem ps;
    private bool isRain = false;

    public Light dirLight;

    private void Start() 
    {
        ps = GetComponent <ParticleSystem>();
        StartCoroutine(Weather());
    }

    private void Update() 
    {
        if (isRain && dirLight.intensity > 0.25f)
        {
            LightIntensity (-1);
        } 
        else if (!isRain && dirLight.intensity < 1f)
        {
            LightIntensity (1);
        }
    }

    private void LightIntensity (int i)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * i;
    }

    IEnumerator Weather()
    {
        while(true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(25f, 45f));


            if (isRain)
            {
                ps.Stop();
            }
            else
            {
                ps.Play();
            }

            isRain = !isRain;
        }
    }


}
