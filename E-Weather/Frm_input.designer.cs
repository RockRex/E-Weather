namespace E_Weather
{
    partial class Frm_input
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
            this.label31 = new System.Windows.Forms.Label();
            this.TbInput = new System.Windows.Forms.TextBox();
            this.Btn_sure = new System.Windows.Forms.Button();
            this.Btn_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(30, 26);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(189, 20);
            this.label31.TabIndex = 0;
            this.label31.Text = "请输入要查询的城市";
            // 
            // TbInput
            // 
            this.TbInput.Location = new System.Drawing.Point(88, 95);
            this.TbInput.MaxLength = 15;
            this.TbInput.Name = "TbInput";
            this.TbInput.Size = new System.Drawing.Size(165, 25);
            this.TbInput.TabIndex = 2;
            this.TbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_year_KeyDown);
            // 
            // Btn_sure
            // 
            this.Btn_sure.Location = new System.Drawing.Point(256, 148);
            this.Btn_sure.Name = "Btn_sure";
            this.Btn_sure.Size = new System.Drawing.Size(75, 32);
            this.Btn_sure.TabIndex = 3;
            this.Btn_sure.Text = "确定";
            this.Btn_sure.UseVisualStyleBackColor = true;
            this.Btn_sure.Click += new System.EventHandler(this.Btn_sure_Click);
            // 
            // Btn_reset
            // 
            this.Btn_reset.Location = new System.Drawing.Point(31, 148);
            this.Btn_reset.Name = "Btn_reset";
            this.Btn_reset.Size = new System.Drawing.Size(75, 32);
            this.Btn_reset.TabIndex = 4;
            this.Btn_reset.Text = "重置";
            this.Btn_reset.UseVisualStyleBackColor = true;
            this.Btn_reset.Click += new System.EventHandler(this.Btn_reset_Click);
            // 
            // Frm_input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 192);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_reset);
            this.Controls.Add(this.Btn_sure);
            this.Controls.Add(this.TbInput);
            this.Controls.Add(this.label31);
            this.Name = "Frm_input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TbInput;
        private System.Windows.Forms.Button Btn_sure;
        private System.Windows.Forms.Button Btn_reset;
    }
}