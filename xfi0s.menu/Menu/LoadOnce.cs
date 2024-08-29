using UnityEngine;
using UnityEngine.UI;

public static void LoadOnce()
{
	
	MainCamera = GameObject.Find("Main Camera");
	HUDObj = new GameObject();
	HUDObj2 = new GameObject();
	((Object)HUDObj2).set_name("CLIENT_HUB");
	((Object)HUDObj).set_name("CLIENT_HUB");
	HUDObj.AddComponent<Canvas>();
	HUDObj.AddComponent<CanvasScaler>();
	HUDObj.AddComponent<GraphicRaycaster>();
	((Behaviour)HUDObj.GetComponent<Canvas>()).set_enabled(true);
	HUDObj.GetComponent<Canvas>().set_renderMode((RenderMode)2);
	HUDObj.GetComponent<Canvas>().set_worldCamera(MainCamera.GetComponent<Camera>());
	HUDObj.GetComponent<RectTransform>().set_sizeDelta(new Vector2(5f, 5f));
	((Transform)HUDObj.GetComponent<RectTransform>()).set_position(new Vector3(MainCamera.get_transform().get_position().x, MainCamera.get_transform().get_position().y, MainCamera.get_transform().get_position().z));
	HUDObj2.get_transform().set_position(new Vector3(MainCamera.get_transform().get_position().x, MainCamera.get_transform().get_position().y, MainCamera.get_transform().get_position().z - 4.6f));
	HUDObj.get_transform().set_parent(HUDObj2.get_transform());
	((Transform)HUDObj.GetComponent<RectTransform>()).set_localPosition(new Vector3(0f, 0f, 1.6f));
	Quaternion rotation = ((Transform)HUDObj.GetComponent<RectTransform>()).get_rotation();
	Vector3 eulerAngles = ((Quaternion)(ref rotation)).get_eulerAngles();
	eulerAngles.y = -270f;
	HUDObj.get_transform().set_localScale(new Vector3(1f, 1f, 1f));
	((Transform)HUDObj.GetComponent<RectTransform>()).set_rotation(Quaternion.Euler(eulerAngles));
	GameObject val = new GameObject();
	val.get_transform().set_parent(HUDObj.get_transform());
	Testtext = val.AddComponent<Text>();
	Testtext.set_text("");
	Testtext.set_fontSize(10);
	Testtext.set_font(Resources.GetBuiltinResource<Font>("Arial.ttf"));
	((Graphic)Testtext).get_rectTransform().set_sizeDelta(new Vector2(260f, 160f));
	((Transform)((Graphic)Testtext).get_rectTransform()).set_localScale(new Vector3(0.01f, 0.01f, 1f));
	((Transform)((Graphic)Testtext).get_rectTransform()).set_localPosition(new Vector3(-1.5f, 1f, 2f));
	((Graphic)Testtext).set_material(AlertText);
	NotifiText = Testtext;
	Testtext.set_alignment((TextAnchor)0);
	((Component)HUDObj2.get_transform()).get_transform().set_position(new Vector3(MainCamera.get_transform().get_position().x, MainCamera.get_transform().get_position().y, MainCamera.get_transform().get_position().z));
	HUDObj2.get_transform().set_rotation(MainCamera.get_transform().get_rotation());
	MainMenu = new MenuOption[7];
	MainMenu[0] = new MenuOption
	{
		DisplayName = "<color=red>Movement</color>",
		_type = "submenu",
		AssociatedString = "Movement"
	};
	MainMenu[1] = new MenuOption
	{
		DisplayName = "<color=orange>Main Stuff</color>",
		_type = "submenu",
		AssociatedString = "MainStuff"
	};
	MainMenu[2] = new MenuOption
	{
		DisplayName = "<color=yellow>Ghost Mods</color>",
		_type = "submenu",
		AssociatedString = "GhostMods"
	};
	MainMenu[3] = new MenuOption
	{
		DisplayName = "<color=green>Visual Stuff</color>",
		_type = "submenu",
		AssociatedString = "Visual"
	};
	MainMenu[4] = new MenuOption
	{
		DisplayName = "<color=blue>Server Settings</color>",
		_type = "submenu",
		AssociatedString = "Settings"
	};
	MainMenu[5] = new MenuOption
	{
		DisplayName = "<color=purple>All Cred to Colossal!</color>",
		_type = "button",
		AssociatedString = ""
	};
	MainMenu[6] = new MenuOption
	{
		DisplayName = "<color=red>Disconnect</color>",
		_type = "button",
		AssociatedString = "Disconnect"
	};
	Movement = new MenuOption[10];
	Movement[0] = new MenuOption
	{
		DisplayName = "<color=red>Ironmonke</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[1] = new MenuOption
	{
		DisplayName = "<color=orange>longer arms</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[2] = new MenuOption
	{
		DisplayName = "<color=yellow>Fly</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[3] = new MenuOption
	{
		DisplayName = "<color=green>No Clip</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[4] = new MenuOption
	{
		DisplayName = "<color=blue>No Speed Cap</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[5] = new MenuOption
	{
		DisplayName = "<color=purple>SpeedBoost</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[6] = new MenuOption
	{
		DisplayName = "<color=red>Slow Fly</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[7] = new MenuOption
	{
		DisplayName = "<color=orange>Noclip Fly</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[8] = new MenuOption
	{
		DisplayName = "<color=yellow>teleport gun</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Movement[9] = new MenuOption
	{
		DisplayName = "<color=blue>Back</color>",
		_type = "submenu",
		AssociatedString = "Back"
	};
	MainStuff = new MenuOption[13];
	MainStuff[0] = new MenuOption
	{
		DisplayName = "<color=red>Destroy All</color>",
		_type = "button",
		AssociatedString = "destroyAll"
	};
	MainStuff[1] = new MenuOption
	{
		DisplayName = "<color=orange>Crash Gun</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[2] = new MenuOption
	{
		DisplayName = "<color=yellow>Vibrate all</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[3] = new MenuOption
	{
		DisplayName = "<color=green>Slow All</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[4] = new MenuOption
	{
		DisplayName = "<color=blue>Change Gamemode to Hunt</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[5] = new MenuOption
	{
		DisplayName = "<color=purple>tag all</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[6] = new MenuOption
	{
		DisplayName = "<color=red>Mat All</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[7] = new MenuOption
	{
		DisplayName = "<color=orange>Tag Gun</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[8] = new MenuOption
	{
		DisplayName = "<color=yellow>Tag Lag</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[9] = new MenuOption
	{
		DisplayName = "<color=green>Change Gamemode To Infection</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[10] = new MenuOption
	{
		DisplayName = "<color=blue>Rig Spam</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[11] = new MenuOption
	{
		DisplayName = "<color=purple>Change Gamemode To Casual</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	MainStuff[12] = new MenuOption
	{
		DisplayName = "<color=red>Back</color>",
		_type = "submenu",
		AssociatedString = "Back"
	};
	GhostMods = new MenuOption[7];
	GhostMods[0] = new MenuOption
	{
		DisplayName = "<color=red>ghost monkey</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	GhostMods[1] = new MenuOption
	{
		DisplayName = "<color=orange>Invis Monke</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	GhostMods[2] = new MenuOption
	{
		DisplayName = "<color=yellow>Sound Spam</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	GhostMods[3] = new MenuOption
	{
		DisplayName = "<color=green>wacky monkey</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	GhostMods[4] = new MenuOption
	{
		DisplayName = "<color=blue>Teleport To Random</color>",
		_type = "button",
		AssociatedString = "teleportToRandom"
	};
	GhostMods[5] = new MenuOption
	{
		DisplayName = "<color=purple>Follow Gun</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	GhostMods[6] = new MenuOption
	{
		DisplayName = "<color=red>Back</color>",
		_type = "submenu",
		AssociatedString = "Back"
	};
	Settings = new MenuOption[4];
	Settings[0] = new MenuOption
	{
		DisplayName = "<color=red>Disconect</color>",
		_type = "button",
		AssociatedString = "Disconnect"
	};
	Settings[1] = new MenuOption
	{
		DisplayName = "<color=orange>Join Random</color>",
		_type = "button",
		AssociatedString = "joinRandom"
	};
	Settings[2] = new MenuOption
	{
		DisplayName = "<color=yellow>Create Room</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Settings[3] = new MenuOption
	{
		DisplayName = "<color=green>Back</color>",
		_type = "submenu",
		AssociatedString = "Back"
	};
	Visual = new MenuOption[4];
	Visual[0] = new MenuOption
	{
		DisplayName = "<color=red>Tracers</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Visual[1] = new MenuOption
	{
		DisplayName = "<color=orange>Name Tag</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Visual[2] = new MenuOption
	{
		DisplayName = "<color=yellow>Low Qualty</color>",
		_type = "toggle",
		AssociatedBool = false
	};
	Visual[3] = new MenuOption
	{
		DisplayName = "<color=green>Back</color>",
		_type = "submenu",
		AssociatedString = "Back"
	};
	MenuState = "Main";
	CurrentViewingMenu = MainMenu;
	UpdateMenuState(new MenuOption(), null, null);
}
