using System;

namespace BaseSystem
{
    /// <summary>
    /// Pass 的摘要说明。
    /// </summary>
    public class Pass
    {
        private Pass()
        {
        }

        /// <summary>
        /// 加密程序
        /// </summary>
        /// <param name="str">加密源串</param>
        /// <returns>返回生成的加密字符串</returns>
        public static string SetPass(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            int intKey = 20050430;
            int intTimes = 10;

            byte Key1 = (byte)intKey;
            byte Key2 = (byte)(intKey >> 8);
            byte Key3 = (byte)(intKey >> 16);
            byte Key4 = (byte)(intKey >> 24);

            byte[] bytesKey = System.Text.Encoding.Default.GetBytes(str);

            int intLen = bytesKey.Length;

            string strResult = string.Empty;

            for(int i=0; i<intTimes; i++)
            {
                bytesKey[0] = (byte)(bytesKey[0] + Key3);

                for(int j=1; j<intLen; j++)
                {
                    bytesKey[j] = (byte)((bytesKey[j - 1] + bytesKey[j]) ^ Key1);
                }

                bytesKey[intLen - 1] = (byte)(bytesKey[intLen - 1] + Key4);

                for(int j=intLen-2; j>=0; j--)
                {
                    bytesKey[j] = (byte)((bytesKey[j + 1] + bytesKey[j]) ^ Key2);
                }
            }

            for(int i=0; i<intLen; i++)
            {
                strResult += bytesKey[i].ToString("X2");
            }

            return strResult;
        }

        /// <summary>
        /// 解密程序
        /// </summary>
        /// <param name="str">解密原串</param>
        /// <returns>返回生成的解密字符串</returns>
        public static string GetPass(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            int intKey = 20050430;
            int intTimes = 10;

            byte Key1 = (byte)intKey;
            byte Key2 = (byte)(intKey >> 8);
            byte Key3 = (byte)(intKey >> 16);
            byte Key4 = (byte)(intKey >> 24);
            
            int intLen = str.Length / 2;

            byte[] bytesKey = new byte[intLen];

            for(int i=0; i<intLen; i++)
            {
                bytesKey[i] = byte.Parse(str.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }

            for(int i=0; i<intTimes; i++)
            {
                for(int j=0; j<intLen-1; j++)
                {
                    bytesKey[j] = (byte)((byte)(bytesKey[j] ^ Key2) - bytesKey[j + 1]);
                }
                bytesKey[intLen-1] = (byte)(bytesKey[intLen-1] - Key4);

                for(int j=intLen-1; j>=1; j--)
                {
                    bytesKey[j] = (byte)((byte)(bytesKey[j] ^ Key1) - bytesKey[j - 1]);
                }
                bytesKey[0] = (byte)(bytesKey[0] - Key3);
            }

            return System.Text.Encoding.Default.GetString(bytesKey);
        }
    }
}
