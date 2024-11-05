using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USI_vanluuluong
{
    public static class ChuyenDoi
    {
        #region  -- Convert textbox to number  --
        public static double txt2Double(string str)
        {
            try
            {
                return Convert.ToDouble(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Int16 txt2Int16(string str)
        {
            str = str.Replace(".", "").Replace(",", "");
            try
            {
                return Convert.ToInt16(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Int32 txt2Int32(string str)
        {
            str = str.Replace(".", "").Replace(",", "");
            try
            {
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Int64 txt2Int64(string str)
        {
            str = str.Replace(".", "").Replace(",", "");
            try
            {
                return Convert.ToInt64(str);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        public static DataTable Cat_chuoi(string DSFile = "", string _char = ";")
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("column");
            if (DSFile != "")
            {
                string[] listFile = DSFile.ToString().Split(new char[] { Convert.ToChar(_char) });
                foreach (var file in listFile)
                {
                    if (file != "")
                    {

                        tb.Rows.Add(tb.NewRow());
                        tb.Rows[tb.Rows.Count - 1]["column"] = file;
                    }
                }
            }
            return tb;
        }
        public static double to_double(object obj)
        {
            try
            {
                return Convert.ToDouble(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double to_Int16(object obj)
        {
            try
            {
                return Convert.ToInt16(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double LayDataDouble(byte[] byteData, int viTriBatDau)
        {
            byte[] _data = new byte[4];
            _data[0] = byteData[viTriBatDau];
            _data[1] = byteData[viTriBatDau + 1];
            _data[2] = byteData[viTriBatDau + 2];
            _data[3] = byteData[viTriBatDau + 3];
            return S7.Net.Types.Double.FromByteArray(_data);
        }

        public static string LayDataString(byte[] byteData, int viTriBatDau)
        {
            int i_string;
            byte[] Lengh = { byteData[viTriBatDau + 1] };
            int Len_string = S7.Net.Types.Byte.FromByteArray(Lengh);
            if (Len_string>0)
            {
                byte[] _data = new byte[Len_string];
                for (i_string = 0; i_string < Len_string; i_string++)
                {
                    _data[i_string] = byteData[viTriBatDau + 2 + i_string];
                }
                return S7.Net.Types.String.FromByteArray(_data);
            }
            else
            {
                return "";
            }
        }

        public static int LayDataInt(byte[] byteData, int viTriBatDau)
        {
            byte[] _data = new byte[2];
            _data[0] = byteData[viTriBatDau];
            _data[1] = byteData[viTriBatDau + 1];
            return S7.Net.Types.Int.FromByteArray(_data);
        }

        public static bool LayDataBool(byte byteData, int viTriBatDau)
        {
            return S7.Net.Types.Boolean.GetValue(byteData, viTriBatDau);
        }
        public static double LayDataDWord(byte[] byteData, int viTriBatDau)
        {
            byte[] _data = new byte[4];
            _data[0] = byteData[viTriBatDau];
            _data[1] = byteData[viTriBatDau + 1];
            _data[2] = byteData[viTriBatDau + 2];
            _data[3] = byteData[viTriBatDau + 3];
            return S7.Net.Types.DWord.FromByteArray(_data);
        }

    }
}
