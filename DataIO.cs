using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO3EquipmentEdit.Data;
using OriginTablets.Types;
using System.IO;

namespace EO3EquipmentEdit
{
  /// <summary>
  /// Handles writing out the equipment files.
  /// </summary>
  public static class DataIO
  {
    /// <summary>
    /// Writes all of the equipment files to the specified directory.
    /// </summary>
    /// <param name="directory">The destination directory for the files.</param>
    /// <param name="equipmentData">The list of equipment.</param>
    /// <param name="equipmentNames">The equipment name table.</param>
    /// <param name="equipmentDescriptions">The equipment description MBM.</param>
    public static void WriteEquipmentData(
      string directory, 
      List<Equipment> equipmentData, 
      Table equipmentNames, 
      MBM equipmentDescriptions)
    {
      // Equipment table output.
      string equipmentTableOutputPath = directory + "/equipitemtable.tbl";
      using (var writer = new BinaryWriter(new FileStream(equipmentTableOutputPath, FileMode.Create)))
      {
        foreach (var item in equipmentData)
        {
          item.WriteToFile(writer);
        }
      }
      // Names output.
      string equipmentNameTableOutputPath = directory + "/equipitemnametable.tbl";
      equipmentNames.WriteToFile(equipmentNameTableOutputPath, false);
      // Descriptions output.
      string equipmentDescriptionsOutputPath = directory + "/equipitemexpbattle.mbm";
      equipmentDescriptions.WriteToFile(equipmentDescriptionsOutputPath);
    }
  }
}
