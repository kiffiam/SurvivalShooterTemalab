using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowScoresManager : MonoBehaviour {

	int tenth;

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

	List<person> list;

	public Text mycontent_1;
	public Text mycontent_2;
	public Text mycontent_3;

	void Awake () {
		tenth = 0;

		string mynewtext = "";
		string path = @"Assets\scores.txt";
		string[] readText = System.IO.File.ReadAllLines(path);
		list = new List<person> ();
		foreach (string s in readText)
		{
			string[] tmp = s.Split (new System.Char[] {'\t'});
			list.Add (new person(tmp[0],Int32.Parse(tmp[1])));
		}

		list.Sort ((x,y) => y.getScore().CompareTo(x.getScore()));

		ShowScores (tenth);
	}

	void Update () {
		
	}
		
	public void ShowScores(int tenth){
		string mynewtext_1="";
		string mynewtext_2="";
		string mynewtext_3="";

		int i = 0;
		while(tenth*10+i < list.Count)
		{
			mynewtext_1 += (tenth*10+i+1).ToString() + "\n";
			mynewtext_2 += list[tenth*10+i].getName() + "\n";
			mynewtext_3 += list[tenth*10+i].getScore().ToString() + "\n";
			i++;
		}
		mycontent_1.text = mynewtext_1;
		mycontent_2.text = mynewtext_2;
		mycontent_3.text = mynewtext_3;
	}

    public void BackToMain() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

	public void Next(){
		if (list.Count > (tenth + 1) * 10) {
			tenth++;
			ShowScores (tenth);
		}
	}

	public void Back(){
		if (tenth > 0) {
			tenth--;
			ShowScores (tenth);
		}
	}
}
