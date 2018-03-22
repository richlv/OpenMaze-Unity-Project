﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace data
{
	/// <summary>
	/// The old data file present in the previous branch.
	/// This is now the KING of the experiment system.
	/// </summary>
	[Serializable]
	public class Data
	{
		public int OutputTimesPerSecond;
		//This is the object (defined below) which contains all data available for the main player
		public Character CharacterData;
		public string OutputFile; //The output file of the character's movements during an experiment

		//This is a LIST of the different types of pickup items that are defiend below
		public List<Goal> Goals;
	
		//This is a list of the pillar objects
		public List<LandMark> Landmarks;

		
		//This list contains all pre-defined trials.
		public List<Trial> TrialData;


		//Array of blocks
		public List<BlockData> BlockList;

		//Order of blocks
		public List<int> BlockOrder;
		
		//Each given block
		[Serializable]
		public class BlockData
		{
			public string EndGoal; //percentage ___SPACE___ number. This is very arbitrary.
			public string EndFunction; //The function name (if not present, we assume its always true)

			public string BlockName; //Name (outputed at the end of the Block)
			public string Notes; //Notes about the given block
			public int Replacement; //Integer value representing replacement
			public List<RandomData>	 RandomTrialType; //Array that contains all the possible random values
			public List<int> TrialOrder; //Trial order (-1 means random)
		}
		[Serializable]
		public class RandomData
		{
			public List<int> RandomGroup;
		}
		
		/// <summary>
		/// A sample trial.
		/// </summary>
		[Serializable]
		public class Trial
		{
			public int TimeToRotate; //How long the delay can last in the rotatio
			public float WallHeight;			//This is the wall height
			public int TwoDimensional; //Set to true iff trial is two dimensional
			public string FileLocation; //Is not null iff FileLocation exists (Image for 1D trials)
			public int EnvironmentType; //This is the environment type referenced.
			public int Sides; //Number of sides present in the trial.
			public string WallColor; //HEX color of the walls
			public int Radius; //Radius of the walls
			public int TimeAllotted; //Allotted amount of time
			public int RandomLoc; //Whether or not the pickup has a random loaction
			public string Header; //Note outputted out of the trial.
			public MazeData Map;
			public string GroundType;
			public string GroundColor;
			public List<int> ActiveInvisibleGoals;
			public List<int> ActiveGoals;
			public List<int> InactiveGoals;
			public List<int> LandMarks;
			public int Quota;
			public List<float> CharacterStartPos; //The start position of the character (usually 0, 0)
		}
 	

		//This is the given PickupItem. Note that in the JSON, this is contained with an ARRAY
		[Serializable]
		public class Goal
		{
			//In general this will always be one unless necessary to implement in the future.
			public string Tag; //The name of the pickup item
			public string Color; //The colour in Hex without #
			public string SoundLocation; //The file path of the sound
			public string PythonFile; //The python file that will generate the position
			public float Size; //The size of the object
			public string Type; //The name of the prefab object
			public string ImageLoc;
			public List<float> Location;
 	
		}


		[Serializable]	
		public class Character
		{
			public float MovementSpeed; //The movespeed of the character
			public float RotationSpeed; //The rotation speed of the character
			public float GoalRotationSpeed;

			public float Height;

			public float DistancePickup;
		}


	

		//This is essentially a pillar object.
		//Fields are pretty obvious.
		[Serializable]
		public class LandMark
		{
			public List<float> Location;
			public float Length;
			public float Width;
			public float Height;
			public string Type;
			public string Color;
			public string ImageLoc;
			public float InitialRotation { get; set; }
		}
	
		//=========================== END OF JSON FIELDS ==========================================
		
		[Serializable]
		public class MazeData
		{
			public List<float> TopLeft;
			public float TileWidth;
			public List<string> Map;
			public string Color;
		}

		//This function converts the hex value to Colour.
		public static Color GetColour(string hex)
		{
			float[] l = { 0, 0, 0 };
			for (var i = 0; i < 6; i += 2)
			{
				float decValue = int.Parse(hex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
				l[i / 2] = decValue / 255;
			}
			return new Color(l[0], l[1], l[2]);

		}

		public class Point
		{
			public float X { get; set; }
			public float Y { get; set; }
			public float Z { get; set; }
		}
	}
}