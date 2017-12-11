using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowScoresManager : MonoBehaviour {

	public class person{
		string name;
		int score;

		public string getName(){ return name; }

		public int getScore(){
			return score;
		}

		public person(string s, int i){
			name=s;
			score = i;
		}
	}

	public Text mycontent;
	// Use this for initialization
	void Awake () {
		ShowScores ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void ShowScores(){
		string mynewtext = "";
		string path = @"Assets\scores.txt";
		string[] readText = System.IO.File.ReadAllLines(path);
		List<person> list = new List<person> ();
		foreach (string s in readText)
		{
			string[] tmp = s.Split (new System.Char[] {'\t'});
			list.Add (new person(tmp[0],Int32.Parse(tmp[1])));
			//mynewtext +=tmp[0]+"\t"+tmp[1];
		}



		list.Sort ((x,y) => y.getScore().CompareTo(x.getScore()));

		int i = 0;
		foreach (person p in list)
		{
			i++;
			mynewtext += "\t"+i+"\t\t\t\t\t\t\t"+p.getName()+"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t"+p.getScore()+"\n";
		}
		mycontent.text = mynewtext;
	}

    public void BackToMain() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
