using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace AEScrypto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    // static class that extends String by adding encrypt() and decrypt() functions
    public static class AES
    {
        static AesCryptoServiceProvider CSP = new AesCryptoServiceProvider();

        static AES()
        {
            CSP.KeySize = 256; // 128 bytes
            CSP.BlockSize = 128; // 256 bytes
            CSP.GenerateIV(); // generating random IV
            CSP.GenerateKey(); // generating random key
            CSP.Mode = CipherMode.CBC;
            CSP.Padding = PaddingMode.PKCS7; // using PKCS7 padding mode
        }

        
        /**
         * @param any size string to be encrypted
         * The function encrypts the string parameter using AES 256 encryption
         * @return base64 encrypted string 
         * */
        public static string encrypt( this string Decrypted)
        {
            ICryptoTransform trans = CSP.CreateEncryptor(); // create an ecryptor using the AesCryptoServiceProvider

            byte[] e_bytes = trans.TransformFinalBlock(ASCIIEncoding.ASCII.GetBytes(Decrypted), 0, Decrypted.Length);// convert the parameter string to byte array and use it as input buffer for Transforming final block to encrypt the byte array

            return (Convert.ToBase64String(e_bytes));//Convert byte array to base64 string and return

        }


        /**
         * @param any size string to be decrypted
         * The function decrypts the string parameter using AES 256 decryption
         * @return decrypted string 
         * */
        public static String decrypt(this string Encrypted)
        {
            ICryptoTransform trans = CSP.CreateDecryptor(); // create a decryptor

            byte[] e_bytes = Convert.FromBase64String(Encrypted); // Convert the base64 string to a byte array to be used as the input buffer for transforming the final block

            byte[] d_bytes = trans.TransformFinalBlock(e_bytes, 0, e_bytes.Length); // decrypt the parameter string's bytes

            return ASCIIEncoding.ASCII.GetString(d_bytes); // convert the decrypted byte array back to string

        }
    }
}
