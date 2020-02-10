using EO3EquipmentEdit.Data;
using OriginTablets.Types;
using System.Collections.Generic;
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
      // Equipment table and requirements output.
      string equipmentTableOutputPath = Path.Combine(directory, "equipitemtable.tbl");
      string equipmentUnlockRequirementsOutputPath = Path.Combine(directory, "equipitemcompound.tbl");
      using (var writer = new BinaryWriter(new FileStream(equipmentTableOutputPath, FileMode.Create)))
      using (var requirementsWriter = new BinaryWriter(new FileStream(equipmentUnlockRequirementsOutputPath, FileMode.Create)))
      {
        foreach (var item in equipmentData)
        {
          item.WriteToFile(writer);
          item.Requirements.WriteToFile(requirementsWriter);
        }
      }
      // Names output.
      string equipmentNameTableOutputPath = Path.Combine(directory, "equipitemnametable.tbl");
      equipmentNames.WriteToFile(equipmentNameTableOutputPath, false);
      // Descriptions output.
      string equipmentDescriptionsOutputPath = Path.Combine(directory, "equipitemexpbattle.mbm");
      equipmentDescriptions.WriteToFile(equipmentDescriptionsOutputPath);
    }
  }
}