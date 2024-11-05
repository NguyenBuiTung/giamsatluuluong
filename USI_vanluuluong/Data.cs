using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USI_vanluuluong
{
    public static class Data
    {
        public static bool v1 = true;
        public static bool v2 = true;
        public static bool v3 = true;
        public static bool v4 = true;
        public static bool v5 = true;
        public static bool v6 = true;
        public static bool v7 = true;
        public static bool v8 = true;
        public static bool v9 = true;
        public static bool v10 = true;
        public static bool v11 = true;  // Thêm van 11
        public static bool v12 = true;  // Thêm van 12
        public static bool v13 = true;  // Thêm van 13
        public static bool v14 = true;  // Thêm van 14
        public static bool v15 = true;  // Thêm van 15
        public static bool v16 = true;  // Thêm van 16
        public static double llv1 = 0;
        public static double llv2 = 0;
        public static double llv3 = 0;
        public static double llv4 = 0;
        public static double llv5 = 0;
        public static double llv6 = 0;
        public static double llv7 = 0;
        public static double llv8 = 0;
        public static double llv9 = 0;
        public static double llv10 = 0;
        public static double llv11 = 0;  // Thêm lưỡng lượng cho van 11
        public static double llv12 = 0;  // Thêm lưỡng lượng cho van 12
        public static double llv13 = 0;  // Thêm lưỡng lượng cho van 13
        public static double llv14 = 0;  // Thêm lưỡng lượng cho van 14
        public static double llv15 = 0;  // Thêm lưỡng lượng cho van 15
        public static double llv16 = 0;  // Thêm lưỡng lượng cho van 16
        public static double ttv1 = 0;
        public static double ttv2 = 0;
        public static double ttv3 = 0;
        public static double ttv4 = 0;
        public static double ttv5 = 0;
        public static double ttv6 = 0;
        public static double ttv7 = 0;
        public static double ttv8 = 0;
        public static double ttv9 = 0;
        public static double ttv10 = 0;
        public static double ttv11 = 0;  // Thêm nhiệt độ cho van 11
        public static double ttv12 = 0;  // Thêm nhiệt độ cho van 12
        public static double ttv13 = 0;  // Thêm nhiệt độ cho van 13
        public static double ttv14 = 0;  // Thêm nhiệt độ cho van 14
        public static double ttv15 = 0;  // Thêm nhiệt độ cho van 15
        public static double ttv16 = 0;  // Thêm nhiệt độ cho van 16
        public static double llvT = 0;
        public static double ttvT = 0;
    }

    public static class DATA_PLC
    {
        public static byte[] Read_PLC = { };
        public static bool connect = false;
        public static bool plc_write = false;
        public static int write_data = 0;
        public static int write_length = 0;
        public static int write_return = 0;
    }
}
