using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTechnologyCard {

	public string[] blackGoldModulesNamesRow1 = {
		"Diamond Lens", //0
		"Drone  on", //1
		"Precision Antennas", //2
		"Light Buses", //3
		"Artificial Brain", //4
	};
	public string[] blackGoldModulesDescribeRow1 = {
		"x2 Module 1 Profit, x2 Module 4 Profit,x2 Module 7 Profit", //0
		"x2 Module 2 Profit, x2 Module 5 Profit,x2 Module 8 Profit", //1
		"x2 Module 3 Profit, x2 Module 6 Profit, x2 Module 9 Profit", //2
		"x1.5 All Modules Profit, x2 Module 1 Profit", //3
		"x1.5 All Modules Profit, x2 Module 2 Profit", //4
	};
	public string[] blackGoldModulesNamesRow2 = {
		"Holographic Mapping", //5
		"Graphene Board", //6
		"4D Technology", //7
		"Atomic Cell", //8
		"Rainbow Beam", //9
	};
	public string[] blackGoldModulesDescribeRow2 = {
		"x1.5 All Modules Profit, x2 Module 3 Profit", //5
		"x1.5 All Modules Profit, x2 Module 4 Profit", //6
		"x1.5 All Modules Profit, x2 Module 5 Profit", //7
		"x1.5 All Modules Profit, x2 Module 6 Profit", //8
		"x1.5 All Modules Profit, x2 Module 7 Profit", //9
	};
	public string[] blackGoldModulesNamesRow3 = {
		"Growth Beam", //10
		"Carbon 14", //11
		"Interplanetary Map", //12
		"Robots Manufacturers", //13
		"Universal Queue", //14
	};
	public string[] blackGoldModulesDescribeRow3 = {
		"x1.5 All Modules Profit, x2 Module 8 Profit", //10
		"x1.5 All Modules Profit, x2 Module 9 Profit", //11
		"x1.5 All Modules Profit, x2 Module 10 Profit", //12
		"x1.5 All Modules Profit, x2 Double Fabrication Amount", //13
		"x1.5 All Modules Profit, x2 Double Fabrication Amount", //14
	};
	public string[] blackGoldModulesNamesRow4 = {
		"I-Harmony", //15
		"Fast Mats", //16
		"Time Lapse", //17
		"Artificial Alien Int", //18
		"Diamond Tools", //19
	};
	public string[] blackGoldModulesDescribeRow4 = {
		"x1.5 All Modules Profit", //15
		"x1.5 All Modules Profit, x2 Tap Profit", //16
		"x1.5 All Modules Profit", //17
		"x2 All Modules Profit", //18
		"x1.5 All Modules Profit, x2 Double Fabrication Amount", //19
	};
	public string[] blackGoldModulesNamesRow5 = {
		"Probe Maker", //20
		"Alien Call", //21
		"Jet Strong", //22
		"Robot Manager", //23
		"Universal Recycling", //24
	};
	public string[] blackGoldModulesDescribeRow5 = {
		"x2 Double Fabrication Amount", //20
		"x1.5 All Modules Profit", //21
		"x2 Double Fabrication Amount", //22
		"x2 All Modules Profit", //23
		"x1.5 All Modules Profit", //24
	};
	public string[] blackSilverModulesNamesRow6 = {
		"C-Probe", //25
		"Black Hole Drill", //26
		"Robot-assist", //27
		"Wormhole Wicket", //28
		"Photon Reactor", //29
	};
	public string[] blackSilverModulesDescribeRow6 = {
		"x1.5 per Module 1 technology", //25
		"x2 Module 1 profit", //26
		"x2 Module 1 profit", //27
		"x2 Module 1 profit", //28
		"x3 Module 1 profit", //29
	};
	public string[] blackSilverModulesNamesRow7 = {
		"Cave Finder", //30
		"Shell", //31
		"Planet Finder", //32
		"Molecular Clones", //33
		"Gamma Posse", //34
	};
	public string[] blackSilverModulesDescribeRow7 = {
		"x1.2 per Module 2 technology", //30
		"x2 Module 2 profit", //31
		"x2 Module 2 profit", //32
		"x2 Module 2 profit", //33
		"x3 Module 2 profit", //34
	};
	public string[] blackSilverModulesNamesRow8 = {
		"Portal-Package", //35
		"T to the three", //36
		"Takebots", //37
		"Droners", //38
		"Holo-Stamps", //39
	};
	public string[] blackSilverModulesDescribeRow8 = {
		"x1.2 per Module 3 technology", //35
		"x2 Module 3 profit", //36
		"x2 Module 3 profit", //37
		"x2 Module 3 profit", //38
		"x3 Module 3 profit", //39
	};
	public string[] blackSilverModulesNamesRow9 = {
		"Probe Power", //40
		"Big Probe", //41
		"Miner Craft", //42
		"NanoCharge", //43
		"Solar Shades", //44
	};
	public string[] blackSilverModulesDescribeRow9 = {
		"x1.2 per Module 4 technology", //40
		"x2 Module 4 profit", //41
		"x2 Module 4 profit", //42
		"x2 Module 4 profit", //43
		"x3 Module 4 profit", //44
	};
	public string[] blackSilverModulesNamesRow10 = {
		"Holo-Window", //45
		"Pilot Robot", //46
		"Sweeter", //47
		"Plasma Screw", //48
		"Drone-tender", //49
	};
	public string[] blackSilverModulesDescribeRow10 = {
		"x1.2 per Module 5 technology", //45
		"x2 Module 5 profit", //46
		"x2 Module 5 profit", //47
		"x2 Module 5 profit", //48
		"x3 Module 5 profit", //49
	};
	public string[] blackSilverModulesNamesRow11 = {
		"Clone at Station", //50
		"Five Finger", //51
		"X-Lens", //52
		"A*", //53
		"Smart-Return", //54
	};
	public string[] blackSilverModulesDescribeRow11 = {
		"x1.2 per Module 6 technology", //50
		"x2 Module 6 profit", //51
		"x2 Module 6 profit", //52
		"x2 Module 6 profit", //53
		"x3 Module 6 profit", //54
	};
	public string[] blackSilverModulesNamesRow12 = {
		"Zap!", //55
		"Booster Probe", //56
		"Bionic Armor", //57
		"Gaz Glass", //58
		"The Stink", //59
	};
	public string[] blackSilverModulesDescribeRow12 = {
		"x1.2 per Module 7 technology", //55
		"x2 Module 7 profit", //56
		"x2 Module 7 profit", //57
		"x2 Module 7 profit", //58
		"x3 Module 7 profit", //59
	};
	public string[] blackSilverModulesNamesRow13 = {
		"Virtual Work", //60
		"Soul Real", //61
		"Rousey Robot", //62
		"Atomic Coaster", //63
		"Super Probe", //64
	};
	public string[] blackSilverModulesDescribeRow13 = {
		"x1.2 per Module 8 technology", //60
		"x2 Module 8 profit", //61
		"x2 Module 8 profit", //62
		"x2 Module 8 profit", //63
		"x3 Module 8 profit", //64
	};
	public string[] blackSilverModulesNamesRow14 = {
		"Buddy Tech", //65
		"Bots", //66
		"Safe Production", //67
		"V-Robot", //68
		"E-Carbon", //69
	};
	public string[] blackSilverModulesDescribeRow14 = {
		"x1.2 per Module 9 technology", //65
		"x2 Module 9 profit", //66
		"x2 Module 9 profit", //67
		"x2 Module 9 profit", //68
		"x3 Module 9 profit", //69
	};
	public string[] blackSilverModulesNamesRow15 = {
		"Phase Finder", //70
		"UV-Broadcaster", //71
		"V-Broadcaster", //72
		"Full Robot", //73
		"Telemarket Robot", //74
	};
	public string[] blackSilverModulesDescribeRow15 = {
		"x1.2 per Module 10 technology", //70
		"x2 Module 10 profit", //71
		"x2 Module 10 profit", //72
		"x2 Module 10 profit", //73
		"x3 Module 10 profit", //74
	};
	public string[] blackCopperModulesNamesRow16 = {
		"Aura Up", //75
		"Karma R Us", //76
		"Random Probe", //77
		"The Future", //78
		"Betting", //79
	};
	public string[] blackCopperModulesDescribeRow16 = {
		"+5% Tap Stack Chance", //75
		"+1% Tap Stack Chance", //76
		"+1% Tap Stack Chance", //77
		"+1% Tap Stack Chance", //78
		"+1% Tap Stack Chance", //79
	};
	public string[] blackCopperModulesNamesRow17 = {
		"Probes Maker", //80
		"Robot Genie", //81
		"Screwdriver Bot", //82
		"Lots of Probe", //83
		"Problem No More", //84
	};
	public string[] blackCopperModulesDescribeRow17 = {
		"+5% Tap Stack Chance", //80
		"+1% Tap Stack Chance", //81
		"+1% Tap Stack Chance", //82
		"+1% Tap Stack Chance", //83
		"+1% Tap Stack Chance", //84
	};
	public string[] blackCopperModulesNamesRow18 = {
		"Push it out!", //85
		"On Their Mind", //86
		"Smarto", //87
		"Brain Cell", //88
		"Cerebral Fabrication", //89
	};
	public string[] blackCopperModulesDescribeRow18 = {
		"+2 Automatically Fabrication Profit", //85
		"+2 Automatically Fabrication Profit", //86
		"+2 Automatically Fabrication Profit", //87
		"+2 Automatically Fabrication Profit", //88
		"+2 Automatically Fabrication Profit", //89
	};
	public string[] blackCopperModulesNamesRow19 = {
		"Octo-arms", //90
		"Light Speed Finger", //91
		"E-Gravity", //92
		"A-Tech", //93
		"Invisa-wear", //94
	};
	public string[] blackCopperModulesDescribeRow19 = {
		"x2 Tap Profit", //90
		"x1.5 Tap Profit", //91
		"x1.5 Tap Profit", //92
		"x1.5 Tap Profit", //93
		"x1.5 Tap Profit", //94
	};
	public string[] blackCopperModulesNamesRow20 = {
		"T-Paper", //95
		"X-Ray", //96
		"Spy Probe", //97
		"Cosmic Carboniser", //98
		"Second Wave", //99
	};
	public string[] blackCopperModulesDescribeRow20 = {
		"x2 Module 1 Profit, x2 Module 10 Profit", //95
		"x2 Module 2 Profit, x2 Module 9 Profit", //96
		"x2 Module 3 Profit, x2 Module 8 Profit", //97
		"x2 Module 4 Profit, x2 Module 7 Profit", //98
		"x2 Module 5 Profit, x2 Module 6 Profit", //99
	};
}

