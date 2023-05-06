using HarmonyLib;
using System;
using UnityEngine;
using UnityModManagerNet;

namespace T21C
{
    public class T21C
    {
        internal static UnityModManager.ModEntry mod;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                mod = modEntry;

                var harmony = new Harmony("com.thijnmens.t21c");
                harmony.PatchAll();

                mod.OnGUI += (UnityModManager.ModEntry _) =>
                {
                    GUILayout.BeginHorizontal(GUILayout.Width(200f));
                    GUILayout.Label("Install T21C Webdownloader");
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal(GUILayout.Width(200f));
                    GUILayout.Label("<red>Not Installed</red>", GUILayout.Width(200f));
                    if (GUILayout.Button("Install", GUILayout.Width(100f)))
                    {
                        new Installer();
                    }
                    GUILayout.EndHorizontal();
                };

                return true;
            }
            catch (Exception e)
            {
                modEntry.Logger.Critical(e.ToString());
                return false;
            }
        }
    }
}