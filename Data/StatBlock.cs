namespace EO3EquipmentEdit.Data
{
  /// <summary>
  /// Represents a block of player stats. Used, for example, in numeric equipment bonuses.
  /// </summary>
  public class StatBlock
  {
    public int HP { get; set; }
    public int TP { get; set; }
    public int STR { get; set; }
    public int TEC { get; set; }
    public int VIT { get; set; }
    public int WIS { get; set; }
    public int AGI { get; set; }
    public int LUC { get; set; }
  }
}