using System;
using System.IO;
using UnityModManagerNet;

namespace T21C
{
    internal static class Loader
    {
        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                // LoadAssembly("Mods/AdofaiSRM/Newtonsoft.Json.dll");

                bool success = T21C.Load(modEntry);
                if (!success)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                modEntry.Logger.Critical(e.ToString());
                return false;
            }
        }

        private static void LoadAssembly(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                AppDomain.CurrentDomain.Load(data);
            }
        }
    }
}