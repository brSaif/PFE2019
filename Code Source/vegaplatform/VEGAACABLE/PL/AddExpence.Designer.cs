namespace VEGAACABLE.PL
{
    partial class AddExpence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpence));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.btnAdd = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPaymnt = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.txtDescrip = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.dwnCategories = new Bunifu.Framework.UI.BunifuDropdown();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.ButtonText = "Add New";
            this.btnAdd.ButtonTextMarginLeft = 0;
            this.btnAdd.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.btnAdd.DisabledFillColor = System.Drawing.Color.Gray;
            this.btnAdd.DisabledForecolor = System.Drawing.Color.White;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.IconPadding = 10;
            this.btnAdd.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnAdd.IdleBorderRadius = 1;
            this.btnAdd.IdleBorderThickness = 0;
            this.btnAdd.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnAdd.IdleIconLeftImage = null;
            this.btnAdd.IdleIconRightImage = null;
            this.btnAdd.Location = new System.Drawing.Point(240, 200);
            this.btnAdd.Name = "btnAdd";
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties3.BorderRadius = 1;
            stateProperties3.BorderThickness = 1;
            stateProperties3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties3.IconLeftImage = null;
            stateProperties3.IconRightImage = null;
            this.btnAdd.onHoverState = stateProperties3;
            this.btnAdd.Size = new System.Drawing.Size(106, 35);
            this.btnAdd.TabIndex = 108;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.label6.Location = new System.Drawing.Point(191, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 19);
            this.label6.TabIndex = 107;
            this.label6.Text = "Catagory";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.label7.Location = new System.Drawing.Point(23, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 19);
            this.label7.TabIndex = 105;
            this.label7.Text = "Payment";
            // 
            // txtPaymnt
            // 
            this.txtPaymnt.AcceptsReturn = false;
            this.txtPaymnt.AcceptsTab = false;
            this.txtPaymnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPaymnt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPaymnt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPaymnt.BackColor = System.Drawing.Color.Transparent;
            this.txtPaymnt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPaymnt.BackgroundImage")));
            this.txtPaymnt.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(95)))), ((int)(((byte)(113)))));
            this.txtPaymnt.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtPaymnt.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(167)))), ((int)(((byte)(171)))));
            this.txtPaymnt.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.txtPaymnt.BorderRadius = 1;
            this.txtPaymnt.BorderThickness = 1;
            this.txtPaymnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPaymnt.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymnt.DefaultText = "";
            this.txtPaymnt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtPaymnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(167)))), ((int)(((byte)(171)))));
            this.txtPaymnt.HideSelection = true;
            this.txtPaymnt.IconLeft = null;
            this.txtPaymnt.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtPaymnt.IconPadding = 8;
            this.txtPaymnt.IconRight = null;
            this.txtPaymnt.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtPaymnt.Location = new System.Drawing.Point(17, 74);
            this.txtPaymnt.MaxLength = 32767;
            this.txtPaymnt.MinimumSize = new System.Drawing.Size(100, 35);
            this.txtPaymnt.Modified = false;
            this.txtPaymnt.Name = "txtPaymnt";
            this.txtPaymnt.PasswordChar = '\0';
            this.txtPaymnt.ReadOnly = false;
            this.txtPaymnt.SelectedText = "";
            this.txtPaymnt.SelectionLength = 0;
            this.txtPaymnt.SelectionStart = 0;
            this.txtPaymnt.ShortcutsEnabled = true;
            this.txtPaymnt.Size = new System.Drawing.Size(162, 35);
            this.txtPaymnt.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtPaymnt.TabIndex = 104;
            this.txtPaymnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPaymnt.TextMarginLeft = 5;
            this.txtPaymnt.TextPlaceholder = "";
            this.txtPaymnt.UseSystemPasswordChar = false;
            this.txtPaymnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPaymnt_KeyPress);
            // 
            // txtDescrip
            // 
            this.txtDescrip.AcceptsReturn = false;
            this.txtDescrip.AcceptsTab = false;
            this.txtDescrip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDescrip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDescrip.BackColor = System.Drawing.Color.Transparent;
            this.txtDescrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtDescrip.BackgroundImage")));
            this.txtDescrip.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(95)))), ((int)(((byte)(113)))));
            this.txtDescrip.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtDescrip.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(167)))), ((int)(((byte)(171)))));
            this.txtDescrip.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.txtDescrip.BorderRadius = 1;
            this.txtDescrip.BorderThickness = 1;
            this.txtDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescrip.DefaultFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrip.DefaultText = "";
            this.txtDescrip.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtDescrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(167)))), ((int)(((byte)(171)))));
            this.txtDescrip.HideSelection = true;
            this.txtDescrip.IconLeft = null;
            this.txtDescrip.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.txtDescrip.IconPadding = 8;
            this.txtDescrip.IconRight = null;
            this.txtDescrip.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.txtDescrip.Location = new System.Drawing.Point(17, 137);
            this.txtDescrip.MaxLength = 32767;
            this.txtDescrip.MinimumSize = new System.Drawing.Size(100, 35);
            this.txtDescrip.Modified = false;
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.PasswordChar = '\0';
            this.txtDescrip.ReadOnly = false;
            this.txtDescrip.SelectedText = "";
            this.txtDescrip.SelectionLength = 0;
            this.txtDescrip.SelectionStart = 0;
            this.txtDescrip.ShortcutsEnabled = true;
            this.txtDescrip.Size = new System.Drawing.Size(329, 53);
            this.txtDescrip.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.txtDescrip.TabIndex = 111;
            this.txtDescrip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescrip.TextMarginLeft = 5;
            this.txtDescrip.TextPlaceholder = "";
            this.txtDescrip.UseSystemPasswordChar = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.label8.Location = new System.Drawing.Point(23, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 19);
            this.label8.TabIndex = 110;
            this.label8.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 124;
            this.label1.Text = "Expence";
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.ButtonText = "Cancel";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.Gray;
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.White;
            this.bunifuButton1.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.bunifuButton1.IdleBorderRadius = 1;
            this.bunifuButton1.IdleBorderThickness = 0;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.Location = new System.Drawing.Point(155, 200);
            this.bunifuButton1.Name = "bunifuButton1";
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties4.BorderRadius = 1;
            stateProperties4.BorderThickness = 1;
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties4.IconLeftImage = null;
            stateProperties4.IconRightImage = null;
            this.bunifuButton1.onHoverState = stateProperties4;
            this.bunifuButton1.Size = new System.Drawing.Size(81, 35);
            this.bunifuButton1.TabIndex = 125;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.Click += new System.EventHandler(this.BunifuButton1_Click);
            // 
            // dwnCategories
            // 
            this.dwnCategories.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dwnCategories.BackColor = System.Drawing.Color.Transparent;
            this.dwnCategories.BorderRadius = 3;
            this.dwnCategories.DisabledColor = System.Drawing.Color.Gray;
            this.dwnCategories.ForeColor = System.Drawing.Color.White;
            this.dwnCategories.items = new string[0];
            this.dwnCategories.Location = new System.Drawing.Point(185, 74);
            this.dwnCategories.Name = "dwnCategories";
            this.dwnCategories.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.dwnCategories.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.dwnCategories.selectedIndex = -1;
            this.dwnCategories.Size = new System.Drawing.Size(161, 35);
            this.dwnCategories.TabIndex = 198;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(129)))), ((int)(((byte)(3)))));
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(362, 250);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(363, 251);
            this.shapeContainer1.TabIndex = 199;
            this.shapeContainer1.TabStop = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.shapeContainer1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // AddExpence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(363, 251);
            this.Controls.Add(this.dwnCategories);
            this.Controls.Add(this.bunifuButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescrip);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPaymnt);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddExpence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddExpence";
            this.Load += new System.EventHandler(this.AddExpence_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtPaymnt;
        internal Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtDescrip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        internal Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        internal Bunifu.Framework.UI.BunifuDropdown dwnCategories;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}