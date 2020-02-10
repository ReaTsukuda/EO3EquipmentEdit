using EO3EquipmentEdit.Data;
using Microsoft.WindowsAPICodePack.Dialogs;
using OriginTablets.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EO3EquipmentEdit
{
  internal static class Entrypoint
  {
    /// <summary>
    /// EquipmentEdit's entrypoint function.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      // We prompt the user for where various files are is before showing a form. Once the
      // application's been launched once, we can cache this. If any of the files aren't loaded,
      // then exit.
      using (var openDialog = new CommonOpenFileDialog())
      {
        openDialog.IsFolderPicker = true;
        openDialog.AllowNonFileSystemItems = true;
        openDialog.Title = "Select the equipment data files' location";
        if (openDialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
          Table equipmentNames = null;
          MBM equipmentDescriptions = null;
          List<Equipment> equipment = null;
          Table useItemNames = null;
          List<UseItem> useItems = new List<UseItem>();
          string equipItemDescriptionsLocation = Path.Combine(openDialog.FileName, "equipitemexpbattle.mbm");
          string equipItemNameTableLocation = Path.Combine(openDialog.FileName, "equipitemnametable.tbl");
          string equipItemTableLocation = Path.Combine(openDialog.FileName, "equipitemtable.tbl");
          string equipItemCompoundLocation = Path.Combine(openDialog.FileName, "equipitemcompound.tbl");
          string useItemNameTableLocation = Path.Combine(openDialog.FileName, "useitemnametable.tbl");
          try
          {
            // Load item names.
            equipmentNames = new Table(equipItemNameTableLocation, false);
            // Load item descriptions
            equipmentDescriptions = new MBM(equipItemDescriptionsLocation);
            // Load use item names.
            useItemNames = new Table(useItemNameTableLocation, false);
            // Create the use item list.
            for (int index = 0; index < useItemNames.Count; index += 1)
            {
              useItems.Add(new UseItem(useItemNames, index));
            }
            // Create the equipment list.
            equipment = new List<Equipment>();
            using (var reader = new BinaryReader(new FileStream(equipItemTableLocation, FileMode.Open)))
            {
              int itemIndex = 0;
              while (reader.BaseStream.Position < reader.BaseStream.Length)
              {
                equipment.Add(new Equipment(itemIndex, reader, equipmentNames, equipmentDescriptions, useItems));
                itemIndex += 1;
              }
            }
            // Load unlock requirements.
            using (var reader = new BinaryReader(new FileStream(equipItemCompoundLocation, FileMode.Open)))
            {
              foreach (Equipment item in equipment)
              {
                item.Requirements.First.ItemIndex = reader.ReadUInt16();
                item.Requirements.Second.ItemIndex = reader.ReadUInt16();
                item.Requirements.Third.ItemIndex = reader.ReadUInt16();
                item.Requirements.First.Amount = reader.ReadByte();
                item.Requirements.Second.Amount = reader.ReadByte();
                item.Requirements.Third.Amount = reader.ReadByte();
                reader.ReadByte(); // Alignment spacer, skip.
              }
            }
          }
          catch (IOException)
          {
            MessageBox.Show("One or more of the equipment files could not be loaded.", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
          }
          Application.Run(new MainForm(equipment, equipmentNames, equipmentDescriptions, useItems));
        }
        else { Environment.Exit(0); }
      }
    }
  }
}