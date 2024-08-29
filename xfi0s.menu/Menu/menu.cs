using System;
using System.Linq;
using Colossal;
using Colossal.Menu;
using easyInputs;
using GorillaLocomotion;
using Il2CppSystem;
using Photon.Pun;
using Photon.Realtime;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.UI;

public class Menu
{
	public static bool GUIToggled = true;

	private static GameObject HUDObj;

	private static GameObject HUDObj2;

	private static GameObject MainCamera;

	private static Text Testtext;

	private static TextAnchor textAnchor = (TextAnchor)2;

	private static Material AlertText = new Material(Shader.Find("GUI/Text Shader"));

	private static Text NotifiText;

	public static string MenuState = "Main";

	public static string MenuColour = "blue";

	public static bool MenuRGB = false;

	public static float menurgb = 1f;

	public static int SelectedOptionIndex = 0;

	public static MenuOption[] CurrentViewingMenu = null;

	public static MenuOption[] MainMenu;

	public static MenuOption[] Movement;

	public static MenuOption[] GhostMods;

	public static MenuOption[] MainStuff;

	public static MenuOption[] Visual;

	public static MenuOption[] BasicColors;

	public static MenuOption[] Settings;

  public static MenuOption[] projectiles;

	public static bool inputcooldown = false;

	public static bool menutogglecooldown = false;

	public static bool driftmode = false;

