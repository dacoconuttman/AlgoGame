using UnityEngine;
using System.Collections.Generic;

public class ObjectManager{

	public Map _Map;
	public EventHandler _EventHandler;
	public static ObjectManager _ObjectManager;
	public List<EnemyBase> enemies = new List<EnemyBase>();
	public int gameSpeed = 1;

	public ObjectManager(){

		_Map = GameObject.Find ("Map").GetComponent<Map> ();
		_EventHandler = GameObject.Find ("Map").GetComponent<EventHandler>();
		_ObjectManager = this;
		_Map.nodes = new Node[_Map.size_x, _Map.size_y];

		setPositions ();
		buildNodes ();
		connectNodes ();

	}

	public static ObjectManager getInstance(){

		if (_ObjectManager == null) {
			return new ObjectManager();
		} else {
			return _ObjectManager;
		}
	}

	private void setPositions(){
		Vector2 midLeft = new Vector3 (0, Screen.height / 2);
		Vector2 midRight = new Vector3 (Screen.width, Screen.height / 2);

		midLeft = Camera.main.ScreenToWorldPoint (midLeft);
		midRight = Camera.main.ScreenToWorldPoint (midRight);

		_Map.left.transform.position = midLeft;
		_Map.right.transform.position = midRight;

		_Map.enemySpawnTransform.position = midLeft;
		_Map.destinationTransform.position = midRight;
	}

	private void buildNodes(){
		float mapSizeX = (_Map.right.position.x - _Map.left.position.x);
		float mapSizeY = (_Map.left.position.y - _Map.right.position.y);

		_Map.nodeSize = new Vector2(mapSizeX / _Map.size_x, mapSizeY / _Map.size_y);

		for(int x = 0; x < _Map.size_x; x++){
			for (int y = 0; y < _Map.size_y; y++) {
				xPos = left.position.x + (x * nodeSize.x);
				yPos = right.position.y + ((y + 1) * nodeSize.y);
				Vector3 position = new Vector3 (xPos + nodeSize.x / 2, yPos - nodeSize.y / 2, 0);
				Vector3 listIndex = new Vector3 (x, y, 0);
				nodes [x, y] = new Node (true, true, position, listIndex);
			}
		}
	}


	private void connectNodes(){
		for (int y = 0; y < _Map.size_y; y++) {
			for (int x = 0; x < _Map.size_x; x++) {
				if (x - 1 >= 0) {
					nodes [x, y].borderTiles [(int)Border.downRight] = nodes [x - 1, y];
					if (y - 1 >= 0)
						nodes [x, y].borderTiles [(int)Border.Down] = nodes [x - 1, y - 1];

					if (y + 1 < nodes.GetLength (1))
						nodes [x, y].borderTiles [(int)Border.Right] = nodes [x - 1, y + 1];
				}

				if (x + 1 < nodes.GetLength (0)) {
					nodes [x, y].borderTiles [(int)Border.upLeft] = nodes [x + 1, y];
					if (y - 1 >= 0)
						nodes [x, y].borderTiles [(int)Border.Left] = nodes [x + 1, y - 1];

					if (y + 1 < nodes.GetLength (1))
						nodes [x, y].borderTiles [(int)Border.Up] = nodes [x + 1, y + 1];
				}

				if (y - 1 >= 0)
					nodes [x, y].borderTiles [(int)Border.downLeft] = nodes [x, y - 1];

				if (y + 1 < nodes.GetLength (1))
					nodes [x, y].borderTiles [(int)Border.upRight] = nodes [x, y + 1];

			}
		}
	}

}
