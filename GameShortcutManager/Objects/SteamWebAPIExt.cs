using SteamStoreQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_Shortcut_Manager.Objects
{
    internal class SteamWebAPIExt
    {
        //https://github.com/Fluxter/SteamWebAPI
        //https://wiki.teamfortress.com/wiki/WebAPI

        internal static int GetSteamAppID(String vSearchString)
        {
            //Someone Elses: //SteamWebAPI.SetGlobalKey("CFDCF16D4EC9D68762FBE9C61B43892D");

            //SteamWebAPI.SetGlobalKey("EB11DFE13E7EA7EC1B8D26938A82F9C3");
            if (String.IsNullOrEmpty(vSearchString)) return -1;

            string searchQuery = vSearchString;
            List<Listing> results = Query.Search(searchQuery);
            //Console.WriteLine($"The first result is {results[0].Name}, and it costs ${results[0].PriceUSD}. You can find it here: {results[0].StoreLink}");
            Console.WriteLine($"The first result is {results[0].Name}, and its APP ID is {results[0].AppId}");

            //Console.ReadLine();
            if (results != null && results.Count > 0)
            {
                return results[0].AppId;
            }
            else
            {
                return -1;
            }

        }


        internal static List<Listing> GetSteamApps(String vSearchString)
        {
            //Someone Elses: //SteamWebAPI.SetGlobalKey("CFDCF16D4EC9D68762FBE9C61B43892D");

            //SteamWebAPI.SetGlobalKey("EB11DFE13E7EA7EC1B8D26938A82F9C3");
            if (String.IsNullOrEmpty(vSearchString)) return null;

            string searchQuery = vSearchString;
            List<Listing> results = Query.Search(searchQuery);
            //Console.WriteLine($"The first result is {results[0].Name}, and it costs ${results[0].PriceUSD}. You can find it here: {results[0].StoreLink}");

            return results;

        }

    }
}
