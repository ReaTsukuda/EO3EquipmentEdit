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
      this.nameLabel = new System.Windows.Forms.Label();
      this.itemName = new System.Windows.Forms.TextBox();
      this.typeLabel = new System.Windows.Forms.Label();
      this.itemType = new System.Windows.Forms.ComboBox();
      this.namePreviewPanel = new System.Windows.Forms.Panel();
      this.ATKDEFEntryPanel = new System.Windows.Forms.TableLayoutPanel();
      this.physicalLabel = new System.Windows.Forms.Label();
      this.magicLabel = new System.Windows.Forms.Label();
      this.physicalEntry = new System.Windows.Forms.NumericUpDown();
      this.magicEntry = new System.Windows.Forms.NumericUpDown();
      this.statBonusGroup = new System.Windows.Forms.GroupBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.LUCEntry = new System.Windows.Forms.NumericUpDown();
      this.AGIEntry = new System.Windows.Forms.NumericUpDown();
      this.WISEntry = new System.Windows.Forms.NumericUpDown();
      this.VITEntry = new System.Windows.Forms.NumericUpDown();
      this.TECEntry = new System.Windows.Forms.NumericUpDown();
      this.STREntry = new System.Windows.Forms.NumericUpDown();
      this.TPEntry = new System.Windows.Forms.NumericUpDown();
      this.HPEntry = new System.Windows.Forms.NumericUpDown();
      this.HPLabel = new System.Windows.Forms.Label();
      this.TPLabel = new System.Windows.Forms.Label();
      this.STRLabel = new System.Windows.Forms.Label();
      this.TECLabel = new System.Windows.Forms.Label();
      this.VITLabel = new System.Windows.Forms.Label();
      this.WISLabel = new System.Windows.Forms.Label();
      this.AGILabel = new System.Windows.Forms.Label();
      this.LUCLabel = new System.Windows.Forms.Label();
      this.classGroup = new System.Windows.Forms.GroupBox();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.princess = new System.Windows.Forms.CheckBox();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkBox3 = new System.Windows.Forms.CheckBox();
      this.checkBox4 = new System.Windows.Forms.CheckBox();
      this.checkBox5 = new System.Windows.Forms.CheckBox();
      this.checkBox6 = new System.Windows.Forms.CheckBox();
      this.checkBox7 = new System.Windows.Forms.CheckBox();
      this.checkBox8 = new System.Windows.Forms.CheckBox();
      this.checkBox9 = new System.Windows.Forms.CheckBox();
      this.checkBox10 = new System.Windows.Forms.CheckBox();
      this.checkBox11 = new System.Windows.Forms.CheckBox();
      this.flags = new System.Windows.Forms.FlowLayoutPanel();
      this.requiresRestock = new System.Windows.Forms.CheckBox();
      this.goldIcon = new System.Windows.Forms.CheckBox();
      this.starterEquipment = new System.Windows.Forms.CheckBox();
      this.priceTable = new System.Windows.Forms.TableLayoutPanel();
      this.priceLabel = new System.Windows.Forms.Label();
      this.priceEntry = new System.Windows.Forms.NumericUpDown();
      this.formLayout.SuspendLayout();
      this.equipmentSelectionControls.SuspendLayout();
      this.nameAndTypeLayout.SuspendLayout();
      this.ATKDEFEntryPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.physicalEntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.magicEntry)).BeginInit();
      this.statBonusGroup.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LUCEntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.AGIEntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.WISEntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.VITEntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TECEntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.STREntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TPEntry)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.HPEntry)).BeginInit();
      this.classGroup.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.flags.SuspendLayout();
      this.priceTable.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.priceEntry)).BeginInit();
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
      this.formLayout.Controls.Add(this.statBonusGroup);
      this.formLayout.Controls.Add(this.priceTable);
      this.formLayout.Controls.Add(this.classGroup);
      this.formLayout.Controls.Add(this.flags);
      this.formLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.formLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.formLayout.Location = new System.Drawing.Point(0, 24);
      this.formLayout.Name = "formLayout";
      this.formLayout.Size = new System.Drawing.Size(800, 379);
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
      this.formLayout.SetFlowBreak(this.equipmentSelectionControls, true);
      this.equipmentSelectionControls.Location = new System.Drawing.Point(3, 3);
      this.equipmentSelectionControls.Name = "equipmentSelectionControls";
      this.equipmentSelectionControls.RowCount = 3;
      this.equipmentSelectionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.equipmentSelectionControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.equipmentSelectionControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.equipmentSelectionControls.Size = new System.Drawing.Size(131, 372);
      this.equipmentSelectionControls.TabIndex = 1;
      // 
      // equipmentList
      // 
      this.equipmentList.FormattingEnabled = true;
      this.equipmentList.Location = new System.Drawing.Point(3, 53);
      this.equipmentList.Name = "equipmentList";
      this.equipmentList.Size = new System.Drawing.Size(124, 316);
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
      this.nameAndTypeLayout.Controls.Add(this.nameLabel, 0, 0);
      this.nameAndTypeLayout.Controls.Add(this.itemName, 1, 0);
      this.nameAndTypeLayout.Controls.Add(this.typeLabel, 0, 1);
      this.nameAndTypeLayout.Controls.Add(this.itemType, 1, 1);
      this.nameAndTypeLayout.Location = new System.Drawing.Point(140, 3);
      this.nameAndTypeLayout.Name = "nameAndTypeLayout";
      this.nameAndTypeLayout.RowCount = 2;
      this.nameAndTypeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.nameAndTypeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.nameAndTypeLayout.Size = new System.Drawing.Size(123, 54);
      this.nameAndTypeLayout.TabIndex = 2;
      // 
      // nameLabel
      // 
      this.nameLabel.AutoSize = true;
      this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.nameLabel.Location = new System.Drawing.Point(3, 0);
      this.nameLabel.Name = "nameLabel";
      this.nameLabel.Size = new System.Drawing.Size(35, 26);
      this.nameLabel.TabIndex = 0;
      this.nameLabel.Text = "Name";
      this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // itemName
      // 
      this.itemName.Enabled = false;
      this.itemName.Location = new System.Drawing.Point(44, 3);
      this.itemName.Name = "itemName";
      this.itemName.Size = new System.Drawing.Size(79, 20);
      this.itemName.TabIndex = 1;
      // 
      // typeLabel
      // 
      this.typeLabel.AutoSize = true;
      this.typeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.typeLabel.Location = new System.Drawing.Point(3, 26);
      this.typeLabel.Name = "typeLabel";
      this.typeLabel.Size = new System.Drawing.Size(35, 28);
      this.typeLabel.TabIndex = 2;
      this.typeLabel.Text = "Type";
      this.typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // itemType
      // 
      this.itemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.itemType.Enabled = false;
      this.itemType.FormattingEnabled = true;
      this.itemType.Location = new System.Drawing.Point(44, 29);
      this.itemType.Name = "itemType";
      this.itemType.Size = new System.Drawing.Size(79, 21);
      this.itemType.TabIndex = 3;
      // 
      // namePreviewPanel
      // 
      this.namePreviewPanel.Location = new System.Drawing.Point(140, 63);
      this.namePreviewPanel.Name = "namePreviewPanel";
      this.namePreviewPanel.Size = new System.Drawing.Size(123, 20);
      this.namePreviewPanel.TabIndex = 3;
      // 
      // ATKDEFEntryPanel
      // 
      this.ATKDEFEntryPanel.ColumnCount = 2;
      this.ATKDEFEntryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.77236F));
      this.ATKDEFEntryPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.22765F));
      this.ATKDEFEntryPanel.Controls.Add(this.physicalLabel, 0, 0);
      this.ATKDEFEntryPanel.Controls.Add(this.magicLabel, 0, 1);
      this.ATKDEFEntryPanel.Controls.Add(this.physicalEntry, 1, 0);
      this.ATKDEFEntryPanel.Controls.Add(this.magicEntry, 1, 1);
      this.ATKDEFEntryPanel.Location = new System.Drawing.Point(140, 89);
      this.ATKDEFEntryPanel.Name = "ATKDEFEntryPanel";
      this.ATKDEFEntryPanel.RowCount = 2;
      this.ATKDEFEntryPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ATKDEFEntryPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ATKDEFEntryPanel.Size = new System.Drawing.Size(123, 47);
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
      this.physicalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
      this.magicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
      this.physicalEntry.Size = new System.Drawing.Size(73, 20);
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
      this.magicEntry.Size = new System.Drawing.Size(73, 20);
      this.magicEntry.TabIndex = 3;
      this.magicEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // statBonusGroup
      // 
      this.statBonusGroup.Controls.Add(this.tableLayoutPanel1);
      this.statBonusGroup.Enabled = false;
      this.statBonusGroup.Location = new System.Drawing.Point(140, 142);
      this.statBonusGroup.Name = "statBonusGroup";
      this.statBonusGroup.Size = new System.Drawing.Size(123, 228);
      this.statBonusGroup.TabIndex = 5;
      this.statBonusGroup.TabStop = false;
      this.statBonusGroup.Text = "Stat Bonuses";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.04274F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.95727F));
      this.tableLayoutPanel1.Controls.Add(this.LUCEntry, 1, 7);
      this.tableLayoutPanel1.Controls.Add(this.AGIEntry, 1, 6);
      this.tableLayoutPanel1.Controls.Add(this.WISEntry, 1, 5);
      this.tableLayoutPanel1.Controls.Add(this.VITEntry, 1, 4);
      this.tableLayoutPanel1.Controls.Add(this.TECEntry, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.STREntry, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.TPEntry, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.HPEntry, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.HPLabel, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.TPLabel, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.STRLabel, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.TECLabel, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.VITLabel, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.WISLabel, 0, 5);
      this.tableLayoutPanel1.Controls.Add(this.AGILabel, 0, 6);
      this.tableLayoutPanel1.Controls.Add(this.LUCLabel, 0, 7);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 8;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(117, 209);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // LUCEntry
      // 
      this.LUCEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LUCEntry.Location = new System.Drawing.Point(44, 185);
      this.LUCEntry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.LUCEntry.Name = "LUCEntry";
      this.LUCEntry.Size = new System.Drawing.Size(70, 20);
      this.LUCEntry.TabIndex = 15;
      this.LUCEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // AGIEntry
      // 
      this.AGIEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AGIEntry.Location = new System.Drawing.Point(44, 159);
      this.AGIEntry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.AGIEntry.Name = "AGIEntry";
      this.AGIEntry.Size = new System.Drawing.Size(70, 20);
      this.AGIEntry.TabIndex = 14;
      this.AGIEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // WISEntry
      // 
      this.WISEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.WISEntry.Location = new System.Drawing.Point(44, 133);
      this.WISEntry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.WISEntry.Name = "WISEntry";
      this.WISEntry.Size = new System.Drawing.Size(70, 20);
      this.WISEntry.TabIndex = 13;
      this.WISEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // VITEntry
      // 
      this.VITEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.VITEntry.Location = new System.Drawing.Point(44, 107);
      this.VITEntry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.VITEntry.Name = "VITEntry";
      this.VITEntry.Size = new System.Drawing.Size(70, 20);
      this.VITEntry.TabIndex = 12;
      this.VITEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // TECEntry
      // 
      this.TECEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TECEntry.Location = new System.Drawing.Point(44, 81);
      this.TECEntry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.TECEntry.Name = "TECEntry";
      this.TECEntry.Size = new System.Drawing.Size(70, 20);
      this.TECEntry.TabIndex = 11;
      this.TECEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // STREntry
      // 
      this.STREntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.STREntry.Location = new System.Drawing.Point(44, 55);
      this.STREntry.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.STREntry.Name = "STREntry";
      this.STREntry.Size = new System.Drawing.Size(70, 20);
      this.STREntry.TabIndex = 10;
      this.STREntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // TPEntry
      // 
      this.TPEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TPEntry.Location = new System.Drawing.Point(44, 29);
      this.TPEntry.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
      this.TPEntry.Name = "TPEntry";
      this.TPEntry.Size = new System.Drawing.Size(70, 20);
      this.TPEntry.TabIndex = 9;
      this.TPEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // HPEntry
      // 
      this.HPEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.HPEntry.Location = new System.Drawing.Point(44, 3);
      this.HPEntry.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
      this.HPEntry.Name = "HPEntry";
      this.HPEntry.Size = new System.Drawing.Size(70, 20);
      this.HPEntry.TabIndex = 8;
      this.HPEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // HPLabel
      // 
      this.HPLabel.AutoSize = true;
      this.HPLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.HPLabel.Location = new System.Drawing.Point(3, 0);
      this.HPLabel.Name = "HPLabel";
      this.HPLabel.Size = new System.Drawing.Size(35, 26);
      this.HPLabel.TabIndex = 0;
      this.HPLabel.Text = "HP";
      this.HPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // TPLabel
      // 
      this.TPLabel.AutoSize = true;
      this.TPLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TPLabel.Location = new System.Drawing.Point(3, 26);
      this.TPLabel.Name = "TPLabel";
      this.TPLabel.Size = new System.Drawing.Size(35, 26);
      this.TPLabel.TabIndex = 1;
      this.TPLabel.Text = "TP";
      this.TPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // STRLabel
      // 
      this.STRLabel.AutoSize = true;
      this.STRLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.STRLabel.Location = new System.Drawing.Point(3, 52);
      this.STRLabel.Name = "STRLabel";
      this.STRLabel.Size = new System.Drawing.Size(35, 26);
      this.STRLabel.TabIndex = 2;
      this.STRLabel.Text = "STR";
      this.STRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // TECLabel
      // 
      this.TECLabel.AutoSize = true;
      this.TECLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TECLabel.Location = new System.Drawing.Point(3, 78);
      this.TECLabel.Name = "TECLabel";
      this.TECLabel.Size = new System.Drawing.Size(35, 26);
      this.TECLabel.TabIndex = 3;
      this.TECLabel.Text = "TEC";
      this.TECLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // VITLabel
      // 
      this.VITLabel.AutoSize = true;
      this.VITLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.VITLabel.Location = new System.Drawing.Point(3, 104);
      this.VITLabel.Name = "VITLabel";
      this.VITLabel.Size = new System.Drawing.Size(35, 26);
      this.VITLabel.TabIndex = 4;
      this.VITLabel.Text = "VIT";
      this.VITLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // WISLabel
      // 
      this.WISLabel.AutoSize = true;
      this.WISLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.WISLabel.Location = new System.Drawing.Point(3, 130);
      this.WISLabel.Name = "WISLabel";
      this.WISLabel.Size = new System.Drawing.Size(35, 26);
      this.WISLabel.TabIndex = 5;
      this.WISLabel.Text = "WIS";
      this.WISLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // AGILabel
      // 
      this.AGILabel.AutoSize = true;
      this.AGILabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.AGILabel.Location = new System.Drawing.Point(3, 156);
      this.AGILabel.Name = "AGILabel";
      this.AGILabel.Size = new System.Drawing.Size(35, 26);
      this.AGILabel.TabIndex = 6;
      this.AGILabel.Text = "AGI";
      this.AGILabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // LUCLabel
      // 
      this.LUCLabel.AutoSize = true;
      this.LUCLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LUCLabel.Location = new System.Drawing.Point(3, 182);
      this.LUCLabel.Name = "LUCLabel";
      this.LUCLabel.Size = new System.Drawing.Size(35, 27);
      this.LUCLabel.TabIndex = 7;
      this.LUCLabel.Text = "LUC";
      this.LUCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // classGroup
      // 
      this.classGroup.Controls.Add(this.flowLayoutPanel1);
      this.classGroup.Location = new System.Drawing.Point(269, 32);
      this.classGroup.Name = "classGroup";
      this.classGroup.Size = new System.Drawing.Size(164, 164);
      this.classGroup.TabIndex = 7;
      this.classGroup.TabStop = false;
      this.classGroup.Text = "Classes That Can Equip This";
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.Controls.Add(this.princess);
      this.flowLayoutPanel1.Controls.Add(this.checkBox1);
      this.flowLayoutPanel1.Controls.Add(this.checkBox2);
      this.flowLayoutPanel1.Controls.Add(this.checkBox3);
      this.flowLayoutPanel1.Controls.Add(this.checkBox4);
      this.flowLayoutPanel1.Controls.Add(this.checkBox5);
      this.flowLayoutPanel1.Controls.Add(this.checkBox6);
      this.flowLayoutPanel1.Controls.Add(this.checkBox7);
      this.flowLayoutPanel1.Controls.Add(this.checkBox8);
      this.flowLayoutPanel1.Controls.Add(this.checkBox9);
      this.flowLayoutPanel1.Controls.Add(this.checkBox10);
      this.flowLayoutPanel1.Controls.Add(this.checkBox11);
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(158, 145);
      this.flowLayoutPanel1.TabIndex = 0;
      // 
      // princess
      // 
      this.princess.AutoSize = true;
      this.princess.Location = new System.Drawing.Point(3, 3);
      this.princess.Name = "princess";
      this.princess.Size = new System.Drawing.Size(66, 17);
      this.princess.TabIndex = 12;
      this.princess.Text = "Princess";
      this.princess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.princess.UseVisualStyleBackColor = true;
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(3, 26);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(68, 17);
      this.checkBox1.TabIndex = 13;
      this.checkBox1.Text = "Gladiator";
      this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point(3, 49);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(59, 17);
      this.checkBox2.TabIndex = 14;
      this.checkBox2.Text = "Hoplite";
      this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox2.UseVisualStyleBackColor = true;
      // 
      // checkBox3
      // 
      this.checkBox3.AutoSize = true;
      this.checkBox3.Location = new System.Drawing.Point(3, 72);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new System.Drawing.Size(78, 17);
      this.checkBox3.TabIndex = 15;
      this.checkBox3.Text = "Buccaneer";
      this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox3.UseVisualStyleBackColor = true;
      // 
      // checkBox4
      // 
      this.checkBox4.AutoSize = true;
      this.checkBox4.Location = new System.Drawing.Point(3, 95);
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.Size = new System.Drawing.Size(50, 17);
      this.checkBox4.TabIndex = 16;
      this.checkBox4.Text = "Ninja";
      this.checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox4.UseVisualStyleBackColor = true;
      // 
      // checkBox5
      // 
      this.checkBox5.AutoSize = true;
      this.checkBox5.Location = new System.Drawing.Point(3, 118);
      this.checkBox5.Name = "checkBox5";
      this.checkBox5.Size = new System.Drawing.Size(53, 17);
      this.checkBox5.TabIndex = 17;
      this.checkBox5.Text = "Monk";
      this.checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox5.UseVisualStyleBackColor = true;
      // 
      // checkBox6
      // 
      this.checkBox6.AutoSize = true;
      this.checkBox6.Location = new System.Drawing.Point(87, 3);
      this.checkBox6.Name = "checkBox6";
      this.checkBox6.Size = new System.Drawing.Size(59, 17);
      this.checkBox6.TabIndex = 18;
      this.checkBox6.Text = "Zodiac";
      this.checkBox6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox6.UseVisualStyleBackColor = true;
      // 
      // checkBox7
      // 
      this.checkBox7.AutoSize = true;
      this.checkBox7.Location = new System.Drawing.Point(87, 26);
      this.checkBox7.Name = "checkBox7";
      this.checkBox7.Size = new System.Drawing.Size(63, 17);
      this.checkBox7.TabIndex = 19;
      this.checkBox7.Text = "Wildling";
      this.checkBox7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox7.UseVisualStyleBackColor = true;
      // 
      // checkBox8
      // 
      this.checkBox8.AutoSize = true;
      this.checkBox8.Location = new System.Drawing.Point(87, 49);
      this.checkBox8.Name = "checkBox8";
      this.checkBox8.Size = new System.Drawing.Size(60, 17);
      this.checkBox8.TabIndex = 20;
      this.checkBox8.Text = "Arbalist";
      this.checkBox8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox8.UseVisualStyleBackColor = true;
      // 
      // checkBox9
      // 
      this.checkBox9.AutoSize = true;
      this.checkBox9.Location = new System.Drawing.Point(87, 72);
      this.checkBox9.Name = "checkBox9";
      this.checkBox9.Size = new System.Drawing.Size(58, 17);
      this.checkBox9.TabIndex = 21;
      this.checkBox9.Text = "Farmer";
      this.checkBox9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox9.UseVisualStyleBackColor = true;
      // 
      // checkBox10
      // 
      this.checkBox10.AutoSize = true;
      this.checkBox10.Location = new System.Drawing.Point(87, 95);
      this.checkBox10.Name = "checkBox10";
      this.checkBox10.Size = new System.Drawing.Size(63, 17);
      this.checkBox10.TabIndex = 22;
      this.checkBox10.Text = "Shogun";
      this.checkBox10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox10.UseVisualStyleBackColor = true;
      // 
      // checkBox11
      // 
      this.checkBox11.AutoSize = true;
      this.checkBox11.Location = new System.Drawing.Point(87, 118);
      this.checkBox11.Name = "checkBox11";
      this.checkBox11.Size = new System.Drawing.Size(68, 17);
      this.checkBox11.TabIndex = 23;
      this.checkBox11.Text = "Yggdroid";
      this.checkBox11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBox11.UseVisualStyleBackColor = true;
      // 
      // flags
      // 
      this.flags.AutoSize = true;
      this.flags.Controls.Add(this.requiresRestock);
      this.flags.Controls.Add(this.goldIcon);
      this.flags.Controls.Add(this.starterEquipment);
      this.flags.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flags.Location = new System.Drawing.Point(269, 202);
      this.flags.Name = "flags";
      this.flags.Size = new System.Drawing.Size(125, 69);
      this.flags.TabIndex = 8;
      // 
      // requiresRestock
      // 
      this.requiresRestock.AutoSize = true;
      this.requiresRestock.Location = new System.Drawing.Point(3, 3);
      this.requiresRestock.Name = "requiresRestock";
      this.requiresRestock.Size = new System.Drawing.Size(119, 17);
      this.requiresRestock.TabIndex = 0;
      this.requiresRestock.Text = "Consumes materials";
      this.requiresRestock.UseVisualStyleBackColor = true;
      // 
      // goldIcon
      // 
      this.goldIcon.AutoSize = true;
      this.goldIcon.Location = new System.Drawing.Point(3, 26);
      this.goldIcon.Name = "goldIcon";
      this.goldIcon.Size = new System.Drawing.Size(100, 17);
      this.goldIcon.TabIndex = 1;
      this.goldIcon.Text = "Has a gold icon";
      this.goldIcon.UseVisualStyleBackColor = true;
      // 
      // starterEquipment
      // 
      this.starterEquipment.AutoSize = true;
      this.starterEquipment.Location = new System.Drawing.Point(3, 49);
      this.starterEquipment.Name = "starterEquipment";
      this.starterEquipment.Size = new System.Drawing.Size(109, 17);
      this.starterEquipment.TabIndex = 2;
      this.starterEquipment.Text = "Starter equipment";
      this.starterEquipment.UseVisualStyleBackColor = true;
      // 
      // priceTable
      // 
      this.priceTable.ColumnCount = 2;
      this.priceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.priceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
      this.priceTable.Controls.Add(this.priceEntry, 1, 0);
      this.priceTable.Controls.Add(this.priceLabel, 0, 0);
      this.priceTable.Location = new System.Drawing.Point(269, 3);
      this.priceTable.Name = "priceTable";
      this.priceTable.RowCount = 1;
      this.priceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.priceTable.Size = new System.Drawing.Size(164, 23);
      this.priceTable.TabIndex = 9;
      // 
      // priceLabel
      // 
      this.priceLabel.AutoSize = true;
      this.priceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.priceLabel.Location = new System.Drawing.Point(3, 0);
      this.priceLabel.Name = "priceLabel";
      this.priceLabel.Size = new System.Drawing.Size(35, 23);
      this.priceLabel.TabIndex = 0;
      this.priceLabel.Text = "Price";
      this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // priceEntry
      // 
      this.priceEntry.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.priceEntry.Location = new System.Drawing.Point(44, 3);
      this.priceEntry.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
      this.priceEntry.Name = "priceEntry";
      this.priceEntry.Size = new System.Drawing.Size(117, 20);
      this.priceEntry.TabIndex = 9;
      this.priceEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 403);
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
      this.statBonusGroup.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LUCEntry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.AGIEntry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.WISEntry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.VITEntry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TECEntry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.STREntry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TPEntry)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.HPEntry)).EndInit();
      this.classGroup.ResumeLayout(false);
      this.classGroup.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.flags.ResumeLayout(false);
      this.flags.PerformLayout();
      this.priceTable.ResumeLayout(false);
      this.priceTable.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.priceEntry)).EndInit();
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
    private System.Windows.Forms.Label nameLabel;
    private System.Windows.Forms.TextBox itemName;
    private System.Windows.Forms.Label typeLabel;
    private System.Windows.Forms.ComboBox itemType;
    private System.Windows.Forms.Panel namePreviewPanel;
    private System.Windows.Forms.TableLayoutPanel ATKDEFEntryPanel;
    private System.Windows.Forms.Label physicalLabel;
    private System.Windows.Forms.Label magicLabel;
    private System.Windows.Forms.NumericUpDown physicalEntry;
    private System.Windows.Forms.NumericUpDown magicEntry;
    private System.Windows.Forms.GroupBox statBonusGroup;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label HPLabel;
    private System.Windows.Forms.Label TPLabel;
    private System.Windows.Forms.Label STRLabel;
    private System.Windows.Forms.Label TECLabel;
    private System.Windows.Forms.Label VITLabel;
    private System.Windows.Forms.Label WISLabel;
    private System.Windows.Forms.Label AGILabel;
    private System.Windows.Forms.Label LUCLabel;
    private System.Windows.Forms.NumericUpDown LUCEntry;
    private System.Windows.Forms.NumericUpDown AGIEntry;
    private System.Windows.Forms.NumericUpDown WISEntry;
    private System.Windows.Forms.NumericUpDown VITEntry;
    private System.Windows.Forms.NumericUpDown TECEntry;
    private System.Windows.Forms.NumericUpDown STREntry;
    private System.Windows.Forms.NumericUpDown TPEntry;
    private System.Windows.Forms.NumericUpDown HPEntry;
    private System.Windows.Forms.GroupBox classGroup;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.CheckBox princess;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.CheckBox checkBox4;
    private System.Windows.Forms.CheckBox checkBox5;
    private System.Windows.Forms.CheckBox checkBox6;
    private System.Windows.Forms.CheckBox checkBox7;
    private System.Windows.Forms.CheckBox checkBox8;
    private System.Windows.Forms.CheckBox checkBox9;
    private System.Windows.Forms.CheckBox checkBox10;
    private System.Windows.Forms.CheckBox checkBox11;
    private System.Windows.Forms.FlowLayoutPanel flags;
    private System.Windows.Forms.CheckBox requiresRestock;
    private System.Windows.Forms.CheckBox goldIcon;
    private System.Windows.Forms.CheckBox starterEquipment;
    private System.Windows.Forms.TableLayoutPanel priceTable;
    private System.Windows.Forms.NumericUpDown priceEntry;
    private System.Windows.Forms.Label priceLabel;
  }
}