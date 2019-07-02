using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//事件触发器 命名空间
using UnityEngine.EventSystems;

public class ClickButton : MonoBehaviour {

    public GameObject cube;

    public GameObject target;

	// Use this for initialization
	void Start () {

        //利用UIEventTrigger工具包中的UIEventTrigger方法 将脚本加到制定位置
        UIEventTrigger trigger = UIEventTrigger.Get(GameObject.Find("Button"));

        //UIEventTrigger为一个封装好的委托事件工具包 包含了Event事件的各个内容 需要时直接调用即可
        trigger.onPointerDown += OnDownButton;

    }

    // Update is called once per frame
    void Update()
    {

    }

        //UIEventTrigger中的onPointerClick方法有传入参数PointerEventData eventData
    public void OnDownButton(PointerEventData eventData)
    {
        GameObject CubePre = Instantiate(cube);
        Vector3 targetSpace = Camera.main.WorldToScreenPoint(target.transform.position);
        CubePre.transform.position= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetSpace.z));
    }
    
}
