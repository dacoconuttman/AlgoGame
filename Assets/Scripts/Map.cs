using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public GameObject enemy;

	public Transform left;
	public Transform right;
	public Transform enemySpawnTransform;
	public Transform destinationTransform;

	public Node destinationNode;
	public Node enemySpawnNode;

	public int size_x;
	public int size_y;
	public Vector2 nodeSize;

	public Node[,] nodes;

	public Texture gridTexture;

	private ObjectManager _ObjectManager;

	void Start () {
		_ObjectManager = ObjectManager.getInstance ();
		destinationNode = GetNodeFromLocation (destinationTransform.position);
		enemySpawnNode = GetNodeFromLocation (enemySpawnTransform.position);

		CreateEnemies ();
	}


	void OnGUI(){
		foreach(Node node in nodes){
			if (node.isWalkable) {
				Vector3 posVector = Camera.main.WorldToScreenPoint (node.unityPosition);
				GUI.DrawTexture (new Rect (posVector.x, Screen.height - posVector.y, nodeSize.x, nodeSize.y), gridTexture);
			}

		}
	}
		
	public void createEnemies(){
		//todo
	}


	public void GetNodeFromLocation(Vector3 location){
		int xIndex = (int) Mathf.Floor ((location.x - left.position.x) / nodeSize.x);
		int yIndex = (int)Mathf.Floor ((location.y - left.position.y) / nodeSize.y);

		if (xIndex >= size_x)
			xIndex = size_x - 1;
		else if (xIndex < 0)
			xIndex = 0;

		if (yIndex >= size_y)
			yIndex = size_y - 1;
		else if (yIndex < 0)
			yIndex = 0;

		return nodes [xIndex, yIndex];
	}

	public bool BlockNode(Node node){
		if (!node.isBuildable)
			return false;
		node.isBuildable = false;
		node.isWalkable = false;

		return true;
	}

	public void UnblockNode(Node node){
		node.isWalkable = true;
		node.isBuildable = true;
	}


}
