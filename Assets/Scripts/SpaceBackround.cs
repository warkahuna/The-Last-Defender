using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectInfo
{
    public Texture texture;
    public int randomWeight;
    public int count;
    public float minSizze, maxSize;
    public Color colo1, color2;
    public int depth;
    public int brightness;

  

}

public class SpaceBackround : MonoBehaviour
{
    private GameObject prefab, spaceObjectContainer, backgroundContainer,spaceObjectLight;
    public ObjectInfo[] objectInfo;
    public int spaceObjectCount ;
    

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("Prefabs/space object") as GameObject;
        spaceObjectLight = Resources.Load("Space Object Light") as GameObject;
        spaceObjectContainer = new GameObject("space objects");
        backgroundContainer = GameObject.FindGameObjectWithTag("background");
        foreach(ObjectInfo oi in objectInfo)
        { 
            if(oi.count>0)
                for (int i = 0; i < oi.count; i++)
                    MakeSpaceObject(oi);
        }
        for (int i = 0; i < spaceObjectCount ; i++)
            MakeSpaceObject(GetRandomObjectInfo());
    }

    private ObjectInfo GetRandomObjectInfo()
    {
        int totalWeight = 0;
        foreach(ObjectInfo oi in objectInfo)
        {
            totalWeight += oi.randomWeight;
        }
        int r = Random.Range(0, totalWeight);
        int indexSoFar = 0;
        foreach(ObjectInfo oi in objectInfo)
        {
            indexSoFar += oi.randomWeight;
            if (r < indexSoFar)
                return oi;
        }
        return null;
    }
        private void MakeSpaceObject(ObjectInfo oi)
    {
        Vector3 position =  Random.onUnitSphere * (10+oi.depth+Random.Range(0,0.5f));
        GameObject newSpaceObject = Instantiate(prefab, position, Quaternion.identity) as GameObject;
        newSpaceObject.transform.parent = spaceObjectContainer.transform;
        newSpaceObject.transform.LookAt(backgroundContainer.transform.position);
        Material mat = newSpaceObject.transform.GetChild(0).GetComponent<MeshRenderer>().material;
        mat.SetTexture(0, oi.texture); 
        Color newColor = Color.Lerp(oi.colo1, oi.color2, Random.Range(0f, 1f));
        newColor.a = 1; 
        mat.color = newColor;


        float newSize = Random.Range(oi.minSizze, oi.maxSize);
        newSpaceObject.transform.localScale = new Vector3(newSize, newSize, newSize);
        if (oi.brightness > 0)
        {
            GameObject newLight = Instantiate(spaceObjectLight, position, Quaternion.identity) as GameObject;
            Light light = newLight.GetComponent<Light>();
            light.color = newColor;
            light.intensity = oi.brightness;
            newLight.transform.LookAt(Vector3.zero);
        }
    }

    private void Update()
    {
        spaceObjectContainer.transform.position = backgroundContainer.transform.position;
    }
}
