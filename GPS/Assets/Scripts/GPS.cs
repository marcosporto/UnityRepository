using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public float longitude = 0.01f;
    public float latitude = 0.02f;

    public Text gpsText;

    private void Start()
    {
        if (Input.location.isEnabledByUser)
            StartCoroutine(GetLocation());
    }

    private IEnumerator GetLocation()
    {
        Input.location.Start();
        while(Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(0.5f);
        }
        longitude = Input.location.lastData.longitude;
        latitude = Input.location.lastData.latitude;
        yield break;

    }
    // Update is called once per frame
    private void Update()
    {
        longitude = Input.location.lastData.longitude;
        latitude = Input.location.lastData.latitude;
        gpsText.text = "Lat: " + latitude + "\nLon: " + longitude;
    }
}
