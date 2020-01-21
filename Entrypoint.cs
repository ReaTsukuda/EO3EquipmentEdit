using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EO3EquipmentEdit.Data;
using OriginTablets.Types;

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
      using (var openDialog = new OpenFileDialog())
      {
        // equipitemtable.tbl
        openDialog.Filter = "Equipment table (equipitemtable.tbl)|equipitemtable.tbl";
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
          string equipItemTableLocation = openDialog.FileName;
          // equipitemnametable.tbl
          openDialog.Filter = "Equipment name table (equipitemnametable.tbl)|equipitemnametable.tbl";
          if (openDialog.ShowDialog() == DialogResult.OK)
          {
            string equipItemNameTableLocation = openDialog.FileName;
            // equipitemexpbattle.mbm
            openDialog.Filter = "Equipment descriptions (equipitemexpbattle.mbm)|equipitemexpbattle.mbm";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
              string equipItemDescriptionsLocation = openDialog.FileName;
              // Load item names.
              var equipmentNames = new Table(equipItemNameTableLocation, false);
              // Load item descriptions
              var equipmentDescriptions = new MBM(equipItemDescriptionsLocation);
              // Create the equipment list.
              var equipment = new List<Equipment>();
              using (var reader = new BinaryReader(new FileStream(equipItemTableLocation, FileMode.Open)))
              {
                int itemIndex = 0;
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                  equipment.Add(new Equipment(itemIndex, reader, equipmentNames, equipmentDescriptions));
                  itemIndex += 1;
                }
              }
              Application.Run(new MainForm(equipment, equipmentNames, equipmentDescriptions));
            }
            else { Application.Exit(); }
          }
          else { Application.Exit(); }
        }
        else { Application.Exit(); }
      }
    }
  }
}
