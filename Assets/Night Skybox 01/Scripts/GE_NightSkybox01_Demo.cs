// Night Skybox 01 version 1.0.0
//
// Author:	Gold Experience Team (http://www.ge-team.com)
// Details:	https://www.assetstore.unity3d.com/en/#!/content/18216
// Support:	geteamdev@gmail.com
//
// Please direct any bugs/comments/suggestions to support e-mail.

#region Namespaces

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#endregion // Namespaces

// ######################################################################
// - See "Light, Fog and Ambient color references.txt" file for text guide.
// - See images in "Night Skybox 01/Presets" folder.
// ######################################################################

// ######################################################################
// GE_NightSkybox01_Demo class does switch the Skybox, update Directional light, 
// update Render Settings,  responds the Trigger events and shows details on GUIs.
//
// Note this class is attached with FirstPersonCharacterController object in "Night Skybox 01 Demo (960x600px)" scene.
// 
// 	More info:
// 
// 		Skybox: 
// 		http://docs.unity3d.com/Documentation/Components/class-Skybox.html
// 		
// 		How do I Make a Skybox?
//		https://docs.unity3d.com/Documentation/Manual/HOWTO-UseSkybox.html
// 
// 		Render Settings
// 		http://docs.unity3d.com/Documentation/Components/class-RenderSettings.html
// 
// 		Directional light
// 		https://docs.unity3d.com/Documentation/Components/class-Light.html
// 
// 		Lights
// 		https://docs.unity3d.com/Documentation/Manual/Lights.html
// 
// 		Box Collider
// 		https://docs.unity3d.com/Documentation/Components/class-BoxCollider.html
// 
// ######################################################################

public class GE_NightSkybox01_Demo : MonoBehaviour
{

	// ########################################
	// Variables
	// ########################################

	#region Variables

	[System.Serializable]           // Embed this class with sub properties in the inspector. http://docs.unity3d.com/ScriptReference/Serializable.html
	public class LightAndSky
	{
		// Name
		public string m_Name;

		// Light
		public Light m_Light;

		// Skybox
		public Material m_Skybox;

		// Fog
		public Color m_FogColor;

		// Ambient
		public Color m_AmbientLight;
	}

	// List of LightAndSky class
	public LightAndSky[] m_LightAndSkyList;

	// Index to current Skybox
	int m_CurrentSkyBox = 0;

	#endregion // Variables

	// ########################################
	// MonoBehaviour Functions
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
	// ########################################

	#region MonoBehaviour

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	void Start()
	{
		/*
		// These lines are for sample values if you want to set set fog colors manually

		// Fog Night
		m_LightAndSkyList[0].m_FogColor =	new Color(0.1176470588235294f,0.196078431372549f,0.392156862745098f,1f);
		m_LightAndSkyList[1].m_FogColor =	new Color(0.1176470588235294f,0.196078431372549f,0.392156862745098f,1f);
		m_LightAndSkyList[2].m_FogColor =	new Color(0.0784313725490196f,0.1568627450980392f,0.392156862745098f,1f);
		m_LightAndSkyList[3].m_FogColor =	new Color(0.0784313725490196f,0.1568627450980392f,0.392156862745098f,1f);
		
		*/

		// Display first skybox in m_LightAndSkyList
		SwitchSkyBox(0);

		// Update UI Text elements
		UpdateDetailsText();
		UpdateHowToText();
	}

	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	void Update()
	{
		// User press Q key
		if (Input.GetKeyUp(KeyCode.Q))
		{
			// Show previous skybox
			OnPreviousSkybox();
		}
		// User press E key
		if (Input.GetKeyUp(KeyCode.E))
		{
			// Show next skybox
			OnNextSkybox();
		}
	}

	// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
	void OnTriggerExit(Collider other)
	{
		Debug.Log("OnTriggerExit=" + other.name);

		// Reset player position when user move it away from terrain
		this.transform.localPosition = new Vector3(0, 1, 0);
	}

	#endregion // MonoBehaviour

	// ########################################
	// Switch skybox functions
	// ########################################

	#region Switch skybox functions

