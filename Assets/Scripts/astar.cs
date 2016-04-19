using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using UnityEngine;

public class AStar{

	public static bool finished = false;
	public static System.Object currMinPath = int.MaxValue;
	public static int[] threadId = new int[] {1,2};

	public int id;

	public Node start;
	public Node dest;

	public int heuristic = 0;
	public Node endNode = null;
	public AStar brotherThread;



}
