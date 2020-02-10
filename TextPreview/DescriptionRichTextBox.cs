using EO3EquipmentEdit.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EO3EquipmentEdit.TextPreview
{
  /// <summary>
  /// An extension of the RichTextBox control that can better handle EO3 control codes.
  /// </summary>
  public partial class DescriptionRichTextBox : RichTextBox
  {
    private Equipment _Equipment;

    /// <summary>
    /// The currently-selected equipment.
    /// </summary>
    public Equipment Equipment
    {
      get => _Equipment;
      set
      {
        _Equipment = value;
        Text = _Equipment.Description.Replace("[80 01]", "[80 01]\n");
      }
    }

    public DescriptionRichTextBox()
    {
      InitializeComponent();
      Size = new Size(234, 80);
    }

    /// <summary>
    /// Sanitizes text before running the TextChanged handlers.
    /// </summary>
    protected override void OnTextChanged(EventArgs eventArgs)
    {
      Equipment.Description = base.Text.Replace("\n", "");
      base.OnTextChanged(eventArgs);
    }
  }
}