	// Switch to previous skybox
	public void OnPreviousSkybox()
	{
		SwitchSkyBox(-1);
		UpdateDetailsText();
	}

	// Switch to next skybox
	public void OnNextSkybox()
	{
		SwitchSkyBox(+1);
		UpdateDetailsText();
	}

	#endregion // MonoBehaviour

	// ########################################
	// Show skybox functions
	// ########################################

	#region Show skybox functions

	// Switch to a skybox by direction
	// DiffNum less than 0 means previous skybox
	// DiffNum larger than 0 means next skybox
	void SwitchSkyBox(int DiffNum)
	{
		// Update add m_CurrentSkyBox with DiffNum
		m_CurrentSkyBox += DiffNum;

		// Clamp m_CurrentSkyBox between 0 and m_LightAndSkyList.Length
		if (m_CurrentSkyBox < 0)
		{
			m_CurrentSkyBox = m_LightAndSkyList.Length - 1;
		}
		if (m_CurrentSkyBox >= m_LightAndSkyList.Length)
		{
			m_CurrentSkyBox = 0;
		}

		// Switch skybox in RenderSettings
		RenderSettings.skybox = m_LightAndSkyList[m_CurrentSkyBox].m_Skybox;

		// Switch light
		for (int i = 0; i < m_LightAndSkyList.Length; i++)
		{
			m_LightAndSkyList[i].m_Light.gameObject.SetActive(false);
		}
		m_LightAndSkyList[m_CurrentSkyBox].m_Light.gameObject.SetActive(true);

		// Enable fog
		RenderSettings.fog = true;

		// Set the fog color
		if (m_CurrentSkyBox >= 0 && m_CurrentSkyBox < m_LightAndSkyList.Length)
		{
			RenderSettings.fogColor = m_LightAndSkyList[m_CurrentSkyBox].m_FogColor;
		}
		else
		{
			RenderSettings.fogColor = Color.white;
		}

		// Set the ambient lighting
		if (m_CurrentSkyBox >= 0 && m_CurrentSkyBox < m_LightAndSkyList.Length)
		{
			RenderSettings.ambientLight = m_LightAndSkyList[m_CurrentSkyBox].m_AmbientLight;
		}
		else
		{
			RenderSettings.ambientLight = Color.white;
		}
	}

	#endregion // Show skybox functions

	// ########################################
	// Update UI text functions
	// ########################################

	#region Update UI text functions

	// Update details UI Text
	void UpdateDetailsText()
	{
		// Update ItemNum text
		GameObject Text_ItemNum = GameObject.Find("Text_ItemNum");
		if (Text_ItemNum != null)
		{
			Text pText = Text_ItemNum.GetComponent<Text>();
			pText.text = string.Format("{0:00} of {1:00}", m_CurrentSkyBox + 1, m_LightAndSkyList.Length);
		}

		// Update Details text
		GameObject Text_Details = GameObject.Find("Text_Details");
		if (Text_Details != null)
		{
			Text pText = Text_Details.GetComponent<Text>();
			pText.text = string.Format(m_LightAndSkyList[m_CurrentSkyBox].m_Name);
		}
	}

	// Update how to UI Text
	void UpdateHowToText()
	{
		// Find Text_HowTo in the scene
		GameObject Text_HowTo = GameObject.Find("Text_HowTo");
		if (Text_HowTo != null)
		{
			// Update text according to target platform
			if (Application.platform == RuntimePlatform.IPhonePlayer ||
			Application.platform == RuntimePlatform.Android ||
			Application.platform == RuntimePlatform.BlackBerryPlayer ||
			Application.platform == RuntimePlatform.WP8Player)
			{
				Text pText = Text_HowTo.GetComponent<Text>();
				pText.text = "Move: Joystick on left | Look: Joystick on right | Change Skybox: Tap";
			}
			else
			{
				Text pText = Text_HowTo.GetComponent<Text>();
				pText.text = "Move: A-W-S-D | Jump: Spacebar | Switch Skybox: Q / E | Look / Turn: Drag Mouse";
			}
		}
	}

	#endregion // Update UI text functions

}