	public static void LoadOnce()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		Menu.MainCamera = GameObject.Find("Main Camera");
		Menu.HUDObj = new GameObject();
		Menu.HUDObj2 = new GameObject();
		((Object)Menu.HUDObj2).set_name("CLIENT_HUB");
		((Object)Menu.HUDObj).set_name("CLIENT_HUB");
		Menu.HUDObj.AddComponent<Canvas>();
		Menu.HUDObj.AddComponent<CanvasScaler>();
		Menu.HUDObj.AddComponent<GraphicRaycaster>();
		((Behaviour)Menu.HUDObj.GetComponent<Canvas>()).set_enabled(true);
		Menu.HUDObj.GetComponent<Canvas>().set_renderMode((RenderMode)2);
		Menu.HUDObj.GetComponent<Canvas>().set_worldCamera(Menu.MainCamera.GetComponent<Camera>());
		Menu.HUDObj.GetComponent<RectTransform>().set_sizeDelta(new Vector2(5f, 5f));
		((Transform)Menu.HUDObj.GetComponent<RectTransform>()).set_position(new Vector3(Menu.MainCamera.get_transform().get_position().x, Menu.MainCamera.get_transform().get_position().y, Menu.MainCamera.get_transform().get_position().z));
		Menu.HUDObj2.get_transform().set_position(new Vector3(Menu.MainCamera.get_transform().get_position().x, Menu.MainCamera.get_transform().get_position().y, Menu.MainCamera.get_transform().get_position().z - 4.6f));
		Menu.HUDObj.get_transform().set_parent(Menu.HUDObj2.get_transform());
		((Transform)Menu.HUDObj.GetComponent<RectTransform>()).set_localPosition(new Vector3(0f, 0f, 1.6f));
		Quaternion rotation;
		rotation = ((Transform)Menu.HUDObj.GetComponent<RectTransform>()).get_rotation();
		Vector3 eulerAngles;
		eulerAngles = ((Quaternion)(ref rotation)).get_eulerAngles();
		eulerAngles.y = -270f;
		Menu.HUDObj.get_transform().set_localScale(new Vector3(1f, 1f, 1f));
		((Transform)Menu.HUDObj.GetComponent<RectTransform>()).set_rotation(Quaternion.Euler(eulerAngles));
		GameObject val;
		val = new GameObject();
		val.get_transform().set_parent(Menu.HUDObj.get_transform());
		Menu.Testtext = val.AddComponent<Text>();
		Menu.Testtext.set_text("");
		Menu.Testtext.set_fontSize(10);
		Menu.Testtext.set_font(Resources.GetBuiltinResource<Font>("Arial.ttf"));
		((Graphic)Menu.Testtext).get_rectTransform().set_sizeDelta(new Vector2(260f, 160f));
		((Transform)((Graphic)Menu.Testtext).get_rectTransform()).set_localScale(new Vector3(0.01f, 0.01f, 1f));
		((Transform)((Graphic)Menu.Testtext).get_rectTransform()).set_localPosition(new Vector3(-1.5f, 1f, 2f));
		((Graphic)Menu.Testtext).set_material(Menu.AlertText);
		Menu.NotifiText = Menu.Testtext;
		Menu.Testtext.set_alignment((TextAnchor)0);
		((Component)Menu.HUDObj2.get_transform()).get_transform().set_position(new Vector3(Menu.MainCamera.get_transform().get_position().x, Menu.MainCamera.get_transform().get_position().y, Menu.MainCamera.get_transform().get_position().z));
		Menu.HUDObj2.get_transform().set_rotation(Menu.MainCamera.get_transform().get_rotation());
		Menu.MainMenu = new MenuOption[7];
		Menu.MainMenu[0] = new MenuOption
		{
			DisplayName = "<color=red>Movement</color>",
			_type = "submenu",
			AssociatedString = "Movement"
		};
		Menu.MainMenu[1] = new MenuOption
		{
			DisplayName = "<color=orange>Main Stuff</color>",
			_type = "submenu",
			AssociatedString = "MainStuff"
		};
		Menu.MainMenu[2] = new MenuOption
		{
			DisplayName = "<color=yellow>Ghost Mods</color>",
			_type = "submenu",
			AssociatedString = "GhostMods"
		};
		Menu.MainMenu[3] = new MenuOption
		{
			DisplayName = "<color=green>Visual Stuff</color>",
			_type = "submenu",
			AssociatedString = "Visual"
		};
		Menu.MainMenu[4] = new MenuOption
		{
			DisplayName = "<color=blue>Server Settings</color>",
			_type = "submenu",
			AssociatedString = "Settings"
		};
		Menu.MainMenu[5] = new MenuOption
		{
			DisplayName = "<color=purple>All Cred to Colossal!</color>",
			_type = "button",
			AssociatedString = ""
		};
		Menu.MainMenu[6] = new MenuOption
		{
			DisplayName = "<color=red>Disconnect</color>",
			_type = "button",
			AssociatedString = "Disconnect"
		};
		Menu.Movement = new MenuOption[10];
		Menu.Movement[0] = new MenuOption
		{
			DisplayName = "<color=red>Ironmonke</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[1] = new MenuOption
		{
			DisplayName = "<color=orange>longer arms</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[2] = new MenuOption
		{
			DisplayName = "<color=yellow>Fly</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[3] = new MenuOption
		{
			DisplayName = "<color=green>No Clip</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[4] = new MenuOption
		{
			DisplayName = "<color=blue>No Speed Cap</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[5] = new MenuOption
		{
			DisplayName = "<color=purple>SpeedBoost</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[6] = new MenuOption
		{
			DisplayName = "<color=red>Slow Fly</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[7] = new MenuOption
		{
			DisplayName = "<color=orange>Noclip Fly</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[8] = new MenuOption
		{
			DisplayName = "<color=yellow>teleport gun</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Movement[9] = new MenuOption
		{
			DisplayName = "<color=blue>Back</color>",
			_type = "submenu",
			AssociatedString = "Back"
		};
		Menu.MainStuff = new MenuOption[13];
		Menu.MainStuff[0] = new MenuOption
		{
			DisplayName = "<color=red>Destroy All</color>",
			_type = "button",
			AssociatedString = "destroyAll"
		};
		Menu.MainStuff[1] = new MenuOption
		{
			DisplayName = "<color=orange>Crash Gun</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[2] = new MenuOption
		{
			DisplayName = "<color=yellow>Vibrate all</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[3] = new MenuOption
		{
			DisplayName = "<color=green>Slow All</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[4] = new MenuOption
		{
			DisplayName = "<color=blue>Change Gamemode to Hunt</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[5] = new MenuOption
		{
			DisplayName = "<color=purple>tag all</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[6] = new MenuOption
		{
			DisplayName = "<color=red>Mat All</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[7] = new MenuOption
		{
			DisplayName = "<color=orange>Tag Gun</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[8] = new MenuOption
		{
			DisplayName = "<color=yellow>Tag Lag</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[9] = new MenuOption
		{
			DisplayName = "<color=green>Change Gamemode To Infection</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[10] = new MenuOption
		{
			DisplayName = "<color=blue>Rig Spam</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[11] = new MenuOption
		{
			DisplayName = "<color=purple>Change Gamemode To Casual</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.MainStuff[12] = new MenuOption
		{
			DisplayName = "<color=red>Back</color>",
			_type = "submenu",
			AssociatedString = "Back"
		};
		Menu.GhostMods = new MenuOption[7];
		Menu.GhostMods[0] = new MenuOption
		{
			DisplayName = "<color=red>ghost monkey</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.GhostMods[1] = new MenuOption
		{
			DisplayName = "<color=orange>Invis Monke</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.GhostMods[2] = new MenuOption
		{
			DisplayName = "<color=yellow>Sound Spam</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.GhostMods[3] = new MenuOption
		{
			DisplayName = "<color=green>wacky monkey</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.GhostMods[4] = new MenuOption
		{
			DisplayName = "<color=blue>Teleport To Random</color>",
			_type = "button",
			AssociatedString = "teleportToRandom"
		};
		Menu.GhostMods[5] = new MenuOption
		{
			DisplayName = "<color=purple>Follow Gun</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.GhostMods[6] = new MenuOption
		{
			DisplayName = "<color=red>Back</color>",
			_type = "submenu",
			AssociatedString = "Back"
		};
		Menu.Settings = new MenuOption[4];
		Menu.Settings[0] = new MenuOption
		{
			DisplayName = "<color=red>Disconect</color>",
			_type = "button",
			AssociatedString = "Disconnect"
		};
		Menu.Settings[1] = new MenuOption
		{
			DisplayName = "<color=orange>Join Random</color>",
			_type = "button",
			AssociatedString = "joinRandom"
		};
		Menu.Settings[2] = new MenuOption
		{
			DisplayName = "<color=yellow>Create Room</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Settings[3] = new MenuOption
		{
			DisplayName = "<color=green>Back</color>",
			_type = "submenu",
			AssociatedString = "Back"
		};
		Menu.Visual = new MenuOption[4];
		Menu.Visual[0] = new MenuOption
		{
			DisplayName = "<color=red>Tracers</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Visual[1] = new MenuOption
		{
			DisplayName = "<color=orange>Name Tag</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Visual[2] = new MenuOption
		{
			DisplayName = "<color=yellow>Low Qualty</color>",
			_type = "toggle",
			AssociatedBool = false
		};
		Menu.Visual[3] = new MenuOption
		{
			DisplayName = "<color=green>Back</color>",
			_type = "submenu",
			AssociatedString = "Back"
		};
		Menu.MenuState = "Main";
		Menu.CurrentViewingMenu = Menu.MainMenu;
		Menu.UpdateMenuState(new MenuOption(), null, null);
	}

	public static void Load()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		if (EasyInputs.GetThumbStickButtonDown((EasyHand)0) && EasyInputs.GetThumbStickButtonDown((EasyHand)1) && !Menu.menutogglecooldown)
		{
			Menu.menutogglecooldown = true;
			Menu.HUDObj2.SetActive(!Menu.HUDObj2.get_activeSelf());
			Menu.GUIToggled = !Menu.GUIToggled;
		}
		if (!EasyInputs.GetThumbStickButtonDown((EasyHand)0) && !EasyInputs.GetThumbStickButtonDown((EasyHand)1) && Menu.menutogglecooldown)
		{
			Menu.menutogglecooldown = false;
		}
		if (Menu.GUIToggled)
		{
			Menu.HUDObj2.get_transform().set_position(new Vector3(Menu.MainCamera.get_transform().get_position().x, Menu.MainCamera.get_transform().get_position().y, Menu.MainCamera.get_transform().get_position().z));
			Menu.HUDObj2.get_transform().set_rotation(Menu.MainCamera.get_transform().get_rotation());
			if (EasyInputs.GetThumbStickButtonDown((EasyHand)0))
			{
				if (EasyInputs.GetTriggerButtonDown((EasyHand)1) && !Menu.inputcooldown)
				{
					Menu.inputcooldown = true;
					if (Menu.SelectedOptionIndex + 1 == Menu.CurrentViewingMenu.Count())
					{
						Menu.SelectedOptionIndex = 0;
					}
					else
					{
						Menu.SelectedOptionIndex++;
					}
					Menu.UpdateMenuState(new MenuOption(), null, null);
				}
				if (EasyInputs.GetGripButtonDown((EasyHand)1) && !Menu.inputcooldown)
				{
					Menu.inputcooldown = true;
					Menu.UpdateMenuState(Menu.CurrentViewingMenu[Menu.SelectedOptionIndex], null, "optionhit");
				}
				if (!EasyInputs.GetTriggerButtonDown((EasyHand)1) && !EasyInputs.GetGripButtonDown((EasyHand)1) && Menu.inputcooldown)
				{
					Menu.inputcooldown = false;
				}
			}
		}
		Plugin.CrashGun = Menu.MainStuff[1].AssociatedBool;
		Plugin.vibrateCon = Menu.MainStuff[2].AssociatedBool;
		Plugin.slowAll = Menu.MainStuff[3].AssociatedBool;
		Plugin.longArms = Menu.Movement[1].AssociatedBool;
		Plugin.fly = Menu.Movement[2].AssociatedBool;
		Plugin.slowFly = Menu.Movement[6].AssociatedBool;
		Plugin.noclip = Menu.Movement[3].AssociatedBool;
		Plugin.excelfly = Menu.Movement[0].AssociatedBool;
		Plugin.TagAll = Menu.MainStuff[5].AssociatedBool;
		Plugin.noSpeedCap = Menu.Movement[4].AssociatedBool;
		Plugin.SetGameModeToHunt = Menu.MainStuff[4].AssociatedBool;
		Plugin.noclipFly = Menu.Movement[7].AssociatedBool;
		Plugin.changeGameModeToCasual = Menu.MainStuff[11].AssociatedBool;
		Plugin.matall = Menu.MainStuff[6].AssociatedBool;
		Plugin.nameSpam = Menu.MainStuff[12].AssociatedBool;
		Plugin.speedBoost = Menu.Movement[5].AssociatedBool;
		Plugin.ghostmonkey = Menu.GhostMods[0].AssociatedBool;
		Plugin.invis = Menu.GhostMods[1].AssociatedBool;
		Plugin.changeGameModeToInfect = Menu.MainStuff[9].AssociatedBool;
		Plugin.TagLag = Menu.MainStuff[8].AssociatedBool;
		Plugin.teleportGun = Menu.Movement[8].AssociatedBool;
		Plugin.wackyMonkey = Menu.GhostMods[3].AssociatedBool;
		Plugin.soundSpam = Menu.GhostMods[2].AssociatedBool;
		Plugin.TagGun = Menu.MainStuff[7].AssociatedBool;
		Plugin.rigSpam = Menu.MainStuff[10].AssociatedBool;
		Plugin.tracers = Menu.Visual[0].AssociatedBool;
		Plugin.nameTags = Menu.Visual[1].AssociatedBool;
		Plugin.createRoom = Menu.Settings[2].AssociatedBool;
		Plugin.followGun = Menu.GhostMods[5].AssociatedBool;
		Plugin.lowQualty = Menu.Visual[2].AssociatedBool;
		string[] array;
		array = new string[5];
		array[0] = "<color=";
		array[1] = Menu.MenuColour;
		array[2] = ">Ventrald GTAG Copy Menu: ";
		array[3] = Menu.MenuState;
		array[4] = "</color>\n";
		string text;
		text = string.Concat(array);
		int num;
		num = 0;
		if (Menu.CurrentViewingMenu != null)
		{
			MenuOption[] currentViewingMenu;
			currentViewingMenu = Menu.CurrentViewingMenu;
			foreach (MenuOption menuOption in currentViewingMenu)
			{
				if (Menu.SelectedOptionIndex == num)
				{
					text += "<color=red>-> </color>";
				}
				text += menuOption.DisplayName;
				if (menuOption._type == "toggle")
				{
					text = ((!menuOption.AssociatedBool) ? (text + " <color=red>[OFF]</color>") : (text + " <color=green>[ON]</color>"));
				}
				text += "\n";
				num++;
			}
			Menu.Testtext.set_text(text);
		}
		else
		{
			Debug.Log(Object.op_Implicit("Null for some reason"));
		}
	}

	private static void UpdateMenuState(MenuOption option, string _MenuState, string OperationType)
	{
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!(OperationType == "optionhit"))
			{
				return;
			}
			if (option._type == "submenu")
			{
				if (option.AssociatedString == "Movement")
				{
					Menu.CurrentViewingMenu = Menu.Movement;
				}
				if (option.AssociatedString == "GhostMods")
				{
					Menu.CurrentViewingMenu = Menu.GhostMods;
				}
				if (option.AssociatedString == "MainStuff")
				{
					Menu.CurrentViewingMenu = Menu.MainStuff;
				}
				if (option.AssociatedString == "basicColors")
				{
					Menu.CurrentViewingMenu = Menu.BasicColors;
				}
				if (option.AssociatedString == "Settings")
				{
					Menu.CurrentViewingMenu = Menu.Settings;
				}
				if (option.AssociatedString == "Visual")
				{
					Menu.CurrentViewingMenu = Menu.Visual;
				}
				if (option.AssociatedString == "Back")
				{
					Menu.CurrentViewingMenu = Menu.MainMenu;
				}
				Menu.MenuState = option.AssociatedString;
				Menu.SelectedOptionIndex = 0;
			}
			if (option._type == "toggle")
			{
				if (!option.AssociatedBool)
				{
					option.AssociatedBool = true;
					Debug.Log(Object.op_Implicit($"<color=black>Toggled {option.DisplayName} : {option.AssociatedBool}</color>"));
				}
				else
				{
					option.AssociatedBool = false;
				}
			}
			if (option._type == "button")
			{
				if (option.AssociatedString == "Disconnect")
				{
					PhotonNetwork.LeaveRoom(true);
				}
				if (option.AssociatedString == "joinRandom")
				{
					PhotonNetwork.JoinRandomRoom();
				}
			}
			if (!(option._type == "button"))
			{
				return;
			}
			if (option.AssociatedString == "destroyAll")
			{
				PhotonNetwork.SetMasterClient(PhotonNetwork.get_LocalPlayer());
				foreach (Player item in (Il2CppArrayBase<Player>)(object)PhotonNetwork.get_PlayerListOthers())
				{
					PhotonNetwork.DestroyPlayerObjects(item);
				}
			}
			if (option.AssociatedString == "teleportToRandom")
			{
				Player[] array;
				array = Il2CppArrayBase<Player>.op_Implicit((Il2CppArrayBase<Player>)(object)PhotonNetwork.get_PlayerList());
				Random random;
				random = new Random();
				int num;
				num = random.Next(array.Length);
				PhotonView val;
				val = GorillaGameManager.get_instance().FindVRRigForPlayer(array[num]);
				if ((Object)(object)val != (Object)null)
				{
					((Component)Player.get_Instance()).get_transform().set_position(((Component)val).get_transform().get_position());
					((Component)Player.get_Instance()).GetComponent<Rigidbody>().set_velocity(new Vector3(0f, 0f, 0f));
				}
				foreach (MeshCollider item2 in Object.FindObjectsOfType<MeshCollider>())
				{
					((Collider)item2).set_enabled(false);
				}
			}
			if (option.AssociatedString == "Disconnect")
			{
				PhotonNetwork.LeaveRoom(true);
			}
		}
		catch
		{
		}
	}
}
