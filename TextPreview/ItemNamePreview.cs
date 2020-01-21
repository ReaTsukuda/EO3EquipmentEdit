using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EO3EquipmentEdit.TextPreview
{
  public partial class ItemNamePreview : PictureBox
  {
    readonly new EO3Font Font;

    private string _Text;

    /// <summary>
    /// The name that is displayed in the item name preview.
    /// </summary>
    public new string Text
    {
      get => _Text;
      set
      {
        _Text = value;
        if (Image != null) { Image.Dispose(); }
        Image = Font.GetString(_Text);
      }
    }
    
    /// <summary>
    /// The only constructor you should use for ItemNamePreview.
    /// </summary>
    /// <param name="font">The 10px font we use for item name previews.</param>
    public ItemNamePreview(EO3Font font)
    {
      Font = font;
      Size = new Size(102, 10);
      BackColor = Color.White;
    }
  }
}
