using UnityEngine;
using System.Collections;

public class CubeDragScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
        StartCoroutine(OnMouseDown());
    }
	

    IEnumerator OnMouseDown()
    {
        if (Camera.main != null)
        {
            //三维物体世界坐标转屏幕坐标  
            Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);

            //完成两个步骤 1.由于鼠标的坐标系是2维，需要转换成3维的世界坐标系  

            //            2.只有3维坐标情况下才能来计算鼠标位置与物理的距离，offset即是差值

            //将鼠标屏幕坐标转为世界三维坐标，转换前的屏幕Z值套用Cube转换过得Z值，再算出Cube世界坐标与鼠标世界坐标的差值

            Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
        
            while (Input.GetMouseButton(0))

            {
           
                Camera.main.GetComponent<MouseOrbit>().enabled = false;
                
                //得到现在鼠标的屏幕坐标
                Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

                //物体的位置就是鼠标的世界坐标 + 差值
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

                transform.position = curPosition;
                //这个很重要，循环执行
                yield return null; 

            }
        }

        if (Camera.main != null) Camera.main.GetComponent<MouseOrbit>().enabled = true;
    }



}
