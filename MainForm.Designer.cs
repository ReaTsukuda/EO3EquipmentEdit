namespace EO3EquipmentEdit
{
  partial class MainForm
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
      // Disposing manual elements from the main file go here.
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.menu = new System.Windows.Forms.MenuStrip();
      this.formLayout = new System.Windows.Forms.FlowLayoutPanel();
      this.equipmentSelectionControls = new System.Windows.Forms.TableLayoutPanel();
      this.equipmentList = new System.Windows.Forms.ListBox();
      this.equipmentTypeFilter = new System.Windows.Forms.ComboBox();
      this.includeDummyItems = new System.Windows.Forms.CheckBox();
      this.nameAndTypeLayout = new System.Windows.Forms.TableLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.itemName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.itemType = new System.Windows.Forms.ComboBox();
      this.namePreviewPanel = new System.Windows.Forms.Panel();
      this.ATKDEFEntryPanel = new System.Windows.Forms.TableLayoutPanel();
      this.physicalLabel = new System.Windows.Forms.Label();
      this.magicLabel = new System.Windows.Forms.Label();
      this.physicalEntry = new System.Windows.Forms.NumericUpDown();
      this.magicEntry = new System.Windows.Forms.NumericUpDown();
      this.formLayout.SuspendLayout();
      this.equipmentSelectionControls.SuspendLayout();
      this.nameAndTypeLayout.SuspendLayout();
      this.ATKDEFEntryPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.physicalEntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.magicEntry)).BeginInit();
      this.SuspendLayout();
      // 
      // menu
      // 
      this.menu.Location = new System.Drawing.Point(0, 0);
      this.menu.Name = "menu";
      this.menu.Size = new System.Drawing.Size(800, 24);
      this.menu.TabIndex = 0;
      this.menu.Text = "menuStrip1";
      // 
      // formLayout
      // 
      this.formLayout.Controls.Add(this.equipmentSelectionControls);
      this.formLayout.Controls.Add(this.nameAndTypeLayout);
      this.formLayout.Controls.Add(this.namePreviewPanel);
      this.formLayout.Controls.Add(this.ATKDEFEntryPanel);
      this.formLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.formLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.formLayout.Location = new System.Drawing.Point(0, 24);
      this.formLayout.Name = "formLayout";
      this.formLayout.Size = new System.Drawing.Size(800, 519);
      this.formLayout.TabIndex = 5;
      // 
      // equipmentSelectionControls
      // 
      this.equipmentSelectionControls.AutoSize = true;
      this.equipmentSelectionControls.ColumnCount = 1;
      this.equipmentSelectionControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.equipmentSelectionControls.Controls.Add(this.equipmentList, 0, 2);
      this.equipmentSelectionControls.Controls.Add(this.equipmentTypeFilter, 0, 0);
      this.equipmentSelectionControls.Controls.Add(this.includeDummyItems, 0, 1);
      this.equipmentSelectionControls.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.formLayout.SetFlowBreak(this.equipmentSelectionControls, true);
      this.equipmentSelectionControls.Location = new System.Drawing.Point(3, 3);
      this.equipmentSelectionControls.Name = "equipmentSelectionControls";
      this.equipmentSelectionControls.RowCount = 3;
      this.equipmentSelectionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.equipmentSelectionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.equipmentSelectionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.equipmentSelectionControls.Size = new System.Drawing.Size(131, 515);
      this.equipmentSelectionControls.TabIndex = 1;
      // 
      // equipmentList
      // 
      this.equipmentList.FormattingEnabled = true;
      this.equipmentList.Location = new System.Drawing.Point(3, 53);
      this.equipmentList.Name = "equipmentList";
      this.equipmentList.Size = new System.Drawing.Size(124, 459);
      this.equipmentList.TabIndex = 8;
      // 
      // equipmentTypeFilter
      // 
      this.equipmentTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.equipmentTypeFilter.FormattingEnabled = true;
      this.equipmentTypeFilter.Location = new System.Drawing.Point(3, 3);
      this.equipmentTypeFilter.Name = "equipmentTypeFilter";
      this.equipmentTypeFilter.Size = new System.Drawing.Size(125, 21);
      this.equipmentTypeFilter.TabIndex = 5;
      // 
      // includeDummyItems
      // 
      this.includeDummyItems.AutoSize = true;
      this.includeDummyItems.Location = new System.Drawing.Point(3, 30);
      this.includeDummyItems.Name = "includeDummyItems";
      this.includeDummyItems.Size = new System.Drawing.Size(124, 17);
      this.includeDummyItems.TabIndex = 7;
      this.includeDummyItems.Text = "Include dummy items";
      this.includeDummyItems.UseVisualStyleBackColor = true;
      // 
      // nameAndTypeLayout
      // 
      this.nameAndTypeLayout.ColumnCount = 2;
      this.nameAndTypeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.nameAndTypeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.nameAndTypeLayout.Controls.Add(this.label1, 0, 0);
      this.nameAndTypeLayout.Controls.Add(this.itemName, 1, 0);
      this.nameAndTypeLayout.Controls.Add(this.label2, 0, 1);
      this.nameAndTypeLayout.Controls.Add(this.itemType, 1, 1);
      this.nameAndTypeLayout.Location = new System.Drawing.Point(140, 3);
      this.nameAndTypeLayout.Name = "nameAndTypeLayout";
      this.nameAndTypeLayout.RowCount = 2;
      this.nameAndTypeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.nameAndTypeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.nameAndTypeLayout.Size = new System.Drawing.Size(144, 54);
      this.nameAndTypeLayout.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 26);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // itemName
      // 
      this.itemName.Enabled = false;
      this.itemName.Location = new System.Drawing.Point(44, 3);
      this.itemName.Name = "itemName";
      this.itemName.Size = new System.Drawing.Size(100, 20);
      this.itemName.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Location = new System.Drawing.Point(3, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 28);
      this.label2.TabIndex = 2;
      this.label2.Text = "Type";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // itemType
      // 
      this.itemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.itemType.Enabled = false;
      this.itemType.FormattingEnabled = true;
      this.itemType.Location = new System.Drawing.Point(44, 29);
      this.itemType.Name = "itemType";
      this.itemType.Size = new System.Drawing.Size(100, 21);
      this.itemType.TabIndex = 3;
      // 
      // namePreviewPanel
      // 
      this.namePreviewPanel.Location = new System.Drawing.Point(140, 63);
      this.namePreviewPanel.Name = "namePreviewPanel";
      this.namePreviewPanel.Size = new System.Drawing.Size(144, 20);
      this.namePreviewPanel.TabIndex = 3;
      // 
      // ATKDEFEntryPanel
      // 
      this.ATKDEFEntryPanel.ColumnCount = 2;
      this.ATKDEFEntryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.55556F));
      this.ATKDEFEntryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.44444F));
      this.ATKDEFEntryPanel.Controls.Add(this.physicalLabel, 0, 0);
      this.ATKDEFEntryPanel.Controls.Add(this.magicLabel, 0, 1);
      this.ATKDEFEntryPanel.Controls.Add(this.physicalEntry, 1, 0);
      this.ATKDEFEntryPanel.Controls.Add(this.magicEntry, 1, 1);
      this.ATKDEFEntryPanel.Location = new System.Drawing.Point(140, 89);
      this.ATKDEFEntryPanel.Name = "ATKDEFEntryPanel";
      this.ATKDEFEntryPanel.RowCount = 2;
      this.ATKDEFEntryPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ATKDEFEntryPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ATKDEFEntryPanel.Size = new System.Drawing.Size(144, 47);
      this.ATKDEFEntryPanel.TabIndex = 4;
      // 
      // physicalLabel
      // 
      this.physicalLabel.AutoSize = true;
      this.physicalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.physicalLabel.Location = new System.Drawing.Point(3, 0);
      this.physicalLabel.Name = "physicalLabel";
      this.physicalLabel.Size = new System.Drawing.Size(38, 23);
      this.physicalLabel.TabIndex = 0;
      this.physicalLabel.Text = "PATK";
      this.physicalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // magicLabel
      // 
      this.magicLabel.AutoSize = true;
      this.magicLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.magicLabel.Location = new System.Drawing.Point(3, 23);
      this.magicLabel.Name = "magicLabel";
      this.magicLabel.Size = new System.Drawing.Size(38, 24);
      this.magicLabel.TabIndex = 1;
      this.magicLabel.Text = "MATK";
      this.magicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // physicalEntry
      // 
      this.physicalEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.physicalEntry.Location = new System.Drawing.Point(47, 3);
      this.physicalEntry.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.physicalEntry.Name = "physicalEntry";
      this.physicalEntry.Size = new System.Drawing.Size(94, 20);
      this.physicalEntry.TabIndex = 2;
      this.physicalEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // magicEntry
      // 
      this.magicEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.magicEntry.Location = new System.Drawing.Point(47, 26);
      this.magicEntry.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.magicEntry.Name = "magicEntry";
      this.magicEntry.Size = new System.Drawing.Size(94, 20);
      this.magicEntry.TabIndex = 3;
      this.magicEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 543);
      this.Controls.Add(this.formLayout);
      this.Controls.Add(this.menu);
      this.MainMenuStrip = this.menu;
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.formLayout.ResumeLayout(false);
      this.formLayout.PerformLayout();
      this.equipmentSelectionControls.ResumeLayout(false);
      this.equipmentSelectionControls.PerformLayout();
      this.nameAndTypeLayout.ResumeLayout(false);
      this.nameAndTypeLayout.PerformLayout();
      this.ATKDEFEntryPanel.ResumeLayout(false);
      this.ATKDEFEntryPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.physicalEntry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.magicEntry)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menu;
    private System.Windows.Forms.FlowLayoutPanel formLayout;
    private System.Windows.Forms.TableLayoutPanel equipmentSelectionControls;
    private System.Windows.Forms.ListBox equipmentList;
    private System.Windows.Forms.ComboBox equipmentTypeFilter;
    private System.Windows.Forms.CheckBox includeDummyItems;
    private System.Windows.Forms.TableLayoutPanel nameAndTypeLayout;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox itemName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox itemType;
    private System.Windows.Forms.Panel namePreviewPanel;
    private System.Windows.Forms.TableLayoutPanel ATKDEFEntryPanel;
    private System.Windows.Forms.Label physicalLabel;
    private System.Windows.Forms.Label magicLabel;
    private System.Windows.Forms.NumericUpDown physicalEntry;
    private System.Windows.Forms.NumericUpDown magicEntry;
  }
}