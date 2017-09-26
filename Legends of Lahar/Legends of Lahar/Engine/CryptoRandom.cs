using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Legends_Of_Lahar
{
    class CryptoRandom
    {
        private RNGCryptoServiceProvider rng;

        public CryptoRandom()
        {
            rng = new RNGCryptoServiceProvider();
        }

        public uint Next()
        {
            byte[] buffer = new byte[sizeof(uint)];
            rng.GetBytes(buffer);
            return BitConverter.ToUInt32(buffer, 0);
        }

        public uint Next(uint lowest, uint highest)
        {
            uint num = Next();

            if (num < lowest)
            {
                num += lowest;
            }
            
            if(num > highest)
            {
                num = (num / (num / highest) - (num % (highest + 1)));
            }


            return num;
        }
    }
}
