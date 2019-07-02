using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickButton : MonoBehaviour {

    public GameObject Cube;

    public GameObject Target;

    private Button _btnCreate;


	void Start () {

	    _btnCreate = GameObject.Find("Button").GetComponent<Button>();
		_btnCreate.AddListener(EventTriggerType.PointerDown,OnDownButton);

	}

    public void OnDownButton(BaseEventData baseEventData)
    {
        GameObject cubePre = Instantiate(Cube);
	    if (Camera.main != null)
	    {
		    Vector3 targetSpace = Camera.main.WorldToScreenPoint(Target.transform.position);
		    cubePre.transform.position= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetSpace.z));
	    }
    }
    
}
