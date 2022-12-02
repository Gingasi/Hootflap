using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCG_RepeatBackground : MonoBehaviour
{
    public GameObject[] Levels;
    private Camera MainCamera;
    private Vector2 ScreenBound;
    public float Repeat;

    void Start()
    {
        MainCamera = gameObject.GetComponent<Camera>();
        ScreenBound = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        foreach (GameObject obj in Levels)
        {
            LoadBackGround(obj);
        }
    }

    void LoadBackGround(GameObject obj)
    {
        float ObjectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - Repeat;
        int ChildisNeeded = (int)Mathf.Ceil(ScreenBound.x * 2 / ObjectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= ChildisNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(ObjectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }

        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void MirrorBackground(GameObject obj)
    {
        Transform[] Children = obj.GetComponentsInChildren<Transform>();
        if (Children.Length > 1)
        {
            GameObject firstChild = Children[0].gameObject;
            GameObject lastChild = Children[Children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - Repeat;
            if(transform.position.x + ScreenBound.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - ScreenBound.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void LateUpload()
    {
        foreach(GameObject obj in Levels)
        {
            MirrorBackground(obj);
        }
        
      
    }
}
