using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace 登录案例
{
    public partial class WatermarkTextBox : TextBox      //将此控件的继承类型从UserControl改成TextBox。即继承TextBox控件的所有功能。

    {
        public WatermarkTextBox()

        {
            InitializeComponent();

        }

 

        private const uint ECM_FIRST = 0x1500;

        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

       

        //通过SendMessage发送EM_SETCUEBANNER消息，即可达到添加水印文字的效果。

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]

        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

 

        private string watermarkText;

        public string WatermarkText

        {
            get { return watermarkText; }

            set

            {
                watermarkText = value;

                SetWatermark(watermarkText);

            }

        }

 

        private void SetWatermark(string watermarkText)

        {
            SendMessage(this.Handle,EM_SETCUEBANNER,0,watermarkText);

        }

    }

}
