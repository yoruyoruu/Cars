using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaceScript : MonoBehaviour
{
   public GameObject building;

   public void PlaceBuild()
   {
    Instantiate (building, Vector3.zero, Quaternion.identity);
   }
    
}
