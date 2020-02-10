using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EO3EquipmentEdit.Data
{
  /// <summary>
  /// Represents items in useitemtable, which are used as materials for unlocking equipment.
  /// </summary>
  public class UseItem
  {
    /// <summary>
    /// The useitemnametable.tbl object.
    /// </summary>
    private List<string> Names;

    /// <summary>
    /// The item's position in useitemtable.tbl.
    /// </summary>
    private int Index = 0;

    /// <summary>
    /// The item's name.
    /// </summary>
    public string Name => Names[Index];

    public UseItem(List<string> names, int index)
    {
      Names = names;
      Index = index;
    }
  }
}
