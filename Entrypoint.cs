using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EO3EquipmentEdit
{
  static class Entrypoint
  {
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.Run(new MainForm());
    }
  }
}
