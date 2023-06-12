using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script stores every dialogue conversation in a public Dictionary.*/

public class Dialogue : MonoBehaviour
{

	public Dictionary<string, string[]> dialogue = new Dictionary<string, string[]>();

	void Start()
	{
		//Door
		dialogue.Add("LockedDoorA", new string[] {
			"A large door...",
			"Looks like it has a key hole!"
		});


		dialogue.Add("LockedDoorB", new string[] {
			"Key used!"
		});

		//NPC
		dialogue.Add("CharacterA", new string[] {
			"Hi there!",
			"It's me! I mean...",
			"YOU! ...",
			"But, there's no time for that, bring me 30 coins and I'll show you a new way to f**k those bastards",
			"Well, let's just say I'm your future you",
			"You will understand soon",
		});

		dialogue.Add("CharacterAChoice1", new string[] {
			"",
			"",
			"",
			"Let me go find some coins!",
		});

		dialogue.Add("CharacterAChoice2", new string[] {
			"",
			"",
			"",
			"Wait, what the hell is this?!"
		});

		dialogue.Add("CharacterB", new string[] {
			"Hey! You got the coins!",
			"I'll show you a new ability!",
			"How about a DOWNWARD SMASH? Simply attack while pressing down in mid-air!"
		});
	}
}
