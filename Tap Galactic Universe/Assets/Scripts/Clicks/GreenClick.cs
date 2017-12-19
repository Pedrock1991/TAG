using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenClick : MonoBehaviour {

	public Text dataCounter1;
	public Text dataCounter2;
	public Text dataCounter3;
	public Text PerProbe;
	public Text numberOfProbe;
	public double data;
	public double dataPerProbe = 1;
	public double dataPerProbeBooster; // Don't Save this Variable
	public int probes;
	public BigNumbers formatter;
	SaveClick save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void Awake () {
		LoadGame ();
	}

	// Update is called once per frame
	void Update () {
		dataCounter1.text = "<b>Amount of Data</b>\n" + formatter.FormatNumber(data);
		dataCounter2.text = "<b>Amount of Data</b>\n" + formatter.FormatNumber(data);
		dataCounter3.text = "<b>Amount of Data</b>\n" + formatter.FormatNumber(data);
		PerProbe.text = " <b>Data/Probe</b>\n " + formatter.FormatNumber((dataPerProbe + dataPerProbeBooster));
		numberOfProbe.text = " <b>Number Of Probes</b>\n " + probes;
	}

	public void count ()
	{
		data += (dataPerProbe + dataPerProbeBooster);
	}

	private SaveClick CreateSaveGameObject () {
		SaveClick save = new SaveClick ();
		save.data = data;
		save.dataPerProbe = dataPerProbe;

		Debug.Log (save.data);
		Debug.Log (save.dataPerProbe);

		return save;
	}

	public void SaveGame () {
		//SaveClick save = CreateSaveGameObject ();
		SaveClick save = new SaveClick ();
		save.data = data;
		save.dataPerProbe = dataPerProbe;


		PlayerPrefs.SetString("GreenClickSave", Helper.Serialize<SaveClick>(save));
	}

	public void LoadGame () {

		if (PlayerPrefs.HasKey ("GreenClickSave")) {
			SaveClick save = Helper.DeSerialize<SaveClick>(PlayerPrefs.GetString("GreenClickSave"));

			data = save.data;
			dataPerProbe = save.dataPerProbe;
		}
	}
}
