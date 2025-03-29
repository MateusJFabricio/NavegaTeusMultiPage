namespace NavegaTeus.Views
{
    partial class FormPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.timerBtnRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerUpdate
            // 
            this.timerUpdate.Enabled = true;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(539, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 59);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chromiumWebBrowser
            // 
            this.chromiumWebBrowser.ActivateBrowserOnCreation = false;
// TODO: Falha na geração de código para '' devido à Exceção 'Tipo primitivo inválido: System.IntPtr. Considere o uso de CodeObjectCreateExpression.'.
            this.chromiumWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser.Name = "chromiumWebBrowser";
            this.chromiumWebBrowser.Size = new System.Drawing.Size(645, 414);
            this.chromiumWebBrowser.TabIndex = 3;
            // 
            // timerBtnRefresh
            // 
            this.timerBtnRefresh.Enabled = true;
            this.timerBtnRefresh.Interval = 1000;
            this.timerBtnRefresh.Tick += new System.EventHandler(this.timerBtnRefresh_Tick);
            // 
            // FormPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(645, 414);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.chromiumWebBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPage";
            this.Text = "FormPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Button btnRefresh;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser;
        private System.Windows.Forms.Timer timerBtnRefresh;
    }
}