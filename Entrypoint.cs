using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EO3EquipmentEdit.Data;
using OriginTablets.Types;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EO3EquipmentEdit
{
  static class Entrypoint
  {
    /// <summary>
    /// EquipmentEdit's entrypoint function.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      // We prompt the user for where various files are is before showing a form.
      // Once the application's been launched once, we can cache this.
      // If any of the files aren't loaded, then exit.
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
          string equipItemDescriptionsLocation = openDialog.FileName + "/equipitemexpbattle.mbm";
          string equipItemNameTableLocation = openDialog.FileName + "/equipitemnametable.tbl";
          string equipItemTableLocation = openDialog.FileName + "/equipitemtable.tbl";
          try
          {
            // Load item names.
            equipmentNames = new Table(equipItemNameTableLocation, false);
            // Load item descriptions
            equipmentDescriptions = new MBM(equipItemDescriptionsLocation);
            // Create the equipment list.
            equipment = new List<Equipment>();
            using (var reader = new BinaryReader(new FileStream(equipItemTableLocation, FileMode.Open)))
            {
              int itemIndex = 0;
              while (reader.BaseStream.Position < reader.BaseStream.Length)
              {
                equipment.Add(new Equipment(itemIndex, reader, equipmentNames, equipmentDescriptions));
                itemIndex += 1;
              }
            }
          }
          catch (IOException)
          {
            MessageBox.Show("One or more of the equipment files could not be loaded.", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
          }
          Application.Run(new MainForm(equipment, equipmentNames, equipmentDescriptions));
        }
        else { Environment.Exit(0); }
      }
    }
  }
}
