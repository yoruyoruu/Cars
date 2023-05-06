using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class selectController : MonoBehaviour
{
    public GameObject cube;
    public List <GameObject> players;
    public LayerMask layer, layerMask;
    private Camera cam;
    private GameObject cubeSelection;
    private RaycastHit hit;

     private void Awake() 
    {
        cam = GetComponent<Camera>();
    }


     private void Update() 
    {
        if (Input.GetMouseButtonDown(1) && players.Count > 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, layer))
                
                foreach (var el in players)
                el.GetComponent<NavMeshAgent>().SetDestination(agentTarget.point);
                    
        }



        if(Input.GetMouseButtonDown(0))
        {
            foreach (var el in players)
                el.transform.GetChild(0).gameObject.SetActive(false);
        
            players.Clear();

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f, layer))
            {
                cubeSelection = Instantiate(cube, new Vector3(hit.point.x, 1, hit.point.z),Quaternion.identity);
            }
        
        }


        if(cubeSelection)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitdrag, 1000f, layer))
            {
                float xScale = (hit.point.x - hitdrag.point.x)*-1; 
                float zScale = hit.point.z - hitdrag.point.z;

                if(xScale<0.0f && zScale<0.0f)
                    cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0,180,0));

                cubeSelection.transform.localScale= new Vector3 ( Mathf.Abs(xScale), 1 ,Mathf.Abs(zScale));
            }
        }


        if(Input.GetMouseButtonUp(0) && cubeSelection)
        {
            RaycastHit[] hits = Physics.BoxCastAll(
                cubeSelection.transform.position,
                cubeSelection.transform.localScale,
                Vector3.up,
                Quaternion.identity,
                0,
                layerMask); 

                foreach (var el in hits)
                {
                    if(el.collider.CompareTag("enemy")) continue;

                    players.Add(el.transform.gameObject);
                    el.transform.GetChild(0).gameObject.SetActive(true);
                }
                  

            Destroy(cubeSelection);
        }
    }


}
