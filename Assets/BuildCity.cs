using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour {
	public GameObject[] buildings;
	public GameObject xstreets;
	public GameObject zstreets;
	public GameObject crossroad;
	public GameObject downLight;

	int[,] mapgrid;

	public int mapWidth = 20;
	public int mapHeight = 20;
	int buildingFootprint = 3;
	// Use this for initialization
	void Start () {
		mapgrid = new int [mapWidth,mapHeight];

		float seed = Random.Range(0,100);
		for(int h=0;h<mapHeight;h++){
			for(int w=0;w<mapWidth;w++){
				mapgrid[w,h] = (int) (Mathf.PerlinNoise(w/20.0f+seed,h/20.0f+seed) * 10);
			}
		}
		for(int x=0;x<mapWidth;x+=Random.Range(2,5)){
			for(int h = 0; h < mapHeight;h++){
				mapgrid[x,h] = -1;
			}
		}
		for(int z=0;z<mapHeight;z+=Random.Range(2,5)){
			for(int w = 0; w < mapWidth;w++){
				if(mapgrid[w,z] == -1){
					mapgrid[w,z] = -3;
				}else{
					mapgrid[w,z] = -2;
				}
			}
		}
		Debug.Log(mapgrid);
		for(int h=0;h<mapHeight;h++){
			for(int w=0;w<mapWidth;w++){
				int result = mapgrid[w,h];
				Vector3 pos = new Vector3(w * buildingFootprint,(result== -1||result== -2)?0.045f:0,h*buildingFootprint);
				
				if(result < -2){
					Instantiate(crossroad,pos,crossroad.transform.rotation);
					Instantiate(
						downLight,
						new Vector3(w * buildingFootprint,1,h*buildingFootprint),
						downLight.transform.rotation
					);
				}else if(result < -1){
					Instantiate(xstreets,pos,xstreets.transform.rotation);
				}
				else if(result < 0){
					Instantiate(zstreets,pos,zstreets.transform.rotation);}
				else if(result < 2)
					{Instantiate(buildings[0],pos,Quaternion.identity);}
				else if(result < 4)
					{Instantiate(buildings[1],pos,Quaternion.identity);}
				else if(result < 6)
					{Instantiate(buildings[2],pos,Quaternion.identity);}
				else if(result < 7)
					{Instantiate(buildings[3],pos,Quaternion.identity);}
				else if(result < 8)
					{Instantiate(buildings[4],pos,Quaternion.identity);}
				else if(result < 10)
					{Instantiate(buildings[5],pos,Quaternion.identity);}
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
