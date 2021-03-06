﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PathFindingTest : MonoBehaviour {

	public GameObject mapGroup;

	// Use this for initialization
	void Start () {
		int[,] map = new int[6, 6]{
			{0,1,0,0,0,0},
			{0,1,0,0,0,0},
			{0,1,1,1,1,0},
			{0,1,0,0,0,0},
			{0,1,0,0,0,0},
			{0,0,0,0,0,0}

		};

		var graph = new Graph (map);

		var search = new Search (graph);
		search.Start (graph.nodes [0], graph.nodes [2]);

		while (!search.finished) {
			search.Step();
		}

		print ("Search done. Path length " + search.path.Count + " iterations " + search.iterations);

		ResetMapGroup (graph);

		foreach (var node in search.path) {
			GetImage (node.label).color = Color.red;
		}
	} 

	Image GetImage(string label) {
		var id = Int32.Parse (label);
		var go = mapGroup.transform.GetChild (id).gameObject;
		return go.GetComponent<Image> ();
	}

	void ResetMapGroup(Graph graph) {
		foreach (var node in graph.nodes) {
			GetImage (node.label).color = node.adjecent.Count == 0 ? Color.white : Color.gray;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
