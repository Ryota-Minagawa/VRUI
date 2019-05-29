using UnityEngine;
using System.Linq;
using UnityEditor.Experimental.UIElements.GraphView;

public class RayController : MonoBehaviour
{

    [SerializeField] private GameObject diveCamera;
    private ISelectableByRay iselectable;

    void Update()
    {

        Ray ray = new Ray(diveCamera.transform.position, diveCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 0.1f, false);
            
            if (hit.collider.transform.parent.gameObject.GetComponent<ISelectableByRay>()!=null)
            {
                iselectable = hit.collider.gameObject.transform.parent.GetComponent<ISelectableByRay>();
                iselectable.RayEnter();
            }
                
        }
        else
        {
            // これ一回iselectableをキャッシュしたら二度とnullにならないような？
            //→最初のキャッシュまでに何も当たってないとエラーが出ます
            if (iselectable != null) iselectable.RayExit();
        }
    }
}









