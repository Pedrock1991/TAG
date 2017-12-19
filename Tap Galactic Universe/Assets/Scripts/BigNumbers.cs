using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigNumbers : MonoBehaviour {
	//"K"-kila,"M"-mega,"G"-giga,"T"-tera,"P"-peta,"E"-exa,"Z"-zetta,"Y"-yotta,"B"-bronta,
	//"O","OK","OM","OG","OT","OP","OE","OZ","OY","OB", - Geopa
	//"A","AK","AM","AG","AT","AP","AE","AZ","AY","AB", - Amosa
	//"R","RK","RM","RG","RT","RP","RE","RZ","RY","RB", - Hapra
	//"Y","YK","YM","YG","YT","YP","YE","YZ","YY","YB", - Kyra
	//"J","JK","JM","JG","JT","JP","JE","JZ","JY","JB", - Pija
	//"S","SK","SM","SG","ST","SP","SE","SZ","SY","SB", - Sagana
	//"C","CK","CM","CG","CT","CP","CE","CZ","CY","CB", - Pectra
	//"N","NK","NM","NG","NT","NP","NE","NZ","NY","NB", - Nisaba
	//"X","XK","XM","XG","XT","XP","XE","XZ","XY","XB", - Zotza
	//"AA","AAK","AAM","AAG","AAT","AAP","AAE","AAZ","AAY","AAB"}; - Alpha
	string[] tabUnits = new string[] {"Kila","Mega","Giga","Tera","Peta","Exa","Zetta","Yotta","Bronta",
		"Geopa","GeopaKila","GeopaMega","GeopaGiga","GeopaTera","GeopaPeta","GeopaExa","GeopaZetta","GeopaYotta","GeopaBronta",
		"Amosa","AmosaKila","AmosaMega","AmosaGiga","AmosaTera","AmosaPeta","AmosaExa","AmosaZetta","AmosaYotta","AmosaBronta",
		"Hapra","HapraKila","HapraMega","HapraGiga","HapraTera","HapraPeta","HapraExa","HapraZetta","HapraYotta","HapraBronta",
		"Kyra","KyraKila","KyraMega","KyraGiga","KyraTera","KyraPeta","KyraExa","KyraZetta","KyraYotta","KyraBronta",
		"Pija","PijaKila","PijaMega","PijaGiga","PijaTera","PijaPeta","PijaExa","PijaZetta","PijaYotta","PijaBronta",
		"Sagana","SaganaKila","SaganaMega","SaganaGiga","SaganaTera","SaganaPeta","SaganaExa","SaganaZetta","SaganaYotta","SaganaBronta",
		"Pectra","PectraKila","PectraMega","PectraGiga","PectraTera","PectraPeta","PectraExa","PectraZetta","PectraYotta","PectraBronta",
		"Nisaba","NisabaKila","NisabaMega","NisabaGiga","NisabaTera","NisabaPeta","NisabaExa","NisabaZetta","NisabaYotta","NisabaBronta",
		"Zotza","ZotzaKila","ZotzaMega","ZotzaGiga","ZotzaTera","ZotzaPeta","ZotzaExa","ZotzaZetta","ZotzaYotta","ZotzaBronta",
		"Alpha","AlphaKila","AlphaMega","AlphaGiga","AlphaTera","AlphaPeta","AlphaExa","AlphaZetta","AlphaYotta","AlphaBronta"};

	public string FormatNumber (double number) {
		
		bool highNumber = false;
		int tabPosition = -1;
		double bignumber = 1000;
		string unit;
		bool p_AtomePerSecond = true;

		if (number >= bignumber) {
			highNumber = true;
			while (number >= bignumber) {
				bignumber *= 1000;
				tabPosition++;
			}
			number /= (bignumber / 1000);
			unit = tabUnits [tabPosition];
		} else {
			unit = "";
			return (System.Math.Round (number*100)/100).ToString ().Replace (",", ".") + " ";
		}

		int toRound;
		if (highNumber == true) {
			toRound = 100;
		} else {
			if (p_AtomePerSecond == true) {
				toRound = 10;
			} else {
				toRound = 1;
			}
		}

		double result = Mathf.Round ((float)(number * toRound)) / toRound;

		return result.ToString ().Replace(",", ".") + " " + unit;
	}
}
