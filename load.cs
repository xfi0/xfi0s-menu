using System.Linq;
using easyInputs;
using Il2CppSystem;
using UnityEngine;

public static void Load()
{
	
	if (EasyInputs.GetThumbStickButtonDown((EasyHand)0) && EasyInputs.GetThumbStickButtonDown((EasyHand)1) && !menutogglecooldown)
	{
		menutogglecooldown = true;
		HUDObj2.SetActive(!HUDObj2.get_activeSelf());
		GUIToggled = !GUIToggled;
	}
	if (!EasyInputs.GetThumbStickButtonDown((EasyHand)0) && !EasyInputs.GetThumbStickButtonDown((EasyHand)1) && menutogglecooldown)
	{
		menutogglecooldown = false;
	}
	if (GUIToggled)
	{
		HUDObj2.get_transform().set_position(new Vector3(MainCamera.get_transform().get_position().x, MainCamera.get_transform().get_position().y, MainCamera.get_transform().get_position().z));
		HUDObj2.get_transform().set_rotation(MainCamera.get_transform().get_rotation());
		if (EasyInputs.GetThumbStickButtonDown((EasyHand)0))
		{
			if (EasyInputs.GetTriggerButtonDown((EasyHand)1) && !inputcooldown)
			{
				inputcooldown = true;
				if (SelectedOptionIndex + 1 == CurrentViewingMenu.Count())
				{
					SelectedOptionIndex = 0;
				}
				else
				{
					SelectedOptionIndex++;
				}
				UpdateMenuState(new MenuOption(), null, null);
			}
			if (EasyInputs.GetGripButtonDown((EasyHand)1) && !inputcooldown)
			{
				inputcooldown = true;
				UpdateMenuState(CurrentViewingMenu[SelectedOptionIndex], null, "optionhit");
			}
			if (!EasyInputs.GetTriggerButtonDown((EasyHand)1) && !EasyInputs.GetGripButtonDown((EasyHand)1) && inputcooldown)
			{
				inputcooldown = false;
			}
		}
	}
	Plugin.CrashGun = MainStuff[1].AssociatedBool;
	Plugin.vibrateCon = MainStuff[2].AssociatedBool;
	Plugin.slowAll = MainStuff[3].AssociatedBool;
	Plugin.longArms = Movement[1].AssociatedBool;
	Plugin.fly = Movement[2].AssociatedBool;
	Plugin.slowFly = Movement[6].AssociatedBool;
	Plugin.noclip = Movement[3].AssociatedBool;
	Plugin.excelfly = Movement[0].AssociatedBool;
	Plugin.TagAll = MainStuff[5].AssociatedBool;
	Plugin.noSpeedCap = Movement[4].AssociatedBool;
	Plugin.SetGameModeToHunt = MainStuff[4].AssociatedBool;
	Plugin.noclipFly = Movement[7].AssociatedBool;
	Plugin.changeGameModeToCasual = MainStuff[11].AssociatedBool;
	Plugin.matall = MainStuff[6].AssociatedBool;
	Plugin.nameSpam = MainStuff[12].AssociatedBool;
	Plugin.speedBoost = Movement[5].AssociatedBool;
	Plugin.ghostmonkey = GhostMods[0].AssociatedBool;
	Plugin.invis = GhostMods[1].AssociatedBool;
	Plugin.changeGameModeToInfect = MainStuff[9].AssociatedBool;
	Plugin.TagLag = MainStuff[8].AssociatedBool;
	Plugin.teleportGun = Movement[8].AssociatedBool;
	Plugin.wackyMonkey = GhostMods[3].AssociatedBool;
	Plugin.soundSpam = GhostMods[2].AssociatedBool;
	Plugin.TagGun = MainStuff[7].AssociatedBool;
	Plugin.rigSpam = MainStuff[10].AssociatedBool;
	Plugin.tracers = Visual[0].AssociatedBool;
	Plugin.nameTags = Visual[1].AssociatedBool;
	Plugin.createRoom = Settings[2].AssociatedBool;
	Plugin.followGun = GhostMods[5].AssociatedBool;
	Plugin.lowQualty = Visual[2].AssociatedBool;
	string text = "<color=" + MenuColour + ">Ventrald GTAG Copy Menu: " + MenuState + "</color>\n";
	int num = 0;
	if (CurrentViewingMenu != null)
	{
		MenuOption[] currentViewingMenu = CurrentViewingMenu;
		foreach (MenuOption menuOption in currentViewingMenu)
		{
			if (SelectedOptionIndex == num)
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
		Testtext.set_text(text);
	}
	else
	{
		Debug.Log(Object.op_Implicit("Null for some reason"));
	}
}
