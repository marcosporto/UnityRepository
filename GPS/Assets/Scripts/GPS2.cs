using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GPS2 : MonoBehaviour
{
    public Text statusTxt;
    public void GetUserLocation()
    {
        if (!Input.location.isEnabledByUser) //FIRST IM CHACKING FOR PERMISSION IF "true" IT MEANS USER GAVED PERMISSION FOR USING LOCATION INFORMATION
        {
            statusTxt.text = "No Permission";
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        else
        {
            statusTxt.text = "Ok Permission";
            StartCoroutine("GetLatLonUsingGPS");
        }
    }

    IEnumerator GetLatLonUsingGPS()
    {
        Input.location.Start();
        int maxWait = 5;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            statusTxt.text = "Failed To Iniyilize in 10 seconds";
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            statusTxt.text = "Failed To Initialize";
            yield break;
        }
        else
        {
            statusTxt.text = "waiting before getting lat and lon";
            // yield return new WaitForSeconds(5);
            // Access granted and location value could be retrieve
            double longitude = Input.location.lastData.longitude;
            double latitude = Input.location.lastData.latitude;

            AddLocation(latitude, longitude);
            statusTxt.text = "" + Input.location.status + "  lat:" + latitude + "  long:" + longitude;
        }
        //Stop retrieving location
        Input.location.Stop();
        StopCoroutine("Start");
    }

}
