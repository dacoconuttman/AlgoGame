using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {

	public ObjectManager _ObjectManager;
	public List<Node> pathToDestination = null;


	// Use this for initialization
	void Start () {
		_ObjectManager = ObjectManager.getInstance ();
		pathToDestination = AStar (_ObjectManager._Map.enemySpawnNode,
			_ObjectManager._Map.destinationNode);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePosition = Input.mousePosition;

			Node cursorOnNode = _ObjectManager._Map.GetNodeFromLocation (Camera.main.ScreenToWorldPoint(mousePosition));
			bool canBuild = _ObjectManager._Map.BlockNode (cursorOnNode);

			if (CheckAndUpdatePaths () && canBuild) {
				Vector3 correctedPosition = cursorOnNode.unityPosition;
				Instantiate (_ObjectManager._Map.StandardTurret, correctedPosition, Quaternion.Euler (new Vector3 (90, 90, 0)));
			} else if (canBuild) {
				_ObjectManager._Map.UnblockNode (cursorOnNode);
				UpdateNullPaths ();
				Debug.Log ("no path");
			}



		}
	}
}
