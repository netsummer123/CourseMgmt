using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseMgmt.Web
{
    public partial class ValidateCode : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //  4位数字的验证码
                string strValidateCode = GetRandomNumberString(4);
                //  用于验证的Session
                Session["Login_ValidateCode"] = strValidateCode;
                CreateImage(strValidateCode);
            }
        }

        /// <summary>
        /// 创建图片
        /// </summary>
        /// <param name="strValidateCode"></param>
        public void CreateImage(string strValidateCode)
        {
            int intImageWidth = strValidateCode.Length * 35;
            Random newRandom = new Random();
            //图高30px
            Bitmap theBitmap = new Bitmap(intImageWidth, 40);
            Graphics theGraphics = Graphics.FromImage(theBitmap);
            //白色背景
            theGraphics.Clear(GetRandomColor());
            //灰色边框
            theGraphics.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, intImageWidth, 40);

            //10pt的字体
            Font theFont = new Font("Arial", 18);

            for (int intIndex = 0; intIndex < strValidateCode.Length; intIndex++)
            {
                string strChar = strValidateCode.Substring(intIndex, 1);
                Brush newBrush = new SolidBrush(Color.White);
                Point thePos = new Point((intIndex + 1) * 15 + newRandom.Next(15), newRandom.Next(15));
                theGraphics.DrawString(strChar, theFont, newBrush, thePos);
            }

            //  将生成的图片发回客户端
            MemoryStream ms = new MemoryStream();
            theBitmap.Save(ms, ImageFormat.Png);

            Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.ToArray());
            theGraphics.Dispose();
            theBitmap.Dispose();
            Response.End();
        }

        //  生成随机数字字符串
        public static string GetRandomNumberString(int int_NumberLength)
        {
            string str_Number = string.Empty;
            Random theRandomNumber = new Random();

            for (int int_index = 0; int_index < int_NumberLength; int_index++)
                str_Number += theRandomNumber.Next(10).ToString();

            return str_Number;
        }

        /// <summary>
        /// 获取随机颜色
        /// </summary>
        /// <returns></returns>
        public static Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            int int_Red = RandomNum_First.Next(128);
            int int_Green = RandomNum_First.Next(125);
            int int_Blue = RandomNum_First.Next(125);
            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }

    }
}