
namespace barcodeUSBRS232network
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public static string folderPath = "C:/airLeak/Result/";
        public static string barcode;
        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxSerial = new System.Windows.Forms.TextBox();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // textBoxSerial
            // 
            this.textBoxSerial.Location = new System.Drawing.Point(38, 21);
            this.textBoxSerial.Name = "textBoxSerial";
            this.textBoxSerial.Size = new System.Drawing.Size(225, 21);
            this.textBoxSerial.TabIndex = 0;
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Location = new System.Drawing.Point(107, 124);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(100, 21);
            this.textBoxBarcode.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 248);
            this.Controls.Add(this.textBoxBarcode);
            this.Controls.Add(this.textBoxSerial);
            this.Name = "Form1";
            this.Text = "AirLeak";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSerial;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RichTextBox richTextBox_received;


    }
}

