using System;
using System.Collections.Generic;

namespace dnd_character_storage.Resources.Datatypes
{

    public class character
    {

        public Dictionary<string, string> basicInfo;
        public Dictionary<string, int> wallet;

        public character(string name, string race, string alignment)
        {
            this.basicInfo.Add("name", name);
            this.basicInfo.Add("race", race);
            this.basicInfo.Add("alignment", alignment);

            this.wallet.Add("cp", 0);
            this.wallet.Add("sp", 0);
            this.wallet.Add("ep", 0);
            this.wallet.Add("pp", 0);
        }

        public void consolidateWallet()
        {
            int copper = this.wallet["cp"];
            int silver = this.wallet["sp"];
            int electrum = this.wallet["ep"];
            int platinum = this.wallet["pp"];

            while (copper >= 100)
            {
                copper -= 100;
                silver += 1;
            }
            
            while (silver >= 100)
            {
                silver -= 100;
                electrum += 1;
            }
            
            while (electrum >= 100)
            {
                electrum -= 100;
                platinum += 1;
            }

            this.wallet["cp"] = copper;
            this.wallet["sp"] = silver;
            this.wallet["ep"] = electrum;
            this.wallet["pp"] = platinum;

        }


    }

}