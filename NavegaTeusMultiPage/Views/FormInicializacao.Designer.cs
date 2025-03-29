namespace NavegaTeus
{
    partial class FormInicializacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicializacao));
            this.fontDialogDataHora = new System.Windows.Forms.FontDialog();
            this.colorDialogDataHoraFundo = new System.Windows.Forms.ColorDialog();
            this.colorDialogDataHoraLetra = new System.Windows.Forms.ColorDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAtualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemover = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInitWithWindows = new System.Windows.Forms.ToolStripButton();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndexPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UpdateFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSalvar,
            this.toolStripButtonAtualizar,
            this.toolStripButtonRemover,
            this.toolStripButtonInitWithWindows});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(761, 26);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSalvar
            // 
            this.toolStripButtonSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSalvar.Image")));
            this.toolStripButtonSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSalvar.Name = "toolStripButtonSalvar";
            this.toolStripButtonSalvar.Size = new System.Drawing.Size(49, 23);
            this.toolStripButtonSalvar.Text = "Salvar";
            this.toolStripButtonSalvar.Click += new System.EventHandler(this.toolStripButtonSalvar_Click);
            // 
            // toolStripButtonAtualizar
            // 
            this.toolStripButtonAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAtualizar.Image")));
            this.toolStripButtonAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAtualizar.Name = "toolStripButtonAtualizar";
            this.toolStripButtonAtualizar.Size = new System.Drawing.Size(66, 23);
            this.toolStripButtonAtualizar.Text = "Atualizar";
            this.toolStripButtonAtualizar.Click += new System.EventHandler(this.toolStripButtonAtualizar_Click);
            // 
            // toolStripButtonRemover
            // 
            this.toolStripButtonRemover.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRemover.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemover.Image")));
            this.toolStripButtonRemover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemover.Name = "toolStripButtonRemover";
            this.toolStripButtonRemover.Size = new System.Drawing.Size(67, 23);
            this.toolStripButtonRemover.Text = "Remover";
            this.toolStripButtonRemover.Click += new System.EventHandler(this.toolStripButtonRemover_Click);
            // 
            // toolStripButtonInitWithWindows
            // 
            this.toolStripButtonInitWithWindows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonInitWithWindows.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonInitWithWindows.Image")));
            this.toolStripButtonInitWithWindows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInitWithWindows.Name = "toolStripButtonInitWithWindows";
            this.toolStripButtonInitWithWindows.Size = new System.Drawing.Size(134, 23);
            this.toolStripButtonInitWithWindows.Text = "Inicia com Windows";
            this.toolStripButtonInitWithWindows.Click += new System.EventHandler(this.toolStripButtonInitWithWindows_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IndexPosition,
            this.url,
            this.autoUpdate,
            this.UpdateFrequency,
            this.LastUpdate});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 26);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(761, 275);
            this.dataGridView.TabIndex = 16;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // IndexPosition
            // 
            this.IndexPosition.HeaderText = "Index Position Grid";
            this.IndexPosition.Name = "IndexPosition";
            this.IndexPosition.ToolTipText = "Posição na grid";
            this.IndexPosition.Width = 50;
            // 
            // url
            // 
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.Width = 400;
            // 
            // autoUpdate
            // 
            this.autoUpdate.HeaderText = "Auto Update";
            this.autoUpdate.Name = "autoUpdate";
            this.autoUpdate.Width = 50;
            // 
            // UpdateFrequency
            // 
            this.UpdateFrequency.HeaderText = "Update Frequency";
            this.UpdateFrequency.Name = "UpdateFrequency";
            // 
            // LastUpdate
            // 
            this.LastUpdate.HeaderText = "Last Update";
            this.LastUpdate.Name = "LastUpdate";
            // 
            // FormInicializacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 301);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormInicializacao";
            this.Text = "Configuracao da Inicializacao";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FontDialog fontDialogDataHora;
        private System.Windows.Forms.ColorDialog colorDialogDataHoraFundo;
        private System.Windows.Forms.ColorDialog colorDialogDataHoraLetra;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSalvar;
        private System.Windows.Forms.ToolStripButton toolStripButtonAtualizar;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemover;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripButton toolStripButtonInitWithWindows;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autoUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
    }
}